using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AulaProjetoFinal.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        // GET: api/Marca
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Marca>> Get()
        {
            var marcas = _marcaService.Marcas().ToList();

            if (marcas.Any())
            {
                return Ok(marcas);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }//endpoint

        // GET: api/Marca/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Marca> Get(int id)
        {
            var marca = _marcaService.MarcaById(id);

            if (marca != null)
            {
                return Ok(marca);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Marca
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Marca> Post([FromBody] Marca marca)
        {
            var _marca = _marcaService.Salvar(marca);

            if (_marca != null)
            {
                return Ok(_marca);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Marca/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Marca> Put([FromBody] Marca marca)
        {
            var _marca = _marcaService.Atualizar(marca);

            if (_marca != null)
            {
                return Ok(_marca);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var retorno = _marcaService.Deletar(id);

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
