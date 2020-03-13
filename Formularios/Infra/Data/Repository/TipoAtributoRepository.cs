
using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infra.Data.Repository
{
    public interface ITipoAtributoRepository
    {
        void CriarTipoAtributo(TipoAtributo inputs);
        void CriarTipoAtributoLote(List<TipoAtributo> inputs);
        TipoAtributo ConsultarTipoAtributo(Guid IdTipoAtributo);
        List<TipoAtributo> ConsultarTipoAtributos();
        void EditarTipoAtributo(TipoAtributo inputs);
        void DeletarTipoAtributo(Guid IdTipoAtributo);
    }

    public class TipoAtributoRepository : ITipoAtributoRepository
    {
        private readonly IContext _context;

        public TipoAtributoRepository(IContext context)
        {
            _context = context;
        }

        public TipoAtributo ConsultarTipoAtributo(Guid IdTipoAtributo)
        {
            return _context.TipoAtributo.Where(x => x.IdTipoAtributo == IdTipoAtributo).First();
        }

        public List<TipoAtributo> ConsultarTipoAtributos()
        {
            return _context.TipoAtributo.Where(x => x.IsAtivo).ToList();
            //return _context.TipoAtributo.ToList();
        }

        public void CriarTipoAtributo(TipoAtributo inputs)
        {
            _context.TipoAtributo.Add(inputs);
            _context.Commit();
        }

        public void CriarTipoAtributoLote(List<TipoAtributo> inputs)
        {
            _context.TipoAtributo.AddRange(inputs);
            _context.Commit();
        }

        public void DeletarTipoAtributo(Guid IdTipoAtributo)
        {
            _context.TipoAtributo.Find(IdTipoAtributo).IsAtivo = false;
            //_context.TipoAtributo.Remove(_context.TipoAtributo.Find(IdTipoAtributo));
            _context.Commit();
        }

        public void EditarTipoAtributo(TipoAtributo inputs)
        {
            _context.TipoAtributo.Update(inputs);
            _context.Commit();
        }
    }
}
