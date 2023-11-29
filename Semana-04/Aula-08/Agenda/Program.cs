using System;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
}

class Agenda
{
    private Contato[] contatos;

    public Agenda(int tamanho)
    {
        contatos = new Contato[tamanho];
    }

    public Contato this[int index]
    {
        get { return contatos[index]; }
        set { contatos[index] = value; }
    }
}

class Program
{
    static void Main()
    {
        Agenda minhaAgenda = new Agenda(5);

        minhaAgenda[0] = new Contato { Nome = "Eduardo", Telefone = "(11) 1234-5678" };
        minhaAgenda[1] = new Contato { Nome = "Luis", Telefone = "(21) 9876-5432" };
        minhaAgenda[2] = new Contato { Nome = "Lord", Telefone = "(31) 5555-7777" };

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Contato {i + 1}:");
            Console.WriteLine($"Nome: {minhaAgenda[i].Nome}");
            Console.WriteLine($"Telefone: {minhaAgenda[i].Telefone}");
            Console.WriteLine();
        }
    }
}
