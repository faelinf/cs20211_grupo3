using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Banco;
using Banco.Controllers;
using Autofac.Extras.Moq;
using Banco.Models;

namespace BancoTeste
{
    public class BancoControllerTest
    {
        [Theory]
        [InlineData("1234", "12345-6", "1234", "970")]
        public void testaGetSaldo(string agencia, string conta, string senha, string esperado)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Usuario usuario = new Usuario();
                usuario.Agencia = agencia;
                usuario.Conta = conta;
                usuario.Senha = senha;
                usuario.Saldo = Convert.ToDouble(esperado);
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuarioLogin())
                    .Returns(usuario);
                var cls = mock.Create<BDController>();
                var banco = new BancoController();
                banco.busca = cls;
                var resultado = banco.GetSaldo();
                Assert.Equal(resultado, esperado);
            }
        }

        [Theory]
        [InlineData("1234", "12345-6", "1234", "970", "correto")]
        public void testaGetTransacoes(string agencia, string conta, string senha,string valor, string esperado)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Usuario usuario = new Usuario();
                usuario.Id = 1;
                usuario.Agencia = agencia;
                usuario.Conta = conta;
                usuario.Senha = senha;
                usuario.Saldo = Convert.ToDouble(valor);
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuarioLogin())
                    .Returns(usuario);
                mock.Mock<BDController>()
                    .Setup(x => x.buscaTrasacoesId(usuario.Id))
                    .Returns(esperado);
                var cls = mock.Create<BDController>();
                var banco = new BancoController();
                banco.busca = cls;
                var resultado = banco.GetTransacoes();
                Assert.Equal(resultado, esperado);
            }
        }

        [Theory]
        [InlineData("1234", "12345-6", "1234", "970")]
        public void testaPostSaque(string agencia, string conta, string senha, string valor)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mensagens mensagem = new Mensagens();
                double valorD = Convert.ToDouble(valor);
                Usuario usuario = new Usuario();
                usuario.Agencia = agencia;
                usuario.Conta = conta;
                usuario.Senha = senha;
                usuario.Saldo = valorD;
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuarioLogin())
                    .Returns(usuario);
                mock.Mock<BDController>()
                    .Setup(x => x.alteraSaldo(usuario, valorD, mensagem.SAQUE))
                    .Returns(true);
                var cls = mock.Create<BDController>();
                var banco = new BancoController();
                banco.busca = cls;
                var resultado = banco.PostSaque(valor);
                Assert.Equal(resultado, mensagem.OPERACAO_SUCESSO);
            }
        }

        [Theory]
        [InlineData("1234", "12345-6", "1234", "970")]
        public void testaPostDeposito(string agencia, string conta, string senha, string valor)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mensagens mensagem = new Mensagens();
                double valorD = Convert.ToDouble(valor);
                Usuario usuario = new Usuario();
                usuario.Agencia = agencia;
                usuario.Conta = conta;
                usuario.Senha = senha;
                usuario.Saldo = valorD;
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuarioLogin())
                    .Returns(usuario);
                mock.Mock<BDController>()
                    .Setup(x => x.alteraSaldo(usuario, valorD, mensagem.DEPOSITO))
                    .Returns(true);
                var cls = mock.Create<BDController>();
                var banco = new BancoController();
                banco.busca = cls;
                var resultado = banco.PostDeposito(valor);
                Assert.Equal(resultado, mensagem.OPERACAO_SUCESSO);
            }
        }

        [Theory]
        [InlineData("1234", "12345-6", "1234", "970", "1234", "12345-6", "05427805184")]
        public void testaPostTransferencia(string agenciaOrigem, string contaOrigem, string senha, string valor, string agenciaDestino, string contaDestino, string CPFDestinatario)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mensagens mensagem = new Mensagens();
                double valorD = Convert.ToDouble(valor);
                Usuario usuario = new Usuario();
                usuario.Agencia = agenciaOrigem;
                usuario.Conta = contaOrigem;
                usuario.Senha = senha;
                usuario.Saldo = valorD;
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuarioLogin())
                    .Returns(usuario);
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuariosCpf(agenciaDestino, contaDestino, CPFDestinatario))
                    .Returns(usuario);
                List<Usuario> usuarios = new List<Usuario>();
                usuarios.Add(usuario);
                usuarios.Add(usuario);
                mock.Mock<BDController>()
                    .Setup(x => x.realizaTransferencia(usuarios, valorD, mensagem.TRANSFERENCIA))
                    .Returns(true);
                var cls = mock.Create<BDController>();
                var banco = new BancoController();
                banco.busca = cls;
                var resultado = banco.PostTransferencia(valor, agenciaDestino, contaDestino, CPFDestinatario);
                Assert.Equal(resultado, mensagem.OPERACAO_SUCESSO);
            }
        }

        [Theory]
        [InlineData("1234567891234567", "01-2021", "123", "f", "1234", "978", "1234", "12345-6", "05427805184")]
        public void testaPostPagamento(string numeroCartao, string validade, string CVV, string nome, string senha, string valor, string agenciaDestino, string contaDestino, string CPFDestinatario)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mensagens mensagem = new Mensagens();
                double valorD = Convert.ToDouble(valor);
                Cartoes cartao = new Cartoes();
                cartao.Tipo = "Debito";
                cartao.UsuarioId = 1;
                Usuario usuario = new Usuario();
                usuario.Id = 1;
                usuario.Agencia = agenciaDestino;
                usuario.Conta = contaDestino;
                usuario.Senha = senha;
                usuario.Saldo = valorD + 10;
                mock.Mock<BDController>()
                    .Setup(x => x.buscaCartao(nome, numeroCartao, CVV, senha, validade))
                    .Returns(cartao);
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuariosCpf(agenciaDestino, contaDestino, CPFDestinatario))
                    .Returns(usuario);
                List<Usuario> usuarios = new List<Usuario>();
                usuarios.Add(usuario);
                usuarios.Add(usuario);
                mock.Mock<BDController>()
                    .Setup(x => x.realizaTransferencia(usuarios, valorD, mensagem.PAGAMENTO))
                    .Returns(true);
                mock.Mock<BDController>()
                    .Setup(x => x.buscaUsuarioPeloId(1))
                    .Returns(usuario);
                var cls = mock.Create<BDController>();
                var banco = new BancoController();
                banco.busca = cls;
                var resultado = banco.PostPagamento(numeroCartao, validade, CVV, nome, senha, valor, agenciaDestino, contaDestino, CPFDestinatario);
                Assert.Equal(resultado, mensagem.OPERACAO_SUCESSO);
            }
        }
    }

}
