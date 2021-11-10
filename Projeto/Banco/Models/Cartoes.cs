namespace Banco.Models
{
    public class Cartoes
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Tipo { get; set; }

        public string Numero { get; set; }

        public string Nome { get; set; }

        public string Validade { get; set; }

        public string CVV { get; set; }

        public double Limite { get; set; }

        public string Senha { get; set; }
    }
}