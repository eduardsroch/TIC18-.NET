using System;

class ContaBancaria
{
    private decimal _saldo;

    public decimal Saldo
    {
        get { return _saldo; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Saldo não pode ser negativo");
            }
            else
            {
                _saldo = value;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria conta = new ContaBancaria();

        try
        {
            conta.Saldo = 1000;
            Console.WriteLine($"Saldo atual: {conta.Saldo}");
            
            conta.Saldo = -500;
            Console.WriteLine($"Saldo atual: {conta.Saldo}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Erro: {e.Message}");
        }
    }
}
