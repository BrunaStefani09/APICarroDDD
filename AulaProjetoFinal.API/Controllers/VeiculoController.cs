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
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        // GET: api/Veiculo
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Veiculo>> Get()
        {
            var marcas = _veiculoService.Veiculos().ToList();

            if (marcas.Any())
            {
                return Ok(marcas);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }//endpoint

        // GET: api/Veiculo/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Veiculo> Get(int id)
        {
            var veiculo = _veiculoService.VeiculoById(id);

            if (veiculo != null)
            {
                return Ok(veiculo);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Veiculo
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Veiculo> Post([FromBody] Veiculo veiculo)
        {
            var _veiculo = _veiculoService.Salvar(veiculo);

            if (_veiculo != null)
            {
                return Ok(_veiculo);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Veiculo/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Veiculo> Put([FromBody] Veiculo veiculo)
        {
            var _veiculo = _veiculoService.Atualizar(veiculo);

            if (_veiculo != null)
            {
                return Ok(_veiculo);
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
            var retorno = _veiculoService.Deletar(id);

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
