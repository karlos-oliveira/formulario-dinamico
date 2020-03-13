
using Infra.Data.Repository;
using Models;
using System;
using System.Collections.Generic;
namespace Services
{
    public interface IModeloService
    {
        void CriarModelo(Modelo inputs);
        Modelo ConsultarModelo(Guid IdModelo);
        List<Modelo> ConsultarModelos();
        void EditarModelo(Modelo inputs);
        void DeletarModelo(Guid IdModelo);
    }

    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _repo;
        public ModeloService(IModeloRepository repo)
        {
            _repo = repo;
        }

        public Modelo ConsultarModelo(Guid IdModelo)
        {
            return _repo.ConsultarModelo(IdModelo);
        }

        public List<Modelo> ConsultarModelos()
        {
            return _repo.ConsultarModelos();
        }

        public void CriarModelo(Modelo inputs)
        {
            _repo.CriarModelo(inputs);
        }

        public void DeletarModelo(Guid IdModelo)
        {
            _repo.DeletarModelo(IdModelo);
        }

        public void EditarModelo(Modelo inputs)
        {
            _repo.EditarModelo(inputs);
        }
    }
}
