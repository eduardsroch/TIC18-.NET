using System.Collections.Generic;
using System.Linq;

class TaskManager
{
    struct Task
    {
        public string Title;
        public string Description;
        public DateTime DueDate;
        public bool Completed;
    }

    private List<Task> tasks = new List<Task>();

    public void CreateTask()
    {
        Console.WriteLine("Criar uma nova tarefa:");

        Console.Write("Título da tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Descrição da tarefa: ");
        string description = Console.ReadLine();

        Console.Write("Data de vencimento (DD/MM/AAAA): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            tasks.Add(new Task
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Completed = false
            });
            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. Tarefa não criada.");
        }
    }

    public void ListAllTasks()
    {
        Console.WriteLine("Lista de todas as tarefas:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"Título: {task.Title} | Descrição: {task.Description} | Vencimento: {task.DueDate.ToShortDateString()} | Concluída: {(task.Completed ? "Sim" : "Não")}");
        }
    }

    public void MarkTaskAsCompleted()
    {
        Console.WriteLine("Digite o título da tarefa que deseja marcar como concluída:");
        string title = Console.ReadLine();

        var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (task.Title != null)
        {
            task.Completed = true;
            Console.WriteLine("Tarefa marcada como concluída.");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    public void ListPendingTasks()
    {
        var pendingTasks = tasks.Where(t => !t.Completed).ToList();

        Console.WriteLine("Lista de tarefas pendentes:");
        foreach (var task in pendingTasks)
        {
            Console.WriteLine($"Título: {task.Title} | Descrição: {task.Description} | Vencimento: {task.DueDate.ToShortDateString()}");
        }
    }

    public void ListCompletedTasks()
    {
        var completedTasks = tasks.Where(t => t.Completed).ToList();

        Console.WriteLine("Lista de tarefas concluídas:");
        foreach (var task in completedTasks)
        {
            Console.WriteLine($"Título: {task.Title} | Descrição: {task.Description} | Vencimento: {task.DueDate.ToShortDateString()}");
        }
    }

    public void DeleteTask()
    {
        Console.WriteLine("Digite o título da tarefa que deseja excluir:");
        string title = Console.ReadLine();

        var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (task.Title != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Tarefa excluída.");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    public void SearchTasksByKeyword()
    {
        Console.WriteLine("Digite uma palavra-chave para pesquisar tarefas:");
        string keyword = Console.ReadLine();

        var foundTasks = tasks.Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine($"Tarefas encontradas com a palavra-chave '{keyword}':");
        foreach (var task in foundTasks)
        {
            Console.WriteLine($"Título: {task.Title} | Descrição: {task.Description} | Vencimento: {task.DueDate.ToShortDateString()} | Concluída: {(task.Completed ? "Sim" : "Não")}");
        }
    }

    public void ShowStatistics()
    {
        int completedTasksCount = tasks.Count(t => t.Completed);
        int pendingTasksCount = tasks.Count(t => !t.Completed);

        var oldestTask = tasks.OrderBy(t => t.DueDate).FirstOrDefault();
        var newestTask = tasks.OrderByDescending(t => t.DueDate).FirstOrDefault();

        Console.WriteLine($"Número de tarefas concluídas: {completedTasksCount}");
        Console.WriteLine($"Número de tarefas pendentes: {pendingTasksCount}");

        if (oldestTask.Title != null)
        {
            Console.WriteLine($"Tarefa mais antiga: {oldestTask.Title} (Vencimento: {oldestTask.DueDate.ToShortDateString()})");
        }
        else
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
        }

        if (newestTask.Title != null)
        {
            Console.WriteLine($"Tarefa mais recente: {newestTask.Title} (Vencimento: {newestTask.DueDate.ToShortDateString()})");
        }
        else
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n Gerenciador de Tarefas - TIC18");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar todas as tarefas");
            Console.WriteLine("3. Marcar uma tarefa como concluída");
            Console.WriteLine("4. Listar tarefas pendentes");
            Console.WriteLine("5. Listar tarefas concluídas");
            Console.WriteLine("6. Excluir tarefa");
            Console.WriteLine("7. Pesquisar tarefas por palavra-chave");
            Console.WriteLine("8. Mostrar estatísticas");
            Console.WriteLine("9. Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        taskManager.CreateTask();
                        break;
                    case 2:
                        taskManager.ListAllTasks();
                        break;
                    case 3:
                        taskManager.MarkTaskAsCompleted();
                        break;
                    case 4:
                        taskManager.ListPendingTasks();
                        break;
                    case 5:
                        taskManager.ListCompletedTasks();
                        break;
                    case 6:
                        taskManager.DeleteTask();
                        break;
                    case 7:
                        taskManager.SearchTasksByKeyword();
                        break;
                    case 8:
                        taskManager.ShowStatistics();
                        break;
                    case 9:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        Console.WriteLine("Programa encerrado.");
    }
}
