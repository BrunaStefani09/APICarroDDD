using AulaProjetoFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Infra.Data.Context
{
    public sealed class DataContext : DbContext, IDisposable //interface para fechar conexão com o banco
    {
        //objeto que permite a manipulação de dados atraves da apliação para o banco de dados
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Versao> Versoes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        } //metodo construtor
        protected override void OnModelCreating(ModelBuilder modelBuilder) //criação dos modelos das tabelas
        { //cria as tabelas com codefirst
            modelBuilder.Entity<Marca>().ToTable("Marca");

            modelBuilder.Entity<Marca>()
                .Property(c => c.Nome)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome"); //nome da coluna

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Versao>().ToTable("Versao");

            modelBuilder.Entity<Versao>()
                .Property(c => c.Nome)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("varchar(50)")
                .HasColumnName("Nome"); //nome da coluna

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Veiculo>().ToTable("Veiculo");

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.Imagem)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("varchar(500)")
                .HasColumnName("Imagem"); //nome da coluna

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.KM)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("int")
                .HasColumnName("KM"); //nome da coluna

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.Preco)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("float")
                .HasColumnName("Preco"); //nome da coluna

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.AnoModelo)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("int")
                .HasColumnName("AnoModelo"); //nome da coluna

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.AnoFabricacao)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("int")
                .HasColumnName("AnoFabricacao"); //nome da coluna

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.Cor)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("varchar(150)")
                .HasColumnName("Cor"); //nome da coluna

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carro>().ToTable("Carro");

            modelBuilder.Entity<Carro>()
                .Property(c => c.Ano)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("int")
                .HasColumnName("Ano"); //nome da coluna

            modelBuilder.Entity<Carro>()
                .Property(c => c.KM)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("int")
                .HasColumnName("KM"); //nome da coluna

            modelBuilder.Entity<Carro>()
                .Property(c => c.Observacao)
                .IsRequired() //obrigatoriedade (NotNull)
                .HasColumnType("varchar(250)")
                .HasColumnName("Observacao"); //nome da coluna

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        { //configuração banco de dados
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer("Data Source=DESKTOP-QP4USBI\\BRUNA_SQLSERVER;Initial Catalog=Carros_Cod;Integrated Security=True"); //em qual banco sera executado o OnCreating
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
