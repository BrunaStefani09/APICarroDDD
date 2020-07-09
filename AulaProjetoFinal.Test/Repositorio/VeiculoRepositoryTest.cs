using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using AulaProjetoFinal.Infra.Data.Context;
using AulaProjetoFinal.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AulaProjetoFinal.Test.Repositorio
{
    public class VeiculoRepositoryTest
    {
        private readonly Veiculo _veiculo;

        public VeiculoRepositoryTest()
        {
            _veiculo = new Veiculo
            {
                AnoFabricacao = 1998,
                AnoModelo = 1999,
                Cor = "Azul da cor do céu",
                Imagem = "Imagem veiculo Teste em aula",
                MarcaId = 1,
                ModeloId = 1,
                Preco = 34567.89,
                KM = 45,
                VersaoId = 1
            };
        }

        [Fact]
        public void Adicionar_Veiculo()
        {
            IVeiculoRepository veiculoRepository = GetVeiculoRepository();

            Veiculo veiculo = veiculoRepository.Save(_veiculo);

            Assert.Equal("Azul da cor do céu", veiculo.Cor);
            Assert.Equal("Imagem veiculo Teste em aula", veiculo.Imagem);
            Assert.NotNull(veiculo.VersaoId);
        }

        private IVeiculoRepository GetVeiculoRepository()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer("Data Source=DESKTOP-QP4USBI\\BRUNA_SQLSERVER;Initial Catalog=Carros_Cod;Integrated Security=True");
            options = builder.Options;
            DataContext veiculoDataContext = new DataContext(options);
            return new VeiculoRepository(veiculoDataContext);
        }
    }
}
