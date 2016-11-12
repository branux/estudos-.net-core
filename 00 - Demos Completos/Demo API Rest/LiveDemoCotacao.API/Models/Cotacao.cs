using System;

namespace LiveDemoCotacao.API.Models
{
    public class Cotacao
    {
        public string Sigla { get; set; }
        public string NomeMoeda { get; set; }
        public DateTime UltimaCotacao { get; set; }
        public decimal Valor { get; set; }
    }
}
