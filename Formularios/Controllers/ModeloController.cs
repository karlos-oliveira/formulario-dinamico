
using Inputs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/v1/Modelo")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _serv;
        private readonly IModeloAtributoService _servModAtr;

        public ModeloController(IModeloService serv, IModeloAtributoService servModAtr)
        {
            _serv = serv;
            _servModAtr = servModAtr;
        }

        [HttpPost]
        public ActionResult CriarModelo([FromBody] Modelo inputs)
        {
            try
            {
                inputs.IdModelo = Guid.NewGuid();

                _serv.CriarModelo(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Modelo: {ex.Message}");
            }

        }

        [HttpPost]
        [Route("{IdModelo}/AssociarAtributos")]
        public ActionResult AssociarAtributoModelo([FromRoute] Guid IdModelo, [FromBody] List<AtributoInput> atributos)
        {
            try
            {
                _servModAtr.CriarModeloAtributo(IdModelo, atributos);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao associar os atributos ao Modelo: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idModelo}")]
        public ActionResult ConsultarModelo([FromRoute] Guid IdModelo)
        {
            try
            {
                var response = _serv.ConsultarModelo(IdModelo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Modelo {IdModelo}: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idModelo}/Atributos")]
        public ActionResult ConsultarAtributosPorModelo([FromRoute] Guid IdModelo, [FromQuery] long? versao = null)
        {
            try
            {
                var response = _servModAtr.ConsultarAtributosPorModeloVM(IdModelo, versao);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar atributos do Modelo {IdModelo}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarModelos()
        {
            try
            {
                var response = _serv.ConsultarModelos();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Modelos: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idModelo}")]
        public ActionResult DeletarModelo([FromRoute] Guid IdModelo)
        {
            try
            {
                _serv.DeletarModelo(IdModelo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o Modelo {IdModelo}: {ex.Message}");
            }
        }
    }
}
