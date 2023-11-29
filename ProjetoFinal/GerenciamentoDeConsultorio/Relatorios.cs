using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeConsultorio

{
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
}
