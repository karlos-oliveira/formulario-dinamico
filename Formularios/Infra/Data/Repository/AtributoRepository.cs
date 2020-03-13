
using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infra.Data.Repository
{
    public interface IAtributoRepository
    {
        void CriarAtributo(Atributo inputs);
        AtributoCompleto ConsultarAtributo(Guid IdAtributo);
        List<AtributoCompleto> ConsultarAtributos();
        void EditarAtributo(Atributo inputs);
        void DeletarAtributo(Guid IdAtributo);
    }

    public class AtributoRepository : IAtributoRepository
    {
        private readonly IContext _context;

        public AtributoRepository(IContext context)
        {
            _context = context;
        }

        public AtributoCompleto ConsultarAtributo(Guid IdAtributo)
        {
            return _context.AtributoCompleto.Where(x => x.IdAtributo == IdAtributo).First();
        }

        public List<AtributoCompleto> ConsultarAtributos()
        {
            return _context.AtributoCompleto.Where(x => x.IsAtivo).ToList();
            //return _context.Atributo.ToList();
        }

        public void CriarAtributo(Atributo inputs)
        {
            _context.Atributo.Add(inputs);
            _context.Commit();
        }

        public void DeletarAtributo(Guid IdAtributo)
        {
            _context.Atributo.Find(IdAtributo).IsAtivo = false;
            //_context.Atributo.Remove(_context.Atributo.Find(IdAtributo));
            _context.Commit();
        }

        public void EditarAtributo(Atributo inputs)
        {
            _context.Atributo.Update(inputs);
            _context.Commit();
        }
    }
}
