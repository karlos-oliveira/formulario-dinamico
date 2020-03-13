using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ModeloAtributo
    {
        public Guid IdModeloAtributo { get; set; }
        public Guid IdModelo { get; set; }
        public Guid IdAtributo { get; set; }
        public int Ordem { get; set; }
        public DateTime DataAlteracao { get; set; }
        public long Versao { get; set; }
        public bool Obrigatorio { get; set; }
        public bool MultiplaEscolha { get; set; }
        public string Opcoes { get; set; }

    }
}
