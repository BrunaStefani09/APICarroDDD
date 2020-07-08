using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Entities
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
