using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Banco.Controllers;

namespace BancoTeste
{
    public class ValidacaoControllerTest
    {
        [Theory]
        [InlineData("1234", "12345-6", "1234", "sucesso")]
        [InlineData("123a", "12345-6", "1234", "erros: \nO campo agência deve conter apenas números e ter tamanho igual a 4 \n ")]
        [InlineData("1234", "12345", "1234", "erros: \nO campo conta deve ser no formato XXXXX-X e conter apenas números \n ")]
        [InlineData("1234", "12345-6", "123a", "erros: \nO campo senha deve conter apenas 4 números \n ")]
        [InlineData("123a", "12345a", "123a", "erros: \nO campo agência deve conter apenas números e ter tamanho igual a 4 \n O campo conta deve ser no formato XXXXX-X e conter apenas números \n O campo senha deve conter apenas 4 números \n ")]
        public void testaValidacaoAgenciaContaSenha(string agencia, string conta, string senha, string esperado) 
        {
            ValidadorDadosController validador = new ValidadorDadosController();
            String resultado = "sucesso";
            try
            {
                validador.validaAgenciaContaSenha(agencia, conta, senha);
            } catch (Exception e) {
                resultado = e.Message;
            }
            Assert.Equal(resultado, esperado);
        }
        [Theory]
        [InlineData("1", "sucesso")]
        [InlineData("a", "erros: \nO valor deve conter apenas numeros")]
        public void testaValidaAgenciaContaSenhaValor(string valor, string esperado)
        {
            ValidadorDadosController validador = new ValidadorDadosController();
            String resultado = "sucesso";
            try
            {
                validador.validaValor(valor);
            }
            catch (Exception e)
            {
                resultado = e.Message;
            }
            Assert.Equal(resultado, esperado);
        }

        [Theory]
        [InlineData("1", "4321", "65432-1", "05427805184", "sucesso")]
        
        public void testaValidaTransferencia(string valor, string agenciaDestino, string contaDestino, string CPFDestinatario, string esperado)
        {
            ValidadorDadosController validador = new ValidadorDadosController();
            String resultado = "sucesso";
            try
            {
                validador.validarTransferencia(valor, agenciaDestino, contaDestino, CPFDestinatario);
            }
            catch (Exception e)
            {
                resultado = e.Message;
            }
            Assert.Equal(resultado, esperado);
        }

        [Theory]
        [InlineData("1234567891234567", "01-2021", "123", "f","1234", "1","4321", "65432-1", "05427805184", "sucesso")]
        
        public void testaValidaPagamento(string numeroCartao, string validade, string CVV, string nome, string senha, string valor, string agenciaDestino, string contaDestino, string CPFDestinatario, string esperado)
        {
            ValidadorDadosController validador = new ValidadorDadosController();
            String resultado = "sucesso";
            try
            {
                validador.validaPagamento(numeroCartao, validade, CVV, nome, senha, valor, agenciaDestino, contaDestino, CPFDestinatario);
            }
            catch (Exception e)
            {
                resultado = e.Message;
            }
            Assert.Equal(resultado, esperado);
        }
    }
}
