using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Entities
{
    public class Versao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
    }
}
