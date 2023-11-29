using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoDeConsultorio
{
    public class Consultorio
    {
        public List<Medico> Medicos { get; private set; }
        public List<Paciente> Pacientes { get; private set; }

        public Consultorio()
        {
            Medicos = new List<Medico>();
            Pacientes = new List<Paciente>();
        }

        public void AdicionarMedico(Medico medico)
        {
            if (Medicos.Any(m => m.CPF == medico.CPF || m.CRM == medico.CRM))
            {
                throw new ArgumentException("CPF ou CRM já cadastrado para outro médico.");
            }
            Medicos.Add(medico);
        }

        public void AdicionarPaciente(Paciente paciente)
        {
            if (Pacientes.Any(p => p.CPF == paciente.CPF))
            {
                throw new ArgumentException("CPF já cadastrado para outro paciente.");
            }
            Pacientes.Add(paciente);
        }
    }

    public class Medico
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cpf;
            CRM = crm;
        }
    }

    public class Paciente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Sintomas { get; set; }

        public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cpf;
            Sexo = sexo;
            Sintomas = sintomas;
        }
    }

    public class Relatorios
    {
        public static IEnumerable<Medico> MedicosIdadeEntre(List<Medico> medicos, int idadeMin, int idadeMax)
        {
            return medicos.Where(medico => (DateTime.Now.Year - medico.DataNascimento.Year) >= idadeMin &&
                                           (DateTime.Now.Year - medico.DataNascimento.Year) <= idadeMax);
        }

        public static IEnumerable<Paciente> PacientesIdadeEntre(List<Paciente> pacientes, int idadeMin, int idadeMax)
        {
            return pacientes.Where(paciente => (DateTime.Now.Year - paciente.DataNascimento.Year) >= idadeMin &&
                                               (DateTime.Now.Year - paciente.DataNascimento.Year) <= idadeMax);
        }

        public static IEnumerable<Paciente> PacientesPorSexo(List<Paciente> pacientes, string sexo)
        {
            return pacientes.Where(paciente => paciente.Sexo.ToLower() == sexo.ToLower());
        }

        public static IEnumerable<Paciente> PacientesOrdemAlfabetica(List<Paciente> pacientes)
        {
            return pacientes.OrderBy(paciente => paciente.Nome);
        }

        public static IEnumerable<Paciente> PacientesPorSintomas(List<Paciente> pacientes, string textoSintomas)
        {
            return pacientes.Where(paciente => paciente.Sintomas.Contains(textoSintomas));
        }

        public static IEnumerable<object> AniversariantesDoMes(List<Medico> medicos, List<Paciente> pacientes, int mes)
        {
            var aniversariantes = new List<object>();

            aniversariantes.AddRange(medicos.Where(medico => MesAniversario(medico.DataNascimento) == mes)
                                           .Select(medico => new { Tipo = "Médico", Nome = medico.Nome }));

            aniversariantes.AddRange(pacientes.Where(paciente => MesAniversario(paciente.DataNascimento) == mes)
                                               .Select(paciente => new { Tipo = "Paciente", Nome = paciente.Nome }));

            return aniversariantes;
        }

        private static int MesAniversario(DateTime data)
        {
            return data.Month;
        }
    }

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
