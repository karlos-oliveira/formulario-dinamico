
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/v1/TipoAtributo")]
    [ApiController]
    public class TipoAtributoController : ControllerBase
    {
        private readonly ITipoAtributoService _serv;

        public TipoAtributoController(ITipoAtributoService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarTipoAtributo([FromBody] TipoAtributo inputs)
        {
            try
            {
                inputs.IdTipoAtributo = Guid.NewGuid();

                _serv.CriarTipoAtributo(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo TipoAtributo: {ex.Message}");
            }

        }

        [HttpPost]
        [Route("lote")]
        public ActionResult CriarTipoAtributoLote([FromBody] List<TipoAtributo> inputs)
        {
            try
            {
                _serv.CriarTipoAtributoLote(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo TipoAtributo: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idTipoAtributo}")]
        public ActionResult ConsultarTipoAtributo([FromRoute] Guid IdTipoAtributo)
        {
            try
            {
                var response = _serv.ConsultarTipoAtributo(IdTipoAtributo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o TipoAtributo {IdTipoAtributo}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarTipoAtributos()
        {
            try
            {
                var response = _serv.ConsultarTipoAtributos();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar TipoAtributos: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarTipoAtributo([FromBody] TipoAtributo inputs)
        {
            try
            {
                _serv.EditarTipoAtributo(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o TipoAtributo {inputs.IdTipoAtributo}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idTipoAtributo}")]
        public ActionResult DeletarTipoAtributo([FromRoute] Guid IdTipoAtributo)
        {
            try
            {
                _serv.DeletarTipoAtributo(IdTipoAtributo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o TipoAtributo {IdTipoAtributo}: {ex.Message}");
            }
        }
    }
}