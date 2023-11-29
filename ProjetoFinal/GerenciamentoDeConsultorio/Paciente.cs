using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeConsultorio

{
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
}