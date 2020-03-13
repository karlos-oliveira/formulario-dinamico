
using Infra.Data.Repository;
using Models;
using System;
using System.Collections.Generic;
namespace Services
{
    public interface IAtributoService
    {
        void CriarAtributo(Atributo inputs);
        AtributoCompleto ConsultarAtributo(Guid IdAtributo);
        List<AtributoCompleto> ConsultarAtributos();
        void EditarAtributo(Atributo inputs);
        void DeletarAtributo(Guid IdAtributo);
    }

    public class AtributoService : IAtributoService
    {
        private readonly IAtributoRepository _repo;
        public AtributoService(IAtributoRepository repo)
        {
            _repo = repo;
        }

        public AtributoCompleto ConsultarAtributo(Guid IdAtributo)
        {
            return _repo.ConsultarAtributo(IdAtributo);
        }

        public List<AtributoCompleto> ConsultarAtributos()
        {
            return _repo.ConsultarAtributos();
        }

        public void CriarAtributo(Atributo inputs)
        {
            _repo.CriarAtributo(inputs);
        }

        public void DeletarAtributo(Guid IdAtributo)
        {
            _repo.DeletarAtributo(IdAtributo);
        }

        public void EditarAtributo(Atributo inputs)
        {
            _repo.EditarAtributo(inputs);
        }
    }
}
