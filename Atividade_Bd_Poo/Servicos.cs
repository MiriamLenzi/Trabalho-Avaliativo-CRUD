using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_servico
{
    public class Servico
    {
        public int IdServico { get; set; }
        public decimal ValorServico { get; set; }
        public string Descricao { get; set; }
        public int Tempo { get; set; } 

        public void CapturarDados()
        {
            Console.WriteLine("Digite a descrição do serviço:");
            Descricao = Console.ReadLine();

            Console.WriteLine("Digite o valor do serviço:");
            ValorServico = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o tempo do serviço (em minutos):");
            Tempo = Convert.ToInt32(Console.ReadLine());
        }

        public void ExibirDados()
        {
            Console.WriteLine($"ID: {IdServico}, Descrição: {Descricao}, Valor: {ValorServico}, Tempo: {Tempo} minutos");
        }
    }
}
