using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AulaProjetoFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        private readonly IVersaoService _versaoService;

        public VersaoController(IVersaoService versaoService)
        {
            _versaoService = versaoService;
        }

        // GET: api/Versao
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Versao>> Get()
        {
            var marcas = _versaoService.Versoes().ToList();

            if (marcas.Any())
            {
                return Ok(marcas);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }//endpoint

        // GET: api/Versao/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Versao> Get(int id)
        {
            var versao = _versaoService.VersaoById(id);

            if (versao != null)
            {
                return Ok(versao);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Versao
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Versao> Post([FromBody] Versao versao)
        {
            var _versao = _versaoService.Salvar(versao);

            if (_versao != null)
            {
                return Ok(_versao);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Versao/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Versao> Put([FromBody] Versao versao)
        {
            var _versao = _versaoService.Atualizar(versao);

            if (_versao != null)
            {
                return Ok(_versao);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Delete(int id)
        {
            var retorno = _versaoService.Deletar(id);

            if (retorno)
            {
                return Ok("Registro deletado com sucesso!");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
