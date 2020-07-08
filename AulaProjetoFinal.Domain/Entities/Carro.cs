using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Entities
{
    public class Carro
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
