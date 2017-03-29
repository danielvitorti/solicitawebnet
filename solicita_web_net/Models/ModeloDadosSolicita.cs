namespace solicita_web_net.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDadosSolicita : DbContext
    {
        public ModeloDadosSolicita()
            : base("name=ModeloDadosSolicita")
        {
        }

        public virtual DbSet<sol_anexos> sol_anexos { get; set; }
        public virtual DbSet<sol_categoria_servico> sol_categoria_servico { get; set; }
        public virtual DbSet<sol_causas> sol_causas { get; set; }
        public virtual DbSet<sol_classificacao> sol_classificacao { get; set; }
        public virtual DbSet<sol_comentario> sol_comentario { get; set; }
        public virtual DbSet<sol_grupo_resolvedor> sol_grupo_resolvedor { get; set; }
        public virtual DbSet<sol_impacto> sol_impacto { get; set; }
        public virtual DbSet<sol_ocorrencia> sol_ocorrencia { get; set; }
        public virtual DbSet<sol_produto> sol_produto { get; set; }
        public virtual DbSet<sol_responsavel> sol_responsavel { get; set; }
        public virtual DbSet<sol_solicitacao> sol_solicitacao { get; set; }
        public virtual DbSet<sol_solicitante> sol_solicitante { get; set; }
        public virtual DbSet<sol_status> sol_status { get; set; }
        public virtual DbSet<sol_sub_causas> sol_sub_causas { get; set; }
        public virtual DbSet<sol_tipo_servico> sol_tipo_servico { get; set; }
        public virtual DbSet<sol_urgencia> sol_urgencia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sol_anexos>()
                .Property(e => e.sol_arquivo_anexo)
                .IsUnicode(false);

            modelBuilder.Entity<sol_categoria_servico>()
                .Property(e => e.sol_categoria_servico_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_categoria_servico>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_categoria_servico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_causas>()
                .Property(e => e.sol_causa_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_classificacao>()
                .Property(e => e.sol_classificacao_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_classificacao>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_classificacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_comentario>()
                .Property(e => e.sol_descricao_comentario)
                .IsUnicode(false);

            modelBuilder.Entity<sol_grupo_resolvedor>()
                .Property(e => e.sol_grupo_resolvedor_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_grupo_resolvedor>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_grupo_resolvedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_impacto>()
                .Property(e => e.sol_impacto_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_impacto>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_impacto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_ocorrencia>()
                .Property(e => e.sol_ocorrencia_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_produto>()
                .Property(e => e.sol_produto_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_produto>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_responsavel>()
                .Property(e => e.sol_responsavel_nome)
                .IsUnicode(false);

            modelBuilder.Entity<sol_responsavel>()
                .Property(e => e.sol_responsavel_cargo)
                .IsUnicode(false);

            modelBuilder.Entity<sol_responsavel>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_responsavel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_solicitacao>()
                .Property(e => e.sol_resumo_solicitacao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitacao>()
                .Property(e => e.sol_justificativa_solicitacao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitacao>()
                .Property(e => e.sol_solicitacao1)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitacao>()
                .Property(e => e.sol_solucao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .Property(e => e.sol_nome)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .Property(e => e.sol_email)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .Property(e => e.sol_foto)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .Property(e => e.sol_telefone)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .Property(e => e.sol_celular)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .Property(e => e.sol_funcao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_solicitante>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_solicitante)
                .HasForeignKey(e => e.sol_solicitante_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_status>()
                .Property(e => e.sol_status_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_status>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_sub_causas>()
                .Property(e => e.sol_sub_causa_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_sub_causas>()
                .HasMany(e => e.sol_solicitacao)
                .WithOptional(e => e.sol_sub_causas)
                .HasForeignKey(e => e.sol_causa_id);

            modelBuilder.Entity<sol_tipo_servico>()
                .Property(e => e.sol_tipo_servico_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_tipo_servico>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_tipo_servico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sol_urgencia>()
                .Property(e => e.sol_urgencia_descricao)
                .IsUnicode(false);

            modelBuilder.Entity<sol_urgencia>()
                .HasMany(e => e.sol_solicitacao)
                .WithRequired(e => e.sol_urgencia)
                .WillCascadeOnDelete(false);
        }
    }
}
