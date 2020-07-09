using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaProjetoFinal.API.DTOs
{
    public class VersaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
    }
}
