using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaProjetoFinal.API.DTOs
{
    public class CarroDTO
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public int KM { get; set; }
        public string Observacao { get; set; }
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int? ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public int? VersaoId { get; set; }
        public Versao Versao { get; set; }
    }
}
