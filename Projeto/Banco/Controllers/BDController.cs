using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Banco.Models;
using System.Collections.Generic;
using System;

namespace Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BDController : ControllerBase
    {
        Mensagens mensagens;
        public BDController()
        {
            mensagens = new Mensagens();
        }
        public virtual Usuario buscaUsuariosSenha(string agencia, string conta, string senha)
        {
            List<Usuario> usuarios = BancoDB.GetUsuarios();
            List<Usuario> usuariosCorretos = new List<Usuario>();
            foreach (Usuario usuarioAtual in usuarios)
            {
                if (usuarioAtual.Agencia == agencia && usuarioAtual.Conta == conta && usuarioAtual.Senha == senha)
                {
                    usuariosCorretos.Add(usuarioAtual);
                }
            }

            if (!usuariosCorretos.Any())
            {
                throw new System.Exception(mensagens.USUARIOS_VAZIO);
            }

            return usuariosCorretos.First();
        }

        public virtual Usuario buscaUsuarioLogin()
        {
            DateTime dataAtual = DateTime.Now;
            List<Login> logins = BancoDB.GetLogin();
            Login login = new Login();
            bool logado = false;
            foreach (Login loginAtual in logins) {
                DateTime dataLogin = loginAtual.Data;
                DateTime data15Min = dataLogin.AddMinutes(15);
                if (data15Min.CompareTo(dataAtual) >= 0 && dataLogin.CompareTo(dataAtual) < 0) {
                    logado = true;
                    login = loginAtual;
                }
            }
            if(logado)
            {
                return buscaUsuarioPeloId(login.UsuarioId);
            } else
            {
                throw new System.Exception(mensagens.NAO_LOGADO);
            }
            
        }

        public virtual bool realizaLogin(Usuario usuario) {
            DateTime data = DateTime.Now;
            return BancoDB.addLogin(usuario.Id, data);
            
        }

        public virtual Usuario buscaUsuariosCpf(string agencia, string conta, string cpf)
        {
            List<Usuario> usuarios = BancoDB.GetUsuarios();
            List<Usuario> usuariosCorretos = new List<Usuario>();
            foreach (Usuario usuarioAtual in usuarios)
            {
                if (usuarioAtual.Agencia == agencia && usuarioAtual.Conta == conta && usuarioAtual.CPF == cpf)
                {
                    usuariosCorretos.Add(usuarioAtual);
                }
            }

            if (!usuariosCorretos.Any())
            {
                throw new System.Exception(mensagens.USUARIOS_VAZIO);
            }

            return usuariosCorretos.First();
        }



        public virtual string buscaTrasacoesId(int idUsuario)
        {
            List<Transacao> transacoesUsuario = BancoDB.GetTransacaoDeUsuario(idUsuario);
            if (!transacoesUsuario.Any())
            {
                throw new System.Exception(mensagens.TRANSACOES_VAZIAS);
            }
            string resultado = "";
            Usuario usuarioDestinatario;
            foreach(Transacao transacao in transacoesUsuario) {
                usuarioDestinatario = buscaUsuarioPeloId(transacao.DestinatarioId);
                resultado = resultado + transacao.ToString() + ", Destinatario: " + usuarioDestinatario.Nome + "\n";
            }
            return resultado;
        }

        public virtual bool alteraSaldo(Usuario usuario, double valor, string tipo)
        {
            if (tipo == mensagens.SAQUE)
            {
                if (usuario.Saldo < valor)
                {
                    throw new System.Exception(mensagens.SALDO_INSUFICIENTE);
                }
                usuario.Saldo = usuario.Saldo - valor;
            }
            else if (tipo == mensagens.DEPOSITO)
            {
                usuario.Saldo = usuario.Saldo + valor;
            }
            return BancoDB.AlteraSaldo(usuario);
        }

        public virtual bool realizaTransferencia(List<Usuario> usuarios, double valor, string tipo)
        {
            bool sucesso = true;
            sucesso = alteraSaldo(usuarios.First(), valor, mensagens.SAQUE);
            if(sucesso) {
                sucesso = alteraSaldo(usuarios.Last(), valor, mensagens.DEPOSITO);
            }
            if(sucesso) {
                sucesso =  BancoDB.addTransferencia(usuarios.First(), usuarios.Last(), valor, tipo);
            } else {
                alteraSaldo(usuarios.First(), 0, mensagens.DEPOSITO);
                alteraSaldo(usuarios.Last(), 0, mensagens.DEPOSITO);
            }
            return sucesso;
        }

        public virtual Cartoes buscaCartao(string nome, string numeroCartao, string CVV, string senha, string validade) {
            List<Cartoes> listaCartoes = BancoDB.GetCartoes();
            Cartoes cartaoCorreto = null;
            foreach (Cartoes cartao in listaCartoes)
            {
                if (cartao.Nome == nome && cartao.Numero == numeroCartao && cartao.CVV == CVV && cartao.Senha == senha && cartao.Validade == validade)
                {
                    cartaoCorreto = cartao;
                }
            }
            if (cartaoCorreto == null)
            {
                throw new System.Exception(mensagens.USUARIOS_VAZIO);
            }
            return cartaoCorreto;
        }

         public virtual Usuario buscaUsuarioPeloId(int id) {
            List<Usuario> usuarios = BancoDB.GetUsuarios();
            Usuario usuarioCorreto = null;
            foreach (Usuario usuarioAtual in usuarios)
            {
                if (usuarioAtual.Id == id)
                {
                    usuarioCorreto = usuarioAtual;
                }
            }
            if (usuarioCorreto == null)
            {
                throw new System.Exception(mensagens.USUARIOS_VAZIO);
            }
            return usuarioCorreto;
        }
    }
}
