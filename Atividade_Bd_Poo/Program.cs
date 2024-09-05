using System;
using cadastro_servico;

namespace cadastro_servico
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoDAO servicoDAO = new ServicoDAO();
       
             while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Cadastrar serviço");
                Console.WriteLine("2. Listar serviços");
                Console.WriteLine("3. Excluir serviço");
                Console.WriteLine("4. Alterar serviço");
                Console.WriteLine("5. Sair");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Servico servico = new Servico();
                    servico.CapturarDados();
                    servicoDAO.InserirServico(servico);
                }
                else if (opcao == "2")
                {
                    servicoDAO.ListarServicos();
                }
                else if (opcao == "3")
                {
                    Console.WriteLine("Digite o ID do serviço que deseja excluir:");
                    int idServico = Convert.ToInt32(Console.ReadLine());
                    servicoDAO.ExcluirServico(idServico);
                }
                else if (opcao == "4")
                {
                    Console.WriteLine("Digite o ID do serviço que deseja alterar:");
                    int idServico = Convert.ToInt32(Console.ReadLine());

                    // Capturar os novos dados do serviço
                    Servico servico = new Servico
                    {
                        IdServico = idServico
                    };
                    Console.WriteLine("Digite a nova descrição do serviço:");
                    servico.Descricao = Console.ReadLine();

                    Console.WriteLine("Digite o novo valor do serviço:");
                    servico.ValorServico = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Digite o novo tempo do serviço (em minutos):");
                    servico.Tempo = Convert.ToInt32(Console.ReadLine());

                    servicoDAO.AlterarServico(servico);

                }

                else if (opcao == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                }
             }
        }
    }
}
