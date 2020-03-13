
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using Shared;
using System.Dynamic;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Controllers
{
    [Route("api/v1/Valores")]
    [ApiController]
    public class ValoresController : ControllerBase
    {
        private readonly IDocumentDBRepository _repo;

        public ValoresController(IDocumentDBRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult CriarValores([FromBody] JsonElement inputs)
        {
            try
            {
                dynamic objdocumento = JsonConvert.DeserializeObject<ExpandoObject>(inputs.ToString(), new ExpandoObjectConverter());
                var cf = new CamposFixos(objdocumento);
                var response = _repo.CriarDocumentoAsync(objdocumento, cf).Result;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Valores: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{IdDocumento}")]
        public ActionResult ConsultarValores([FromRoute] Guid IdDocumento, [FromQuery] string sistema)
        {
            try
            {
                var response = _repo.ConsultarDocumentoAsync(IdDocumento, sistema).Result;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar os Valores do documento {IdDocumento}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{IdDocumento}")]
        public ActionResult DeletarValores([FromRoute] Guid IdDocumento, [FromQuery] string sistema)
        {
            try
            {
                _repo.DeletarDocumentoAsync(IdDocumento, sistema).Wait();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar os Valores do documento {IdDocumento}: {ex.Message}");
            }
        }
    }
}
