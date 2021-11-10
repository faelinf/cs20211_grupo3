namespace Banco.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Conta { get; set; }

        public string Agencia { get; set; }

        public double Saldo { get; set; }

        public string CPF { get; set; } 

        public string Banco { get; set; } 

        public string Senha { get; set; }
    }
}