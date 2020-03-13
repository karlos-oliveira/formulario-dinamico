using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inputs
{
    public class AtributoInput
    {
        public Guid IdAtributo { get; set; }
        public int Ordem { get; set; }
        public bool Obrigatorio { get; set; }
        public bool MultiplaEscolha { get; set; }
        public string[] Opcoes { get; set; }
    }
}
