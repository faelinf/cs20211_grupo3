using Banco.Models;
using Npgsql;
using System;
using System.Collections.Generic;


namespace Banco.Controllers
{
    public class BancoDB
    {
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from tbusuario";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = (int)dataReader["id"];
                    string nome = dataReader["nome"].ToString();
                    string conta = dataReader["conta"].ToString();
                    string agencia = dataReader["agencia"].ToString();
                    double saldo = (double)dataReader["saldo"];
                    string cpf = dataReader["cpf"].ToString();
                    string senha = dataReader["senha"].ToString();
                    string banco = dataReader["banco"].ToString();

                    Usuario usuario = new Usuario()
                    {
                        Id = id,
                        Nome = nome,
                        Conta = conta,
                        Agencia = agencia,
                        Saldo = saldo,
                        CPF = cpf,
                        Senha = senha,
                        Banco = banco
                    };

                    lista.Add(usuario);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro de SQL: " + e.Message);
            }

            return lista;
        }

        public static List<Login> GetLogin()
        {
            List<Login> lista = new List<Login>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from tblogin";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = (int)dataReader["id"];
                    int usuarioId = (int)dataReader["usuario_id"];
                    DateTime data = (DateTime)dataReader["data"];

                    Login login = new Login()
                    {
                        Id = id,
                        UsuarioId = usuarioId,
                        Data = data,
                    };

                    lista.Add(login);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro de SQL: " + e.Message);
            }

            return lista;
        }

        public static List<Cartoes> GetCartoes()
        {
            List<Cartoes> lista = new List<Cartoes>();

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from tbcartoes";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    int id = (int)dataReader["id"];
                    int usuarioId = (int)dataReader["usuario_id"];
                    string tipo = dataReader["tipo"].ToString();
                    string numero = dataReader["numero"].ToString();
                    string nome = dataReader["nome"].ToString();
                    string validade = dataReader["validade"].ToString();
                    string cVV = dataReader["cvv"].ToString();
                    double limite =  (double)dataReader["limite"];
                    string senha =  dataReader["senha"].ToString();

                    Cartoes cartao = new Cartoes()
                    {
                        Id = id,
                        Nome = nome,
                        UsuarioId = usuarioId,
                        Numero = numero,
                        Limite = limite,
                        CVV = cVV,
                        Senha = senha,
                        Tipo = tipo,
                        Validade = validade
                    };

                    lista.Add(cartao);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro de SQL: " + e.Message);
            }

            return lista;
        }

        public static bool AdicionaUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into tbusuario (id, nome, agencia, conta, saldo) values(@id, @nome, @agencia, @conta, @saldo)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuario.Id;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usuario.Nome;
                cmd.Parameters.Add("@agencia", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usuario.Agencia;
                cmd.Parameters.Add("@conta", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usuario.Conta;
                cmd.Parameters.Add("@saldo", NpgsqlTypes.NpgsqlDbType.Double).Value = usuario.Saldo;
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usuario.CPF;
                cmd.Parameters.Add("@senha", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usuario.Senha;
                cmd.Parameters.Add("@banco", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usuario.Banco;
                int valor = cmd.ExecuteNonQuery();
                if(valor > 0)
                {
                    resultado = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao criar usuário: " + e.Message);
            }
            return resultado;
        }

         public static bool AlteraSaldo(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update tbusuario set saldo = @saldo where id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuario.Id;
                cmd.Parameters.Add("@saldo", NpgsqlTypes.NpgsqlDbType.Double).Value = usuario.Saldo;
                int valor = cmd.ExecuteNonQuery();
                if(valor > 0)
                {
                    resultado = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao alterar saldo: " + e.Message);
            }
            return resultado;
        }

         public static bool addTransferencia(Usuario usuario, Usuario usuarioDestino, double valorTransacao, String tipo)
        {
            bool resultado = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sqlTransacao = "INSERT INTO public.tbtransacoes (usuario_id, tipo, destinatario_id, valor) VALUES (@usuario, @tipo, @destinatario, @valor);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlTransacao, conexao);

                cmd.Parameters.Add("@usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuario.Id;
                cmd.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = tipo;
                cmd.Parameters.Add("@destinatario", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuarioDestino.Id;
                cmd.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Double).Value = valorTransacao;
                int resultadoTransacao = cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand(sqlTransacao, conexao);
                cmd.Parameters.Add("@usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuarioDestino.Id;
                cmd.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = "recebimento";
                cmd.Parameters.Add("@destinatario", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuario.Id;
                cmd.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Double).Value = valorTransacao;
                int resultadoSegundaTransacao = cmd.ExecuteNonQuery();

                if(resultadoTransacao > 0 && resultadoSegundaTransacao > 0)
                {
                    resultado = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao criar transações: " + e.Message);
            }
            return resultado;
        }

        public static bool addLogin(int usuarioId, DateTime data)
        {
            bool resultado = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sqlTransacao = "INSERT INTO public.tblogin (usuario_id, data) VALUES (@usuario, @data);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlTransacao, conexao);

                cmd.Parameters.Add("@usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuarioId;
                cmd.Parameters.Add("@data", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = data;
                int resultadoTransacao = cmd.ExecuteNonQuery();

                if(resultadoTransacao > 0)
                {
                    resultado = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao criar transações: " + e.Message);
            }
            return resultado;
        }

        public static List<Transacao> GetTransacao()
        {
            List<Transacao> lista = new List<Transacao>();

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from tbtransacoes";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = (int)dataReader["id"];
                    int usuarioId = (int)dataReader["usuario_id"];
                    string tipo = dataReader["tipo"].ToString();
                    int destinatarioId = (int)dataReader["destinatario_id"];
                    double valor = (double)dataReader["valor"];

                    Transacao transacao = new Transacao()
                    {
                        Id = id,
                        UsuarioId = usuarioId,
                        Tipo = tipo,
                        DestinatarioId = destinatarioId,
                        Valor = valor
                    };

                    lista.Add(transacao);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro de SQL: " + e.Message);
            }

            return lista;
        }


        public static List<Transacao> GetTransacaoDeUsuario(int usuarioId)
        {
            List<Transacao> lista = new List<Transacao>();

            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from tbtransacoes where usuario_id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = usuarioId;
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = (int)dataReader["id"];
                    string tipo = dataReader["tipo"].ToString();
                    int destinatarioId = (int)dataReader["destinatario_id"];
                    double valor = (double)dataReader["valor"];

                    Transacao transacao = new Transacao()
                    {
                        Id = id,
                        UsuarioId = usuarioId,
                        Tipo = tipo,
                        DestinatarioId = destinatarioId,
                        Valor = valor
                    };

                    lista.Add(transacao);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro de SQL: " + e.Message);
            }

            return lista;
        }
    }
}
