
using Infra.Data.Repository;
using Inputs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public interface IModeloAtributoService
    {
        void CriarModeloAtributo(Guid idModelo, List<AtributoInput> atributos);
        ModeloAtributo ConsultarModeloAtributo(Guid IdModeloAtributo);
        List<ModeloAtributo> ConsultarModeloAtributos();
        List<ModeloAtributo> ConsultarAtributosPorModelo(Guid IdModelo);
        List<ModeloCompleto> ConsultarAtributosPorModeloVM(Guid IdModelo, long? versao = null);
        void DeletarModeloAtributo(Guid IdModeloAtributo);
    }

    public class ModeloAtributoService : IModeloAtributoService
    {
        private readonly IModeloAtributoRepository _repo;
        private readonly IModeloRepository _repoMod;
        public ModeloAtributoService(IModeloAtributoRepository repo, IModeloRepository repoMod)
        {
            _repo = repo;
            _repoMod = repoMod;
        }

        public ModeloAtributo ConsultarModeloAtributo(Guid IdModeloAtributo)
        {
            return _repo.ConsultarModeloAtributo(IdModeloAtributo);
        }

        public List<ModeloAtributo> ConsultarModeloAtributos()
        {
            return _repo.ConsultarModeloAtributos();
        }

        public List<ModeloAtributo> ConsultarAtributosPorModelo(Guid IdModelo)
        {
            return _repo.ConsultarAtributosPorModelo(IdModelo);
        }

        public List<ModeloCompleto> ConsultarAtributosPorModeloVM(Guid IdModelo, long? versao = null)
        {
            long _versao;

            if (versao.HasValue)
                _versao = versao.Value;
            else
            {
                var versoes = ConsultarAtributosPorModelo(IdModelo)?.Select(x => x.Versao);
                _versao = versoes.Count() > 0 ? versoes.Max() : 0;
            }

            return _repo.ConsultarAtributosPorModeloVM(IdModelo, _versao);
        }

        public void CriarModeloAtributo(Guid idModelo, List<AtributoInput> atributos)
        {
            var lstModeloAtrib = new List<ModeloAtributo>();
            var modelo = _repoMod.ConsultarModelo(idModelo);

            if (modelo == null)
                throw new Exception("O modelo informado não está cadastrado");

            var lstAtr = ConsultarAtributosPorModelo(idModelo);

            var ultimaVersao = lstAtr.Count == 0 ? 0 : lstAtr?.Select(x => x.Versao).Max();

            atributos.ForEach(x =>
            {
                lstModeloAtrib.Add(new ModeloAtributo
                {
                    IdModeloAtributo = Guid.NewGuid(),
                    IdAtributo = x.IdAtributo,
                    IdModelo = idModelo,
                    Ordem = x.Ordem,
                    Obrigatorio = x.Obrigatorio,
                    MultiplaEscolha = x.MultiplaEscolha,
                    Opcoes = x.Opcoes == null ? "" : string.Join('|', x.Opcoes),
                    Versao = ultimaVersao.HasValue ? ultimaVersao.Value + 1 : 0
                });
            });

            _repo.CriarModeloAtributo(lstModeloAtrib);
        }

        public void DeletarModeloAtributo(Guid IdModeloAtributo)
        {
            _repo.DeletarModeloAtributo(IdModeloAtributo);
        }
    }
}
