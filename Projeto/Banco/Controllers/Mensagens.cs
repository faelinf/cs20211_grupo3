using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mensagens : ControllerBase
    {
        public string USUARIOS_VAZIO = "Dados incorretos, não foi possivel identificar o usuário";
        public string TRANSACOES_VAZIAS = "Trazações não encontradas";
        public string SALDO_INSUFICIENTE = "saldo insuficiente";
        public string OPERACAO_SUCESSO = "Operação realizada com sucesso";
        public string OPERACAO_ERRO = "Erro ao realizar operacao";
        public string SAQUE = "saque";
        public string DEPOSITO = "deposito";
        public string TRANSFERENCIA = "transferencia";
        public string PAGAMENTO = "pagamento";
        public string NAO_LOGADO = "Não logado";

    }
}