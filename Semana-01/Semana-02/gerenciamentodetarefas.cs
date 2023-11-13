
using System;
using System.Collections.Generic;

class Task {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool Completed { get; set; }
}

class TaskManager {
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Criar nova tarefa");
            Console.WriteLine("2 - Listar todas as tarefas");
            Console.WriteLine("3 - Marcar tarefa como concluída");
            Console.WriteLine("4 - Exibir lista de tarefas pendentes");
            Console.WriteLine("5 - Exibir lista de tarefas concluídas");
            Console.WriteLine("6 - Excluir tarefa");
            Console.WriteLine("7 - Pesquisar tarefas");
            Console.WriteLine("8 - Exibir estatísticas");
            Console.WriteLine("0 - Sair");

            int option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ListTasks();
                    break;
                case 3:
                    CompleteTask();
                    break;
                case 4:
                    ListPendingTasks();
                    break;
                case 5:
                    ListCompletedTasks();
                    break;
                case 6:
                    DeleteTask();
                    break;
                case 7:
                    SearchTasks();
                    break;
                case 8:
                    ShowStatistics();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void CreateTask() {
        Console.WriteLine("Digite o título da tarefa:");
        string title = Console.ReadLine();

        Console.WriteLine("Digite a descrição da tarefa:");
        string description = Console.ReadLine();

        Console.WriteLine("Digite a data de vencimento da tarefa (dd/mm/aaaa):");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());

        Task task = new Task();
        task.Title = title;
        task.Description = description;
        task.DueDate = dueDate;
        task.Completed = false;

        tasks.Add(task);

        Console.WriteLine("Tarefa criada com sucesso!");
    }

    static void ListTasks() {
        Console.WriteLine("Lista de tarefas:");

        for (int i = 0; i < tasks.Count; i++) {
            Console.WriteLine("{0} - {1} ({2})", i, tasks[i].Title, tasks[i].DueDate.ToString("dd/MM/yyyy"));
        }
    }

    static void CompleteTask() {
        Console.WriteLine("Digite o índice da tarefa concluída:");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < tasks.Count) {
            tasks[index].Completed = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        } else {
            Console.WriteLine("Índice inválido!");
        }
    }

    static void ListPendingTasks() {
        Console.WriteLine("Lista de tarefas pendentes:");

        for (int i = 0; i < tasks.Count; i++) {
            if (!tasks[i].Completed) {
                Console.WriteLine("{0} - {1} ({2})", i, tasks[i].Title, tasks[i].DueDate.ToString("dd/MM/yyyy"));
            }
        }
    }

    static void ListCompletedTasks() {
        Console.WriteLine("Lista de tarefas concluídas:");

        for (int i = 0; i < tasks.Count; i++) {
            if (tasks[i].Completed) {
                Console.WriteLine("{0} - {1} ({2})", i, tasks[i].Title, tasks[i].DueDate.ToString("dd/MM/yyyy"));
            }
        }
    }

    static void DeleteTask() {
        Console.WriteLine("Digite o índice da tarefa a ser excluída:");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < tasks.Count) {
            tasks.RemoveAt(index);
            Console.WriteLine("Tarefa excluída com sucesso!");
        } else {
            Console.WriteLine("Índice inválido!");
        }
    }

    static void SearchTasks() {
        Console.WriteLine("Digite a palavra-chave:");
        string keyword = Console.ReadLine();

        Console.WriteLine("Resultado da pesquisa:");

        for (int i = 0; i < tasks.Count; i++) {
            if (tasks[i].Title.Contains(keyword) || tasks[i].Description.Contains(keyword)) {
                Console.WriteLine("{0} - {1} ({2})", i, tasks[i].Title, tasks[i].DueDate.ToString("dd/MM/yyyy"));
            }
        }
    }

    static void ShowStatistics() {
        int pendingTasks = 0;
        int completedTasks = 0;
        DateTime oldestTask = DateTime.MaxValue;
        DateTime newestTask = DateTime.MinValue;

        for (int i = 0; i < tasks.Count; i++) {
            if (tasks[i].Completed) {
                completedTasks++;
            } else {
                pendingTasks++;
            }

            if (tasks[i].DueDate < oldestTask) {
                oldestTask = tasks[i].DueDate;
            }

            if (tasks[i].DueDate > newestTask) {
                newestTask = tasks[i].DueDate;
            }
        }

        Console.WriteLine("Estatísticas:");
        Console.WriteLine("Tarefas pendentes: {0}", pendingTasks);
        Console.WriteLine("Tarefas concluídas: {0}", completedTasks);
        Console.WriteLine("Tarefa mais antiga: {0}", oldestTask.ToString("dd/MM/yyyy"));
        Console.WriteLine("Tarefa mais recente: {0}", newestTask.ToString("dd/MM/yyyy"));
    }
}
