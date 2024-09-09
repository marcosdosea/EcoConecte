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

    public virtual DbSet<Cidadao> Cidadaos { get; set; }

    public virtual DbSet<Cooperado> Cooperados { get; set; }

    public virtual DbSet<Cooperativa> Cooperativas { get; set; }

    public virtual DbSet<Noticium> Noticia { get; set; }

    public virtual DbSet<Orientaco> Orientacoes { get; set; }

    public virtual DbSet<Rotinadecoletum> Rotinadecoleta { get; set; }

    public virtual DbSet<Vendamaterial> Vendamaterials { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=l123;database=ecoconecte");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.IdAgendamento).HasName("PRIMARY");

            entity.ToTable("agendamento");

            entity.HasIndex(e => e.Cep, "cep_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CidadaoIdCidadao, "fk_Agendamento_Cidadao1_idx");

            entity.HasIndex(e => new { e.CooperadoIdCooperado, e.CooperadoCpf }, "fk_Agendamento_Cooperado1_idx");

            entity.Property(e => e.IdAgendamento).HasColumnName("idAgendamento");
            entity.Property(e => e.Cep).HasMaxLength(15);
            entity.Property(e => e.CidadaoIdCidadao).HasColumnName("Cidadao_idCidadao");
            entity.Property(e => e.CooperadoCpf)
                .HasMaxLength(45)
                .HasColumnName("Cooperado_Cpf");
            entity.Property(e => e.CooperadoIdCooperado).HasColumnName("Cooperado_idCooperado");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Horario).HasColumnType("datetime");
            entity.Property(e => e.Logradouro).HasMaxLength(45);
            entity.Property(e => e.NumeroEndereco).HasColumnName("numeroEndereco");

            entity.HasOne(d => d.CidadaoIdCidadaoNavigation).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.CidadaoIdCidadao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Agendamento_Cidadao1_idx");

            entity.HasOne(d => d.Cooperado).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => new { d.CooperadoIdCooperado, d.CooperadoCpf })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Agendamento_Cooperado1_idx");
        });

        modelBuilder.Entity<Cidadao>(entity =>
        {
            entity.HasKey(e => e.IdCidadao).HasName("PRIMARY");

            entity.ToTable("cidadao");

            entity.HasIndex(e => e.Cpf, "CPF_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "NOME_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "nome_idx");

            entity.Property(e => e.IdCidadao).HasColumnName("idCidadao");
            entity.Property(e => e.Bairro).HasMaxLength(25);
            entity.Property(e => e.Cpf).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Logradouro).HasMaxLength(15);
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.NumeroEndereco).HasColumnName("numeroEndereco");
            entity.Property(e => e.Telefone).HasMaxLength(10);
        });

        modelBuilder.Entity<Cooperado>(entity =>
        {
            entity.HasKey(e => new { e.IdCooperado, e.Cpf }).HasName("PRIMARY");

            entity.ToTable("cooperado");

            entity.HasIndex(e => e.Cpf, "Cpf_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "nome_idx");

            entity.Property(e => e.IdCooperado)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCooperado");
            entity.Property(e => e.Cpf).HasMaxLength(45);
            entity.Property(e => e.Nome).HasMaxLength(10);
            entity.Property(e => e.Telefone).HasMaxLength(45);
        });

        modelBuilder.Entity<Cooperativa>(entity =>
        {
            entity.HasKey(e => e.IdCooperativa).HasName("PRIMARY");

            entity.ToTable("cooperativa");

            entity.HasIndex(e => e.Cnpj, "cnpj_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AgendamentoIdAgendamento, "fk_Cooperativa_Agendamento1_idx");

            entity.HasIndex(e => e.CooperadoIdCooperado, "fk_Cooperativa_Cooperado1_idx");

            entity.HasIndex(e => e.NoticiaIdNoticia, "fk_Cooperativa_Noticia1_idx");

            entity.HasIndex(e => e.OrientacoesIdOrientacoes, "fk_Cooperativa_Orientacoes1_idx");

            entity.HasIndex(e => e.RotinaDeColetaIdRotinaDeColeta, "fk_Cooperativa_RotinaDeColeta1_idx");

            entity.HasIndex(e => e.VendaMaterialIdVendaMaterial, "fk_Cooperativa_VendaMaterial1_idx");

            entity.HasIndex(e => e.InscricaoEstadual, "inscricaoEstadual_UNIQUE").IsUnique();

            entity.HasIndex(e => e.InscricaoMunicipal, "inscricaoMunicipal_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "nome_idx");

            entity.Property(e => e.IdCooperativa).HasColumnName("idCooperativa");
            entity.Property(e => e.AgendamentoIdAgendamento).HasColumnName("Agendamento_idAgendamento");
            entity.Property(e => e.Bairro).HasMaxLength(45);
            entity.Property(e => e.Cep).HasMaxLength(45);
            entity.Property(e => e.Cnpj).HasMaxLength(45);
            entity.Property(e => e.CooperadoIdCooperado).HasColumnName("Cooperado_idCooperado");
            entity.Property(e => e.CpfRepresentante)
                .HasMaxLength(45)
                .HasColumnName("cpfRepresentante");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.InscricaoEstadual)
                .HasMaxLength(45)
                .HasColumnName("inscricaoEstadual");
            entity.Property(e => e.InscricaoMunicipal)
                .HasMaxLength(45)
                .HasColumnName("inscricaoMunicipal");
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.NomeRepresentante)
                .HasMaxLength(45)
                .HasColumnName("nomeRepresentante");
            entity.Property(e => e.NoticiaIdNoticia).HasColumnName("Noticia_idNoticia");
            entity.Property(e => e.NumeroEndereco).HasColumnName("numeroEndereco");
            entity.Property(e => e.OrientacoesIdOrientacoes).HasColumnName("Orientacoes_idOrientacoes");
            entity.Property(e => e.RotinaDeColetaIdRotinaDeColeta).HasColumnName("RotinaDeColeta_idRotinaDeColeta");
            entity.Property(e => e.Rua).HasMaxLength(45);
            entity.Property(e => e.Telefone).HasMaxLength(10);
            entity.Property(e => e.VendaMaterialIdVendaMaterial).HasColumnName("VendaMaterial_idVendaMaterial");

            entity.HasOne(d => d.AgendamentoIdAgendamentoNavigation).WithMany(p => p.Cooperativas)
                .HasForeignKey(d => d.AgendamentoIdAgendamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cooperativa_Agendamento1_idx");

            entity.HasOne(d => d.NoticiaIdNoticiaNavigation).WithMany(p => p.Cooperativas)
                .HasForeignKey(d => d.NoticiaIdNoticia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cooperativa_Noticia1_idx");

            entity.HasOne(d => d.OrientacoesIdOrientacoesNavigation).WithMany(p => p.Cooperativas)
                .HasForeignKey(d => d.OrientacoesIdOrientacoes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cooperativa_Orientacoes1_idx");

            entity.HasOne(d => d.RotinaDeColetaIdRotinaDeColetaNavigation).WithMany(p => p.Cooperativas)
                .HasForeignKey(d => d.RotinaDeColetaIdRotinaDeColeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cooperativa_RotinaDeColeta1_idx");

            entity.HasOne(d => d.VendaMaterialIdVendaMaterialNavigation).WithMany(p => p.Cooperativas)
                .HasForeignKey(d => d.VendaMaterialIdVendaMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cooperativa_VendaMaterial1_idx");
        });

        modelBuilder.Entity<Noticium>(entity =>
        {
            entity.HasKey(e => e.IdNoticia).HasName("PRIMARY");

            entity.ToTable("noticia");

            entity.HasIndex(e => e.Titulo, "titulo_idx");

            entity.Property(e => e.IdNoticia).HasColumnName("idNoticia");
            entity.Property(e => e.Conteudo).HasMaxLength(45);
            entity.Property(e => e.Titulo).HasMaxLength(45);
        });

        modelBuilder.Entity<Orientaco>(entity =>
        {
            entity.HasKey(e => e.IdOrientacoes).HasName("PRIMARY");

            entity.ToTable("orientacoes");

            entity.HasIndex(e => e.Titulo, "titulo_idx");

            entity.Property(e => e.IdOrientacoes).HasColumnName("idOrientacoes");
            entity.Property(e => e.Descricao).HasMaxLength(45);
            entity.Property(e => e.Titulo).HasMaxLength(45);
        });

        modelBuilder.Entity<Rotinadecoletum>(entity =>
        {
            entity.HasKey(e => e.IdRotinaDeColeta).HasName("PRIMARY");

            entity.ToTable("rotinadecoleta");

            entity.Property(e => e.IdRotinaDeColeta).HasColumnName("idRotinaDeColeta");
            entity.Property(e => e.Cep).HasMaxLength(45);
            entity.Property(e => e.DiaColeta)
                .HasColumnType("datetime")
                .HasColumnName("diaColeta");
            entity.Property(e => e.HorarioInicio)
                .HasColumnType("datetime")
                .HasColumnName("horarioInicio");
            entity.Property(e => e.HorarioTermino)
                .HasColumnType("datetime")
                .HasColumnName("horarioTermino");
            entity.Property(e => e.Logradouro).HasMaxLength(45);
            entity.Property(e => e.NumeroEndereco).HasColumnName("numeroEndereco");
        });

        modelBuilder.Entity<Vendamaterial>(entity =>
        {
            entity.HasKey(e => e.IdVendaMaterial).HasName("PRIMARY");

            entity.ToTable("vendamaterial");

            entity.HasIndex(e => e.CooperadoIdCooperado, "fk_VendaMaterial_Cooperado1_idx");

            entity.Property(e => e.IdVendaMaterial).HasColumnName("idVendaMaterial");
            entity.Property(e => e.CooperadoCpf)
                .HasMaxLength(45)
                .HasColumnName("Cooperado_Cpf");
            entity.Property(e => e.CooperadoIdCooperado).HasColumnName("Cooperado_idCooperado");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.QuantidadeVendida)
                .HasPrecision(10)
                .HasColumnName("quantidadeVendida");
            entity.Property(e => e.Tipo).HasMaxLength(45);
            entity.Property(e => e.Valor).HasPrecision(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
