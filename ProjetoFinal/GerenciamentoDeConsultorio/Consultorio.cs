using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

