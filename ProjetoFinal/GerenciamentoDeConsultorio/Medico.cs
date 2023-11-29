using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeConsultorio
{
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
} 

