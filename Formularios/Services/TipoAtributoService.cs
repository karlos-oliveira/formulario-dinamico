
using Infra.Data.Repository;
using Models;
using System;
using System.Collections.Generic;
namespace Services
{
    public interface ITipoAtributoService
    {
        void CriarTipoAtributo(TipoAtributo inputs);
        void CriarTipoAtributoLote(List<TipoAtributo> inputs);
        TipoAtributo ConsultarTipoAtributo(Guid IdTipoAtributo);
        List<TipoAtributo> ConsultarTipoAtributos();
        void EditarTipoAtributo(TipoAtributo inputs);
        void DeletarTipoAtributo(Guid IdTipoAtributo);
    }

    public class TipoAtributoService : ITipoAtributoService
    {
        private readonly ITipoAtributoRepository _repo;
        public TipoAtributoService(ITipoAtributoRepository repo)
        {
            _repo = repo;
        }

        public TipoAtributo ConsultarTipoAtributo(Guid IdTipoAtributo)
        {
            return _repo.ConsultarTipoAtributo(IdTipoAtributo);
        }

        public List<TipoAtributo> ConsultarTipoAtributos()
        {
            return _repo.ConsultarTipoAtributos();
        }

        public void CriarTipoAtributo(TipoAtributo inputs)
        {
            _repo.CriarTipoAtributo(inputs);
        }

        public void CriarTipoAtributoLote(List<TipoAtributo> inputs)
        {
            inputs.ForEach(tpa => tpa.IdTipoAtributo = Guid.NewGuid());

            _repo.CriarTipoAtributoLote(inputs);
        }

        public void DeletarTipoAtributo(Guid IdTipoAtributo)
        {
            _repo.DeletarTipoAtributo(IdTipoAtributo);
        }

        public void EditarTipoAtributo(TipoAtributo inputs)
        {
            _repo.EditarTipoAtributo(inputs);
        }
    }
}
