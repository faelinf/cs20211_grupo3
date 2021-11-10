using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Banco.Models;
using System.Collections.Generic;

namespace Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        public ValidadorDadosController validador;
        public BDController busca;
        public Mensagens mensagens;

        public BancoController()
        {
            validador = new ValidadorDadosController();
            busca = new BDController();
            mensagens = new Mensagens();
        }

        // GET: api/Banco/saldo
        [HttpGet("saldo")]
        public string GetSaldo()
        {
            try
            {
                double saldo = busca.buscaUsuarioLogin().Saldo;
                return saldo.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // GET: api/Banco/validacao
        [HttpGet("validacao")]
        public string GetValidacao()
        {
            try
            {
                Usuario usuario = busca.buscaUsuarioLogin();
                if(usuario != null) {
                    return "sucesso";
                }
                return "falha";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Post: api/Banco/login
        [HttpPost("login")]
        public string PostLogin(string agencia, string conta, string senha)
        {
            try
            {
                Usuario usuario = busca.buscaUsuariosSenha(agencia, conta, senha);
                if (usuario != null)
                {
                    if (busca.realizaLogin(usuario))
                    {
                        return "sucesso";
                    }

                }
                return "Algum erro inesperado ocorreu";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        // POST: api/Banco/cadastro
        [HttpPost("cadastro")]
        public string PostUsuario(Usuario usuario)
        {
            bool resultado = BancoDB.AdicionaUsuario(usuario);
            if (resultado)
            {
                return "Cliente cadastrado com sucesso";
            }
            return "Erro ao cadastrar cliente";
        }

        // GET: api/Banco/extrato
        [HttpGet("extrato")]
        public string GetTransacoes()
        {
            try
            {
                int idUsuario = busca.buscaUsuarioLogin().Id;
                string transacoesUsuario = busca.buscaTrasacoesId(idUsuario);
                return transacoesUsuario;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // POST: api/Banco/saque
        [HttpPost("saque")]
        public string PostSaque(string valor)
        {
            try
            {
                validador.validaValor(valor);
                double valorDouble = Convert.ToDouble(valor);
                Usuario usuario = busca.buscaUsuarioLogin();
                bool resultado = busca.alteraSaldo(usuario, valorDouble, mensagens.SAQUE);
                if (resultado)
                {
                    return mensagens.OPERACAO_SUCESSO;
                }
                return mensagens.OPERACAO_ERRO;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // POST: api/Banco/deposito
        [HttpPost("deposito")]
        public string PostDeposito(string valor)
        {
            try
            {
                validador.validaValor(valor);
                double valorDouble = Convert.ToDouble(valor);
                Usuario usuario = busca.buscaUsuarioLogin();
                bool resultado = busca.alteraSaldo(usuario, valorDouble, mensagens.DEPOSITO);
                if (resultado)
                {
                    return mensagens.OPERACAO_SUCESSO;
                }
                return mensagens.OPERACAO_ERRO;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // POST: api/Banco/transferencia
        [HttpPost("transferencia")]
        public string PostTransferencia(string valor, string agenciaDestino, string contaDestino, string CPFDestinatario)
        {
            try
            {
                validador.validarTransferencia(valor, agenciaDestino, contaDestino, CPFDestinatario);
                double valorDouble = Convert.ToDouble(valor);
                Usuario usuarioOrigem = busca.buscaUsuarioLogin();
                Usuario usuarioDestino = busca.buscaUsuariosCpf(agenciaDestino, contaDestino, CPFDestinatario);
                List<Usuario> usuarios = new List<Usuario>();
                usuarios.Add(usuarioOrigem);
                usuarios.Add(usuarioDestino);
                bool resultado = busca.realizaTransferencia(usuarios, valorDouble, mensagens.TRANSFERENCIA);
                if (resultado)
                {
                    return mensagens.OPERACAO_SUCESSO;
                }
                return mensagens.OPERACAO_ERRO;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // POST: api/Banco/pagamento
        [HttpPost("pagamento")]
        public string PostPagamento(string numeroCartao, string validade, string CVV, string nome, string senha, string valor, string agenciaDestino, string contaDestino, string CPFDestinatario)
        {
            try
            {
                validador.validaPagamento(numeroCartao, validade, CVV, nome, senha, valor, agenciaDestino, contaDestino, CPFDestinatario);
                double valorDouble = Convert.ToDouble(valor);
                Usuario usuarioDestino = busca.buscaUsuariosCpf(agenciaDestino, contaDestino, CPFDestinatario);
                Cartoes cartao = busca.buscaCartao(nome, numeroCartao, CVV, senha, validade);
                Usuario usuarioOrigem = busca.buscaUsuarioPeloId(cartao.UsuarioId);
                if (cartao.Tipo == "Debito" && usuarioOrigem.Saldo - valorDouble < 0)
                {
                    return "saldo insuficiente";
                }
                if (cartao.Limite - valorDouble < 0 && cartao.Tipo == "Credito")
                {
                    return "limite insuficiente";
                }
                List<Usuario> usuarios = new List<Usuario>();
                usuarios.Add(usuarioOrigem);
                usuarios.Add(usuarioDestino);
                bool resultado = busca.realizaTransferencia(usuarios, valorDouble, mensagens.PAGAMENTO);
                if (resultado)
                {
                    return mensagens.OPERACAO_SUCESSO;
                }
                return mensagens.OPERACAO_ERRO;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
