using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ModeloCompleto
    {
        public Guid IdModelo { get; set; }
        public Guid IdAtributo { get; set; }
        public Guid IdTipo { get; set; }
        public string Modelo { get; set; }
        public string Label { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int Ordem { get; set; }
        public int TamanhoMaximo { get; set; }
        public long Versao { get; set; }
        public bool Obrigatorio { get; set; }
        public bool MultiplaEscolha { get; set; }
        public string Opcoes { get; set; }
        public string NomeCampo { get; set; }

    }
}
