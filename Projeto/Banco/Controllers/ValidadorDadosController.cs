using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System;

namespace Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidadorDadosController : ControllerBase
    {
        public void validaAgenciaContaSenha(string agencia, string conta, string senha)
        {
            string erros = "erros: \n";
            erros = erros + validaAgencia(agencia);
            erros = erros + validaConta(conta);
            erros = erros + validaSenha(senha);
            if (erros != "erros: \n")
            {
                throw new System.Exception(erros);
            }
        }

        public string validaAgenciaContaCPF(string agencia, string conta, string cpf)
        {
            string erros = validaAgencia(agencia);
            erros = erros + validaConta(conta);
            erros = erros + validaCPF(cpf);
            return erros;
        }
        public string validaCartao(string numeroCartao, string validade, string CVV, string nome, string senha, string valor)
        {
            string erros = "erros: \n";
            erros = erros + validaNumeroCartao(numeroCartao);
            erros = erros + validaValidade(validade);
            erros = erros + validaCVV(CVV);
            erros = erros + validaNome(nome);
            erros = erros + validaSenha(senha);
            erros = erros + validaValorInterna(valor);
            return erros;
        }

        public void validarTransferencia(string valor, string agenciaDestino, string contaDestino, string CPFDestinatario)
        {
            string erros = "erros: \n";
            erros = erros + validaValorInterna(valor);
            erros = erros + validaAgenciaContaCPF(agenciaDestino, contaDestino, CPFDestinatario);
            if (erros != "erros: \n")
            {
                throw new System.Exception(erros);
            }
        }

        public void validaPagamento(string numeroCartao, string validade, string CVV, string nome, string senha, string valor, string agenciaDestino, string contaDestino, string CPFDestinatario)
        {
            string erros = validaCartao(numeroCartao, validade, CVV, nome, senha, valor);
            erros = erros + validaAgenciaContaCPF(agenciaDestino, contaDestino, CPFDestinatario);
            if (erros != "erros: \n")
            {
                throw new System.Exception(erros);
            }
        }

        public string validaAgencia(string agencia)
        {
            if (!Regex.Match(agencia, @"\d{4}").Success)
            {
                return "O campo agência deve conter apenas números e ter tamanho igual a 4 \n ";
            }
            return "";
        }

        public void validaValor(string valor)
        {
            if (Regex.Match(valor, @"^[\d\.,]+$").Success)
            {
                double valorDouble = Convert.ToDouble(valor);
                if (valorDouble <= 0)
                {
                    throw new System.Exception("erros: \nO valor passado deve ser maior que 0,00");
                }
            }
            else
            {
                throw new System.Exception("erros: \nO valor deve conter apenas numeros");
            }

        }

        public string validaValorInterna(string valor)
        {
            if (Regex.Match(valor, @"^[\d\.,]+$").Success)
            {
                double valorDouble = Convert.ToDouble(valor);
                if (valorDouble <= 0)
                {
                    return "O valor passado deve ser maior que 0,00 \n ";
                }
                return "";
            }
            else
            {
                return "O valor deve conter apenas numeros\n";
            }

        }

        public string validaConta(string conta)
        {
            if (!Regex.Match(conta, @"\d+-\d").Success)
            {
                return "O campo conta deve ser no formato XXXXX-X e conter apenas números \n ";
            }
            return "";
        }
        public string validaSenha(string senha)
        {
            if (!Regex.Match(senha, @"\d{4}").Success)
            {
                return "O campo senha deve conter apenas 4 números \n ";
            }
            return "";
        }
        public string validaCPF(string cpf)
        {
            if (!IsCpf(cpf))
            {
                return "O cpf não é valido \n ";
            }
            return "";
        }

        public string validaNumeroCartao(string numero)
        {
            if (!Regex.Match(numero, @"\d{16}").Success)
            {
                return "O campo numero cartão deve conter apenas números e ter tamanho igual a 16 \n ";
            }
            return "";
        }
        public string validaValidade(string validade)
        {
            if (!Regex.Match(validade, @"\d{2}-\d{2}").Success)
            {
                return "O campo validade deve ser no formato XX-XX e conter apenas números e o - separando-os \n ";
            }
            return "";
        }
        public string validaCVV(string cvv)
        {
            if (!Regex.Match(cvv, @"\d{3}").Success)
            {
                return "O campo CVV deve ser no formato XXX e conter apenas números \n ";
            }
            return "";
        }
        public string validaNome(string nome)
        {
            if (!Regex.Match(nome, @"[a-zA-Z ]+").Success)
            {
                return "O campo nome deve conter apenas letras e espaçamentos \n ";
            }
            return "";
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
