using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AtributoCompleto
    {
        public Guid IdAtributo { get; set; }
        public string Label { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int TamanhoMaximo { get; set; }
        public string NomeCampo { get; set; }
        public bool IsAtivo     { get; set; }
    }
}
