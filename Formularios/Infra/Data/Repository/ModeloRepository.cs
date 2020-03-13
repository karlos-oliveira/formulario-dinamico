
using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infra.Data.Repository
{
    public interface IModeloRepository
    {
        void CriarModelo(Modelo inputs);
        Modelo ConsultarModelo(Guid IdModelo);
        List<Modelo> ConsultarModelos();
        void EditarModelo(Modelo inputs);
        void DeletarModelo(Guid IdModelo);
    }

    public class ModeloRepository : IModeloRepository
    {
        private readonly IContext _context;

        public ModeloRepository(IContext context)
        {
            _context = context;
        }

        public Modelo ConsultarModelo(Guid IdModelo)
        {
            return _context.Modelo.Where(x => x.IdModelo == IdModelo).FirstOrDefault();
        }

        public List<Modelo> ConsultarModelos()
        {
            return _context.Modelo.Where(x => x.IsAtivo).ToList();
            // _context.Modelo.ToList();
        }

        public void CriarModelo(Modelo inputs)
        {
            _context.Modelo.Add(inputs);
            _context.Commit();
        }

        public void DeletarModelo(Guid IdModelo)
        {
            _context.Modelo.Find(IdModelo).IsAtivo = false;
            //_context.Modelo.Remove(_context.Modelo.Find(IdModelo));
            _context.Commit();
        }

        public void EditarModelo(Modelo inputs)
        {
            _context.Modelo.Update(inputs);
            _context.Commit();
        }
    }
}
