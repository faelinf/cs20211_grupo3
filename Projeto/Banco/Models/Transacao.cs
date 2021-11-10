namespace Banco.Models
{
    public class Transacao
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Tipo { get; set; }

        public int DestinatarioId { get; set; }

        public double Valor { get; set; }

        public override  string ToString() {
            return "Código: " + Id +", Tipo: " + Tipo + ", Valor: " + Valor;
        }
    }
}