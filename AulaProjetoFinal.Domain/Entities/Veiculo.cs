using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public int KM { get; set; }
        public double Preco { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; }
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int? ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public int? VersaoId { get; set; }
        public Versao Versao { get; set; }
    }
}
