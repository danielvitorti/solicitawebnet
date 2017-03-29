namespace solicita_web_net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.sol_solicitacao", "sol_causa_id", "dbo.sol_causas");
            DropForeignKey("dbo.sol_solicitacao", "sol_classificacao_id", "dbo.sol_classificacao");
            DropForeignKey("dbo.sol_solicitacao", "sol_grupo_resolvedor_id", "dbo.sol_grupo_resolvedor");
            DropForeignKey("dbo.sol_solicitacao", "sol_impacto_id", "dbo.sol_impacto");
            DropForeignKey("dbo.sol_solicitacao", "sol_produto_id", "dbo.sol_produto");
            DropForeignKey("dbo.sol_solicitacao", "sol_responsavel_id", "dbo.sol_responsavel");
            DropForeignKey("dbo.sol_solicitacao", "sol_solicitante_id", "dbo.sol_solicitante");
            DropForeignKey("dbo.sol_solicitacao", "sol_status_id", "dbo.sol_status");
            DropForeignKey("dbo.sol_solicitacao", "sol_causa_id", "dbo.sol_sub_causas");
            DropForeignKey("dbo.sol_solicitacao", "sol_tipo_servico_id", "dbo.sol_tipo_servico");
            DropForeignKey("dbo.sol_solicitacao", "sol_urgencia_id", "dbo.sol_urgencia");
            DropForeignKey("dbo.sol_solicitacao", "sol_categoria_servico_id", "dbo.sol_categoria_servico");
            DropIndex("dbo.sol_solicitacao", new[] { "sol_status_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_solicitante_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_tipo_servico_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_categoria_servico_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_urgencia_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_impacto_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_classificacao_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_produto_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_responsavel_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_grupo_resolvedor_id" });
            DropIndex("dbo.sol_solicitacao", new[] { "sol_causa_id" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.sol_anexos");
            DropTable("dbo.sol_categoria_servico");
            DropTable("dbo.sol_solicitacao");
            DropTable("dbo.sol_causas");
            DropTable("dbo.sol_classificacao");
            DropTable("dbo.sol_grupo_resolvedor");
            DropTable("dbo.sol_impacto");
            DropTable("dbo.sol_produto");
            DropTable("dbo.sol_responsavel");
            DropTable("dbo.sol_solicitante");
            DropTable("dbo.sol_status");
            DropTable("dbo.sol_sub_causas");
            DropTable("dbo.sol_tipo_servico");
            DropTable("dbo.sol_urgencia");
            DropTable("dbo.sol_comentario");
            DropTable("dbo.sol_ocorrencia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.sol_ocorrencia",
                c => new
                    {
                        sol_ocorrencia_id = c.Short(nullable: false, identity: true),
                        sol_ocorrencia_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_ocorrencia_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_ocorrencia_id);
            
            CreateTable(
                "dbo.sol_comentario",
                c => new
                    {
                        sol_comentario_id = c.Int(nullable: false, identity: true),
                        sol_solicitacao_id = c.Long(nullable: false),
                        sol_descricao_comentario = c.String(nullable: false, unicode: false, storeType: "text"),
                        sol_status_id = c.Int(nullable: false),
                        sol_responsavel_id = c.Int(nullable: false),
                        sol_comentario_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_comentario_id);
            
            CreateTable(
                "dbo.sol_urgencia",
                c => new
                    {
                        sol_urgencia_id = c.Int(nullable: false, identity: true),
                        sol_urgencia_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_urgencia_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_urgencia_id);
            
            CreateTable(
                "dbo.sol_tipo_servico",
                c => new
                    {
                        sol_tipo_servico_id = c.Int(nullable: false, identity: true),
                        sol_tipo_servico_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_tipo_servico_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_tipo_servico_id);
            
            CreateTable(
                "dbo.sol_sub_causas",
                c => new
                    {
                        sol_sub_causa_id = c.Int(nullable: false, identity: true),
                        sol_causa_id = c.Int(nullable: false),
                        sol_sub_causa_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_sub_causa_data_cadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.sol_sub_causa_id);
            
            CreateTable(
                "dbo.sol_status",
                c => new
                    {
                        sol_status_id = c.Int(nullable: false, identity: true),
                        sol_status_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_status_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_status_id);
            
            CreateTable(
                "dbo.sol_solicitante",
                c => new
                    {
                        sol_id = c.Int(nullable: false, identity: true),
                        sol_nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_email = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_foto = c.String(maxLength: 100, unicode: false),
                        sol_telefone = c.String(maxLength: 20, unicode: false),
                        sol_celular = c.String(maxLength: 20, unicode: false),
                        sol_funcao = c.String(nullable: false, maxLength: 200, unicode: false),
                        sol_data_cadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.sol_id);
            
            CreateTable(
                "dbo.sol_responsavel",
                c => new
                    {
                        sol_responsavel_id = c.Int(nullable: false, identity: true),
                        sol_responsavel_nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_responsavel_cargo = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_responsavel_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_responsavel_id);
            
            CreateTable(
                "dbo.sol_produto",
                c => new
                    {
                        sol_produto_id = c.Int(nullable: false, identity: true),
                        sol_produto_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_produto_data_cadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.sol_produto_id);
            
            CreateTable(
                "dbo.sol_impacto",
                c => new
                    {
                        sol_impacto_id = c.Int(nullable: false, identity: true),
                        sol_impacto_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_impacto_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_impacto_id);
            
            CreateTable(
                "dbo.sol_grupo_resolvedor",
                c => new
                    {
                        sol_grupo_resolvedor_id = c.Int(nullable: false, identity: true),
                        sol_grupo_resolvedor_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_grupo_resolvedor_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_grupo_resolvedor_id);
            
            CreateTable(
                "dbo.sol_classificacao",
                c => new
                    {
                        sol_classificacao_id = c.Int(nullable: false, identity: true),
                        sol_classificacao_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_classificacao_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_classificacao_id);
            
            CreateTable(
                "dbo.sol_causas",
                c => new
                    {
                        sol_causa_id = c.Int(nullable: false, identity: true),
                        sol_causa_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_causa_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_causa_id);
            
            CreateTable(
                "dbo.sol_solicitacao",
                c => new
                    {
                        sol_solicitacao_id = c.Long(nullable: false, identity: true),
                        sol_status_id = c.Int(nullable: false),
                        sol_solicitante_id = c.Int(nullable: false),
                        sol_tipo_servico_id = c.Int(nullable: false),
                        sol_categoria_servico_id = c.Int(nullable: false),
                        sol_urgencia_id = c.Int(nullable: false),
                        sol_impacto_id = c.Int(nullable: false),
                        sol_classificacao_id = c.Int(nullable: false),
                        sol_produto_id = c.Int(nullable: false),
                        sol_responsavel_id = c.Int(nullable: false),
                        sol_grupo_resolvedor_id = c.Int(nullable: false),
                        sol_causa_id = c.Int(),
                        sol_sub_causa_id = c.Int(),
                        sol_resumo_solicitacao = c.String(nullable: false, unicode: false, storeType: "text"),
                        sol_justificativa_solicitacao = c.String(nullable: false, unicode: false, storeType: "text"),
                        sol_solicitacao = c.String(nullable: false, unicode: false, storeType: "text"),
                        sol_solucao = c.String(nullable: false, unicode: false, storeType: "text"),
                        sol_tempo = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.sol_solicitacao_id);
            
            CreateTable(
                "dbo.sol_categoria_servico",
                c => new
                    {
                        sol_categoria_servico_id = c.Int(nullable: false, identity: true),
                        sol_categoria_servico_descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        sol_categoria_servico_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_categoria_servico_id);
            
            CreateTable(
                "dbo.sol_anexos",
                c => new
                    {
                        sol_anexos_id = c.Long(nullable: false, identity: true),
                        sol_solicitacao_id = c.Long(nullable: false),
                        sol_arquivo_anexo = c.String(nullable: false, unicode: false, storeType: "text"),
                        sol_arquivo_anexo_data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sol_anexos_id);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.sol_solicitacao", "sol_causa_id");
            CreateIndex("dbo.sol_solicitacao", "sol_grupo_resolvedor_id");
            CreateIndex("dbo.sol_solicitacao", "sol_responsavel_id");
            CreateIndex("dbo.sol_solicitacao", "sol_produto_id");
            CreateIndex("dbo.sol_solicitacao", "sol_classificacao_id");
            CreateIndex("dbo.sol_solicitacao", "sol_impacto_id");
            CreateIndex("dbo.sol_solicitacao", "sol_urgencia_id");
            CreateIndex("dbo.sol_solicitacao", "sol_categoria_servico_id");
            CreateIndex("dbo.sol_solicitacao", "sol_tipo_servico_id");
            CreateIndex("dbo.sol_solicitacao", "sol_solicitante_id");
            CreateIndex("dbo.sol_solicitacao", "sol_status_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_categoria_servico_id", "dbo.sol_categoria_servico", "sol_categoria_servico_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_urgencia_id", "dbo.sol_urgencia", "sol_urgencia_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_tipo_servico_id", "dbo.sol_tipo_servico", "sol_tipo_servico_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_causa_id", "dbo.sol_sub_causas", "sol_sub_causa_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_status_id", "dbo.sol_status", "sol_status_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_solicitante_id", "dbo.sol_solicitante", "sol_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_responsavel_id", "dbo.sol_responsavel", "sol_responsavel_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_produto_id", "dbo.sol_produto", "sol_produto_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_impacto_id", "dbo.sol_impacto", "sol_impacto_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_grupo_resolvedor_id", "dbo.sol_grupo_resolvedor", "sol_grupo_resolvedor_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_classificacao_id", "dbo.sol_classificacao", "sol_classificacao_id");
            AddForeignKey("dbo.sol_solicitacao", "sol_causa_id", "dbo.sol_causas", "sol_causa_id");
        }
    }
}
