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
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        // GET: api/Modelo
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Modelo>> Get()
        {
            var marcas = _modeloService.Modelos().ToList();

            if (marcas.Any())
            {
                return Ok(marcas);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }//endpoint

        // GET: api/Modelo/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Modelo> Get(int id)
        {
            var modelo = _modeloService.ModeloById(id);

            if (modelo != null)
            {
                return Ok(modelo);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Modelo
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Modelo> Post([FromBody] Modelo modelo)
        {
            var _modelo = _modeloService.Salvar(modelo);

            if (_modelo != null)
            {
                return Ok(_modelo);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Modelo/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Modelo> Put([FromBody] Modelo modelo)
        {
            var _modelo = _modeloService.Atualizar(modelo);

            if (_modelo != null)
            {
                return Ok(_modelo);
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
            var retorno = _modeloService.Deletar(id);

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
