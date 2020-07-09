using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaProjetoFinal.API.DTOs
{
    public class ModeloDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
