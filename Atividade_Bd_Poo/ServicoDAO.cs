using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using cadastro_servico;
using MySql.Data.MySqlClient;

namespace cadastro_servico
{
    internal class ServicoDAO
    {
        private MySqlConnection Conectar()
        {
            string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=cadastro_servico";
            MySqlConnection conexao = new MySqlConnection(strconexao);
            conexao.Open();
            return conexao;
        }


        public void InserirServico(Servico servico)
        {
            string sql = "INSERT INTO servicos (VALOR_SERVICO, DESCRICAO, TEMPO) VALUES (@valorServico, @descricao, @tempo)";
            using (MySqlCommand comando = new MySqlCommand(sql, Conectar()))
            {
                comando.Parameters.AddWithValue("@valorServico", servico.ValorServico);
                comando.Parameters.AddWithValue("@descricao", servico.Descricao);
                comando.Parameters.AddWithValue("@tempo", servico.Tempo);
                comando.ExecuteNonQuery();
            }
            Console.WriteLine("Serviço cadastrado com sucesso!");
        }

        public void ListarServicos()
        {
            string sql = "SELECT * FROM servicos";
            using (MySqlCommand comando = new MySqlCommand(sql, Conectar()))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Servico servico = new Servico
                        {
                            IdServico = reader.GetInt32("ID_SERVICO"),
                            Descricao = reader.GetString("DESCRICAO"),
                            ValorServico = reader.GetDecimal("VALOR_SERVICO"),
                            Tempo = reader.GetInt32("TEMPO")
                        };
                        servico.ExibirDados();
                    }
                }
            }
        }

        public void AlterarServico(Servico servico)
        {
            string sql = "UPDATE servicos SET VALOR_SERVICO = @valorServico, DESCRICAO = @descricao, TEMPO = @tempo WHERE ID_SERVICO = @idServico";
            using (MySqlCommand comando = new MySqlCommand(sql, Conectar()))
            {
                comando.Parameters.AddWithValue("@valorServico", servico.ValorServico);
                comando.Parameters.AddWithValue("@descricao", servico.Descricao);
                comando.Parameters.AddWithValue("@tempo", servico.Tempo);
                comando.Parameters.AddWithValue("@idServico", servico.IdServico);
                comando.ExecuteNonQuery();
            }
            Console.WriteLine("Serviço atualizado com sucesso!");
        }


        public void ExcluirServico(int idServico)
        {
            string sql = "DELETE FROM servicos WHERE ID_SERVICO = @idServico";
            using (MySqlCommand comando = new MySqlCommand(sql, Conectar()))
            {
                comando.Parameters.AddWithValue("@idServico", idServico);
                comando.ExecuteNonQuery();
            }
            Console.WriteLine("Serviço excluído com sucesso!");
        }
    }
}
