using System;

namespace veiculo
{
    class Program
    {
        static void Main()
        {
            Veiculo meuOpala = new Veiculo();
            meuOpala.Modelo = "Chevrolet Opala";
            meuOpala.Ano = 1975;
            meuOpala.Cor = "Branco";

            Console.WriteLine("Informações do Veículo:");
            Console.WriteLine($"Modelo: {meuOpala.Modelo}");
            Console.WriteLine($"Ano: {meuOpala.Ano}");
            Console.WriteLine($"Cor: {meuOpala.Cor}");
            Console.WriteLine($"Idade do Veículo: {meuOpala.IdadeVeiculo} anos");
        }
    }
}
