using System;

namespace veiculo
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }

        public int IdadeVeiculo
        {
            get
            {
                int anoAtual = DateTime.Now.Year;
                return anoAtual - Ano;
            }
        }
    }
}
