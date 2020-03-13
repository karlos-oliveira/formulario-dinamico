using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Atributo
    {
        public bool IsAtivo { get; set; }
        public Guid IdAtributo { get; set; }
        public Guid IdConta { get; set; }
        public string Label { get; set; }
        public string Descricao { get; set; }
        public Guid IdTipoAtributo { get; set; }
        //public TipoAtributo TipoAtributo { get; set; }
        public int TamanhoMaximo { get; set; }
        public string NomeCampo { get; set; }

    }
}
