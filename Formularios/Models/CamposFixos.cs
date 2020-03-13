using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CamposFixos
    {
        public CamposFixos()
        {

        }

        public CamposFixos(dynamic obj)
        {
            try
            {
                this.Id = Guid.Parse(obj.id);
                this.Sistema = obj.sistema;
                this.CriarSeNaoExistir = obj.criarSeNaoExistir;
            }
            catch (Exception){ }
        }

        public Guid Id { get; set; }
        public string Sistema { get; set; }
        public bool CriarSeNaoExistir { get; set; }
    }
}
