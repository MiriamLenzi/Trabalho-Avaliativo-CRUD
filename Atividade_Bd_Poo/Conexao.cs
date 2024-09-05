using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace cadastro_servico
{
    public static class Conexao
    {
        static MySqlConnection conexao;
        public static MySqlConnection Conectar()
        {
            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database= simulado";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();



            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao relizar a conexão com a base de dados!" + ex.Message);
            }
            return conexao;



        }


    }
}
