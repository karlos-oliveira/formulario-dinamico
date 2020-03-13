
using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infra.Data.Repository
{
    public interface IModeloAtributoRepository
    {
        void CriarModeloAtributo(ModeloAtributo inputs);
        void CriarModeloAtributo(List<ModeloAtributo> lstInputs);
        ModeloAtributo ConsultarModeloAtributo(Guid IdModeloAtributo);
        List<ModeloAtributo> ConsultarModeloAtributos();
        List<ModeloAtributo> ConsultarAtributosPorModelo(Guid IdModelo);
        List<ModeloCompleto> ConsultarAtributosPorModeloVM(Guid IdModelo, long versao);
        void EditarModeloAtributo(ModeloAtributo inputs);
        void DeletarModeloAtributo(Guid IdModeloAtributo);
    }

    public class ModeloAtributoRepository : IModeloAtributoRepository
    {
        private readonly IContext _context;

        public ModeloAtributoRepository(IContext context)
        {
            _context = context;
        }

        public ModeloAtributo ConsultarModeloAtributo(Guid IdModeloAtributo)
        {
            return _context.ModeloAtributo.Where(x => x.IdModeloAtributo == IdModeloAtributo).First();
        }

        public List<ModeloAtributo> ConsultarAtributosPorModelo(Guid IdModelo)
        {
            return _context.ModeloAtributo.Where(x => x.IdModelo == IdModelo)?.ToList();
        }

        public List<ModeloCompleto> ConsultarAtributosPorModeloVM(Guid IdModelo, long versao)
        {
            return _context.ModeloCompleto.Where(x => x.IdModelo == IdModelo && x.Versao == versao)?.ToList();
        }

        public List<ModeloAtributo> ConsultarModeloAtributos()
        {
            //return _context.ModeloAtributo.Where(x => x.IsAtivo).ToList();
            return _context.ModeloAtributo.ToList();
        }

        public void CriarModeloAtributo(ModeloAtributo inputs)
        {
            _context.ModeloAtributo.Add(inputs);
            _context.Commit();
        }

        public void CriarModeloAtributo(List<ModeloAtributo> lstInputs)
        {
            _context.ModeloAtributo.AddRange(lstInputs);
            _context.Commit();
        }

        public void DeletarModeloAtributo(Guid IdModeloAtributo)
        {
            //_context.ModeloAtributo.Find(IdModeloAtributo).IsAtivo = false;
            _context.ModeloAtributo.Remove(_context.ModeloAtributo.Find(IdModeloAtributo));
            _context.Commit();
        }

        public void EditarModeloAtributo(ModeloAtributo inputs)
        {
            _context.ModeloAtributo.Update(inputs);
            _context.Commit();
        }
    }
}
