using System;

class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno()
    {
        Nome = "Eduardo";
        Idade = 29;
    }
}

class Program
{
    static void Main()
    {
        Aluno aluno = new Aluno();

        Console.WriteLine($"Nome do aluno: {aluno.Nome}");
        Console.WriteLine($"Idade do aluno: {aluno.Idade}");
    }
}
