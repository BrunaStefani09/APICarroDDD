using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Entities
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Modelo> Modelos { get; set; }
    }
}
