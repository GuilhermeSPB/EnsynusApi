using System;
using System.Collections.Generic;
using EnsynusApi.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EnsynusApi.Data;

public partial class EnsynusContext : DbContext
{
    public EnsynusContext()
    {
    }

    public EnsynusContext(DbContextOptions<EnsynusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Conteudo> Conteudos { get; set; }

    public virtual DbSet<Ingresso> Ingressos { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    public virtual DbSet<VwTurmaxprofessor> VwTurmaxprofessors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3030;user=root;password=root;database=ensynus", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.AluId).HasName("PRIMARY");

            entity.ToTable("aluno");

            entity.HasIndex(e => e.AluEmail, "alu_email").IsUnique();

            entity.Property(e => e.AluId).HasColumnName("alu_id");
            entity.Property(e => e.AluDataNasc).HasColumnName("alu_dataNasc");
            entity.Property(e => e.AluEmail)
                .HasMaxLength(100)
                .HasColumnName("alu_email");
            entity.Property(e => e.AluEmailResp)
                .HasMaxLength(100)
                .HasColumnName("alu_emailResp");
            entity.Property(e => e.AluNome)
                .HasMaxLength(100)
                .HasColumnName("alu_nome");
            entity.Property(e => e.AluNomeResp)
                .HasMaxLength(100)
                .HasColumnName("alu_nomeResp");
            entity.Property(e => e.AluSenha)
                .HasMaxLength(100)
                .HasColumnName("alu_senha");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.AulId).HasName("PRIMARY");

            entity.ToTable("aula");

            entity.HasIndex(e => e.FkIdTurma, "fk_idTurma");

            entity.Property(e => e.AulId).HasColumnName("aul_id");
            entity.Property(e => e.AulData).HasColumnName("aul_data");
            entity.Property(e => e.AulDescricao)
                .HasColumnType("text")
                .HasColumnName("aul_descricao");
            entity.Property(e => e.AulNome)
                .HasMaxLength(100)
                .HasColumnName("aul_nome");
            entity.Property(e => e.FkIdTurma).HasColumnName("fk_idTurma");

            entity.HasOne(d => d.FkIdTurmaNavigation).WithMany(p => p.Aulas)
                .HasForeignKey(d => d.FkIdTurma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aula_ibfk_1");
        });

        modelBuilder.Entity<Conteudo>(entity =>
        {
            entity.HasKey(e => e.ConId).HasName("PRIMARY");

            entity.ToTable("conteudo");

            entity.HasIndex(e => e.FkIdAula, "fk_idAula");

            entity.Property(e => e.ConId).HasColumnName("con_id");
            entity.Property(e => e.ConDataAnexo).HasColumnName("con_dataAnexo");
            entity.Property(e => e.ConDescricao)
                .HasColumnType("text")
                .HasColumnName("con_descricao");
            entity.Property(e => e.ConNome)
                .HasMaxLength(100)
                .HasColumnName("con_nome");
            entity.Property(e => e.ConTipoArquivo)
                .HasMaxLength(50)
                .HasColumnName("con_tipoArquivo");
            entity.Property(e => e.FkIdAula).HasColumnName("fk_idAula");

            entity.HasOne(d => d.FkIdAulaNavigation).WithMany(p => p.Conteudos)
                .HasForeignKey(d => d.FkIdAula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conteudo_ibfk_1");
        });

        modelBuilder.Entity<Ingresso>(entity =>
        {
            entity.HasKey(e => e.IngId).HasName("PRIMARY");

            entity.ToTable("ingresso");

            entity.HasIndex(e => e.FkAluId, "fk_alu_id");

            entity.HasIndex(e => e.FkTurId, "fk_tur_id");

            entity.Property(e => e.IngId).HasColumnName("ing_id");
            entity.Property(e => e.FkAluId).HasColumnName("fk_alu_id");
            entity.Property(e => e.FkTurId).HasColumnName("fk_tur_id");
            entity.Property(e => e.IngDataEntrada).HasColumnName("ing_dataEntrada");
            entity.Property(e => e.IngDataSaida).HasColumnName("ing_dataSaida");
            entity.Property(e => e.IngSolicitacao)
                .HasMaxLength(255)
                .HasColumnName("ing_solicitacao");

            entity.HasOne(d => d.FkAlu).WithMany(p => p.Ingressos)
                .HasForeignKey(d => d.FkAluId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingresso_ibfk_1");

            entity.HasOne(d => d.FkTur).WithMany(p => p.Ingressos)
                .HasForeignKey(d => d.FkTurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingresso_ibfk_2");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PRIMARY");

            entity.ToTable("professor");

            entity.HasIndex(e => e.ProEmail, "pro_email").IsUnique();

            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.ProDataNasc).HasColumnName("pro_dataNasc");
            entity.Property(e => e.ProEmail)
                .HasMaxLength(100)
                .HasColumnName("pro_email");
            entity.Property(e => e.ProNome)
                .HasMaxLength(100)
                .HasColumnName("pro_nome");
            entity.Property(e => e.ProSenha)
                .HasMaxLength(100)
                .HasColumnName("pro_senha");
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.TurId).HasName("PRIMARY");

            entity.ToTable("turma");

            entity.HasIndex(e => e.FkIdProfessor, "fk_idProfessor");

            entity.Property(e => e.TurId).HasColumnName("tur_id");
            entity.Property(e => e.FkIdProfessor).HasColumnName("fk_idProfessor");
            entity.Property(e => e.TurAreaConhecimento)
                .HasMaxLength(100)
                .HasColumnName("tur_areaConhecimento");
            entity.Property(e => e.TurDescricao)
                .HasColumnType("text")
                .HasColumnName("tur_descricao");
            entity.Property(e => e.TurDuracao)
                .HasMaxLength(20)
                .HasColumnName("tur_duracao");
            entity.Property(e => e.TurModalidade)
                .HasMaxLength(50)
                .HasColumnName("tur_modalidade");
            entity.Property(e => e.TurNome)
                .HasMaxLength(100)
                .HasColumnName("tur_nome");

            entity.HasOne(d => d.FkIdProfessorNavigation).WithMany(p => p.Turmas)
                .HasForeignKey(d => d.FkIdProfessor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turma_ibfk_1");
        });

        modelBuilder.Entity<VwTurmaxprofessor>(entity =>
        {
            entity.HasKey(e => e.Cód);                       
            entity.ToView("vw_turmaxprofessor");             

            entity.Property(e => e.Cód)
                .HasMaxLength(50)
                .ValueGeneratedNever();
            entity.Property(e => e.Modalidade).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Professor).HasMaxLength(100);
            entity.Property(e => e.Área).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
