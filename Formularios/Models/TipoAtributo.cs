using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class TipoAtributo
    {
        public Guid IdTipoAtributo { get; set; }
        //public Guid IdConta { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
