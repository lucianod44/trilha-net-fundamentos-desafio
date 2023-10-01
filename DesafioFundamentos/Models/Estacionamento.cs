using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            string pattern = @"^[A-Za-z]{3}-\d[A-Za-z]\d{2}$";
            string patternFormatoAntigo = @"^[A-Za-z]{3}-\d{4}$";

            
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine();

                if (Regex.IsMatch(placa, pattern) || Regex.IsMatch (placa, patternFormatoAntigo))
                //funçao para usuario colocar o formato da placa valido (placa antiga ou mercosul).
                {
                    Console.WriteLine("Placa Válida");
                    veiculos.Add(placa);
                    Console.WriteLine($"O veículo com placa {placa} foi estacionado.");
                    break; // Sai do loop após adicionar a placa válida.
                }
                else
                {
                    Console.WriteLine("Placa inválida. Digite o formato da placa correto(EX: LLL-0000 OU LLL-0F00).");
                }
            }
        }

        public void RemoverVeiculo()
{
    Console.WriteLine("Digite a placa do veículo para remover:");
    string placa = Console.ReadLine();

    placa = placa.ToUpper();
 

    if (veiculos.Any(x => string.Equals(x, placa, StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        int horas = Convert.ToInt32(Console.ReadLine());
        decimal valorTotal;

        if (horas > 3)
        {
            decimal desconto = 0.10m; // 10% de desconto
            decimal valorSemDesconto = precoInicial + (precoPorHora * horas);
            decimal valorComDesconto = valorSemDesconto - (valorSemDesconto * desconto);
            valorTotal = valorComDesconto;
        }
        else
        {
            valorTotal = precoInicial + (precoPorHora * horas);
        }

        veiculos.Remove(placa);

        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
    }
    else
    {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
    }
}


        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
