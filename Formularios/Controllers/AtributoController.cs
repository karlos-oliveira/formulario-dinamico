
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
namespace Controllers
{
    [Route("api/v1/Atributo")]
    [ApiController]
    public class AtributoController : ControllerBase
    {
        private readonly IAtributoService _serv;

        public AtributoController(IAtributoService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarAtributo([FromBody] Atributo inputs)
        {
            try
            {
                inputs.IdAtributo = Guid.NewGuid();

                _serv.CriarAtributo(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Atributo: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idAtributo}")]
        public ActionResult ConsultarAtributo([FromRoute] Guid IdAtributo)
        {
            try
            {
                var response = _serv.ConsultarAtributo(IdAtributo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Atributo {IdAtributo}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarAtributos()
        {
            try
            {
                var response = _serv.ConsultarAtributos();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Atributos: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarAtributo([FromBody] Atributo inputs)
        {
            try
            {
                _serv.EditarAtributo(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o Atributo {inputs.IdAtributo}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idAtributo}")]
        public ActionResult DeletarAtributo([FromRoute] Guid IdAtributo)
        {
            try
            {
                _serv.DeletarAtributo(IdAtributo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o Atributo {IdAtributo}: {ex.Message}");
            }
        }
    }
}
