using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class ecoconecteContext : DbContext
{
    public ecoconecteContext()
    {
    }

    public ecoconecteContext(DbContextOptions<ecoconecteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Cooperativa> Cooperativas { get; set; }

    public virtual DbSet<Noticia> Noticia { get; set; }

    public virtual DbSet<Orientacoes> Orientacoes { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Coleta> Coleta { get; set; }

    public virtual DbSet<Vendamaterial> Vendamaterials { get; set; }

    public void Delete(uint id)
    {
        throw new NotImplementedException();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("agendamento");

            entity.HasIndex(e => e.Cep, "cep_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdPessoa, "fk_Agendamento_Cidadao1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(45)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(15)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(45)
                .HasColumnName("logradouro");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .HasColumnName("numero");
            entity.Property(e => e.Status)
                .HasComment("A - ATIVO\nC -CANCELADO")
                .HasColumnType("enum('A','C')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Cooperativa>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Status }).HasName("PRIMARY");

            entity.ToTable("cooperativa");

            entity.HasIndex(e => e.Cnpj, "cnpj_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdPessoaRepresentate, "fk_Cooperativa_Pessoa1_idx");

            entity.HasIndex(e => e.InscricaoEstadual, "inscricaoEstadual_UNIQUE").IsUnique();

            entity.HasIndex(e => e.InscricaoMunicipal, "inscricaoMunicipal_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "nome_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Status)
                .HasComment("A - ATIVO\nI - INATIVO")
                .HasColumnType("enum('A','I')")
                .HasColumnName("status");
            entity.Property(e => e.Bairro)
                .HasMaxLength(45)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(45)
                .HasColumnName("cep");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(45)
                .HasColumnName("cnpj");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.IdPessoaRepresentate).HasColumnName("idPessoaRepresentate");
            entity.Property(e => e.InscricaoEstadual)
                .HasMaxLength(45)
                .HasColumnName("inscricaoEstadual");
            entity.Property(e => e.InscricaoMunicipal)
                .HasMaxLength(45)
                .HasColumnName("inscricaoMunicipal");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(45)
                .HasColumnName("logradouro");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .HasColumnName("numero");
            entity.Property(e => e.Telefone)
                .HasMaxLength(10)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Noticia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("noticia");

            entity.HasIndex(e => e.IdCooperativa, "fk_Noticia_Cooperativa1_idx");

            entity.HasIndex(e => e.Titulo, "titulo_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Conteudo)
                .HasMaxLength(2000)
                .HasColumnName("conteudo");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdCooperativa).HasColumnName("idCooperativa");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Orientacoes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orientacoes");

            entity.HasIndex(e => e.IdCooperativa, "fk_Orientacoes_Cooperativa1_idx");

            entity.HasIndex(e => e.Titulo, "titulo_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(2000)
                .HasColumnName("descricao");
            entity.Property(e => e.IdCooperativa).HasColumnName("idCooperativa");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Cpf, "cpf_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdCooperativa, "fk_Pessoa_Cooperativa1_idx");

            entity.HasIndex(e => e.Nome, "nome_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(25)
                .HasColumnName("bairro");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(45)
                .HasColumnName("cpf");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdCooperativa).HasColumnName("idCooperativa");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(15)
                .HasColumnName("logradouro");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .HasColumnName("numero");
            entity.Property(e => e.Status)
                .HasComment("A - ATIVO\nI - INATIVO")
                .HasColumnType("enum('A','I')")
                .HasColumnName("status");
            entity.Property(e => e.Telefone)
                .HasMaxLength(10)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Coleta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rotinadecoleta");

            entity.HasIndex(e => e.IdCooperativa, "fk_RotinaDeColeta_Cooperativa1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cep)
                .HasMaxLength(45)
                .HasColumnName("cep");
            entity.Property(e => e.DiaColeta)
                .HasColumnType("datetime")
                .HasColumnName("diaColeta");
            entity.Property(e => e.HorarioInicio)
                .HasColumnType("datetime")
                .HasColumnName("horarioInicio");
            entity.Property(e => e.HorarioTermino)
                .HasColumnType("datetime")
                .HasColumnName("horarioTermino");
            entity.Property(e => e.IdCooperativa).HasColumnName("idCooperativa");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(45)
                .HasColumnName("logradouro");
            entity.Property(e => e.Numero).HasColumnName("numero");
        });

        modelBuilder.Entity<Vendamaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vendamaterial");

            entity.HasIndex(e => e.IdCooperativa, "fk_VendaMaterial_Cooperativa1_idx");

            entity.HasIndex(e => e.IdPessoa, "fk_VendaMaterial_Pessoa1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdCooperativa).HasColumnName("idCooperativa");
            entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10)
                .HasColumnName("quantidade");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('M','P')")
                .HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasPrecision(10)
                .HasColumnName("valor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
