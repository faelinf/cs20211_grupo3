using Npgsql;
using System;

namespace Banco.Models
{
    public class Conexao
    {
        public static NpgsqlConnection GetConexao()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; password=Schloegl@20; Database=db_banco");
                conexao.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro de conexão: " + e.Message);
            }

            return conexao;
        }

        public static void SetFechaConexao(NpgsqlConnection conexao)
        {
            if(conexao != null)
            {
                try
                {
                    conexao.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Erro ao fechar conexão: " + e.Message);
                }
            }
        }
    }
}
