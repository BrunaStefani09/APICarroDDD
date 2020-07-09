using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AulaProjetoFinal.API.DTOs;
using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AulaProjetoFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;
        private readonly IMapper _mapper;


        public CarroController(ICarroService carroService, IMapper mapper)
        {
            _carroService = carroService;
            _mapper = mapper;
        }

        // GET: api/Carro
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CarroDTO>> Get()
        {
            var carro = _carroService.Carros().ToList();
            var retorno = new List<CarroDTO>();
            if (carro.Any())
            {
                retorno = _mapper.Map<List<CarroDTO>>(carro);
                return Ok(retorno);
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
        public ActionResult<CarroDTO> Get(int id)
        {
            var carro = _carroService.CarroById(id);
            var retorno = new CarroDTO();
            if (carro != null)
            {
                retorno = _mapper.Map<CarroDTO>(carro);
                return Ok(retorno);
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
        public ActionResult<CarroDTO> Post([FromBody] CarroDTO carro)
        {
            var value = _mapper.Map<Carro>(carro);
            var _carro = _carroService.Salvar(value);
            var retorno = new CarroDTO();
            if (_carro != null)
            {
                retorno = _mapper.Map<CarroDTO>(_carro);
                return Ok(retorno);
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
        public ActionResult<CarroDTO> Put([FromBody] CarroDTO carro)
        {
            var value = _mapper.Map<Carro>(carro);
            var _carro = _carroService.Atualizar(value);
            var retorno = new CarroDTO();
            if (_carro != null)
            {
                retorno = _mapper.Map<CarroDTO>(_carro);
                return Ok(retorno);
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
