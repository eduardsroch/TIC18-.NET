using System;

namespace GerenciamentoDeConsultorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Consultorio consultorio = new Consultorio();

            try
            {
                
                consultorio.AdicionarMedico(new Medico("Dr. Carlos", new DateTime(1980, 5, 15), "12345678901", "CRM1234"));
                consultorio.AdicionarMedico(new Medico("Dra. Ana", new DateTime(1975, 10, 25), "23456789012", "CRM5678"));
                consultorio.AdicionarMedico(new Medico("Dr. José", new DateTime(1990, 8, 8), "34567890123", "CRM9101"));
                consultorio.AdicionarMedico(new Medico("Dr. Sofia", new DateTime(1988, 4, 12), "45678901234", "CRM2345"));
                consultorio.AdicionarMedico(new Medico("Dra. Carolina", new DateTime(1972, 6, 20), "56789012345", "CRM6789"));

                consultorio.AdicionarPaciente(new Paciente("João", new DateTime(2000, 3, 5), "67890123456", "Masculino", "Febre"));
                consultorio.AdicionarPaciente(new Paciente("Maria", new DateTime(1995, 7, 10), "78901234567", "Feminino", "Dor de cabeça"));
                consultorio.AdicionarPaciente(new Paciente("Pedro", new DateTime(1988, 12, 20), "89012345678", "Masculino", "Dor nas costas"));
                consultorio.AdicionarPaciente(new Paciente("Ana", new DateTime(2005, 9, 18), "90123456789", "Feminino", "Resfriado"));
                consultorio.AdicionarPaciente(new Paciente("Paulo", new DateTime(1978, 1, 30), "01234567890", "Masculino", "Gripe"));
                
                var medicosIdade = Relatorios.MedicosIdadeEntre(consultorio.Medicos, 30, 50);
                Console.WriteLine("Médicos com idade entre 30 e 50 anos:");
                foreach (var medico in medicosIdade)
                {
                    Console.WriteLine($"Nome: {medico.Nome}, Idade: {DateTime.Now.Year - medico.DataNascimento.Year} anos");
                }
                var pacientesIdade = Relatorios.PacientesIdadeEntre(consultorio.Pacientes, 20, 40);
                Console.WriteLine("\nPacientes com idade entre 20 e 40 anos:");
                foreach (var paciente in pacientesIdade)
                {
                    Console.WriteLine($"Nome: {paciente.Nome}, Idade: {DateTime.Now.Year - paciente.DataNascimento.Year} anos");
                }

                var pacientesSexo = Relatorios.PacientesPorSexo(consultorio.Pacientes, "Feminino");
                Console.WriteLine("\nPacientes do sexo feminino:");
                foreach (var paciente in pacientesSexo)
                {
                    Console.WriteLine($"Nome: {paciente.Nome}, Sexo: {paciente.Sexo}");
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao adicionar: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}