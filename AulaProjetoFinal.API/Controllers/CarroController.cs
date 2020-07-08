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
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        // GET: api/Carro
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Carro>> Get()
        {
            var marcas = _carroService.Carros().ToList();

            if (marcas.Any())
            {
                return Ok(marcas);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }//endpoint

        // GET: api/Carro/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Carro> Get(int id)
        {
            var carro = _carroService.CarroById(id);

            if (carro != null)
            {
                return Ok(carro);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }

        // POST: api/Carro
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Carro> Post([FromBody] Carro carro)
        {
            var _carro = _carroService.Salvar(carro);

            if (_carro != null)
            {
                return Ok(_carro);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }

        // PUT: api/Carro/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Carro> Put([FromBody] Carro carro)
        {
            var _carro = _carroService.Atualizar(carro);

            if (_carro != null)
            {
                return Ok(_carro);
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Delete(int id)
        {
            var retorno = _carroService.Deletar(id);

            if (retorno)
            {
                return Ok("Registro deletado com sucesso!");
            }
            else
            {
                return NoContent(); //não tem valor
            }
        }
    }
}
