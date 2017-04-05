namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                        Descricao = c.String(maxLength: 255, unicode: false),
                        Objetivo = c.String(maxLength: 255, unicode: false),
                        IdEvento = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eventos", t => t.IdEvento)
                .Index(t => t.IdEvento);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuarioCriador = c.Int(nullable: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        Descricao = c.String(maxLength: 255, unicode: false),
                        IdEscola = c.Int(nullable: false),
                        DtInicio = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtTermino = c.DateTime(precision: 7, storeType: "datetime2"),
                        NroMinimoVoluntarios = c.Int(),
                        NroMaximoVoluntarios = c.Int(),
                        Ativo = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuarioCriador)
                .ForeignKey("dbo.Escolas", t => t.IdEscola)
                .Index(t => t.IdUsuarioCriador)
                .Index(t => t.IdEscola);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                        Senha = c.String(maxLength: 255, unicode: false),
                        Apelido = c.String(maxLength: 255, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        Telefone = c.String(maxLength: 255, unicode: false),
                        DtNascimento = c.DateTime(precision: 7, storeType: "datetime2"),
                        Profissao = c.String(maxLength: 255, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Excluido = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConviteAprovacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDiretor = c.Int(nullable: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        DtEnvio = c.DateTime(precision: 7, storeType: "datetime2"),
                        DtAceite = c.DateTime(precision: 7, storeType: "datetime2"),
                        ChaveConfirmacao = c.Guid(nullable: false),
                        DiretorAprovado = c.Boolean(),
                        ConviteAceito = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diretores", t => t.IdDiretor)
                .Index(t => t.IdDiretor);
            
            CreateTable(
                "dbo.Escolas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                        IdEndereco = c.Int(nullable: false),
                        IdDiretor = c.Int(nullable: false),
                        AprovacaoAutomaticaVoluntarios = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diretores", t => t.IdDiretor)
                .ForeignKey("dbo.Enderecos", t => t.IdEndereco)
                .Index(t => t.IdEndereco)
                .Index(t => t.IdDiretor);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(maxLength: 255, unicode: false),
                        Complemento = c.String(maxLength: 255, unicode: false),
                        Cidade = c.String(maxLength: 255, unicode: false),
                        Estado = c.String(maxLength: 255, unicode: false),
                        Cep = c.String(maxLength: 255, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habilidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DtCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DtAtualizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EscolaSupervisor",
                c => new
                    {
                        IdEscola = c.Int(nullable: false),
                        IdSupervisor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdEscola, t.IdSupervisor })
                .ForeignKey("dbo.Escolas", t => t.IdEscola)
                .ForeignKey("dbo.Supervisores", t => t.IdSupervisor)
                .Index(t => t.IdEscola)
                .Index(t => t.IdSupervisor);
            
            CreateTable(
                "dbo.EscolaVoluntario",
                c => new
                    {
                        IdVoluntario = c.Int(nullable: false),
                        IdEscola = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdVoluntario, t.IdEscola })
                .ForeignKey("dbo.Voluntarios", t => t.IdVoluntario)
                .ForeignKey("dbo.Escolas", t => t.IdEscola)
                .Index(t => t.IdVoluntario)
                .Index(t => t.IdEscola);
            
            CreateTable(
                "dbo.EventoVoluntario",
                c => new
                    {
                        IdEvento = c.Int(nullable: false),
                        IdEscola = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdEvento, t.IdEscola })
                .ForeignKey("dbo.Voluntarios", t => t.IdEvento)
                .ForeignKey("dbo.Eventos", t => t.IdEscola)
                .Index(t => t.IdEvento)
                .Index(t => t.IdEscola);
            
            CreateTable(
                "dbo.HabilidadeEvento",
                c => new
                    {
                        IdHabilidade = c.Int(nullable: false),
                        IdEvento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdHabilidade, t.IdEvento })
                .ForeignKey("dbo.Habilidades", t => t.IdHabilidade)
                .ForeignKey("dbo.Eventos", t => t.IdEvento)
                .Index(t => t.IdHabilidade)
                .Index(t => t.IdEvento);
            
            CreateTable(
                "dbo.HabilidadeVoluntario",
                c => new
                    {
                        IdHabilidade = c.Int(nullable: false),
                        IdVoluntario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdHabilidade, t.IdVoluntario })
                .ForeignKey("dbo.Habilidades", t => t.IdHabilidade)
                .ForeignKey("dbo.Voluntarios", t => t.IdVoluntario)
                .Index(t => t.IdHabilidade)
                .Index(t => t.IdVoluntario);
            
            CreateTable(
                "dbo.EventoSupervisor",
                c => new
                    {
                        IdEvento = c.Int(nullable: false),
                        IdSupervisor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdEvento, t.IdSupervisor })
                .ForeignKey("dbo.Eventos", t => t.IdEvento)
                .ForeignKey("dbo.Supervisores", t => t.IdSupervisor)
                .Index(t => t.IdEvento)
                .Index(t => t.IdSupervisor);
            
            CreateTable(
                "dbo.Diretores",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                        Aprovado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Supervisores",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Voluntarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                        IdEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .ForeignKey("dbo.Enderecos", t => t.IdEndereco)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdEndereco);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voluntarios", "IdEndereco", "dbo.Enderecos");
            DropForeignKey("dbo.Voluntarios", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Supervisores", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Diretores", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Acoes", "IdEvento", "dbo.Eventos");
            DropForeignKey("dbo.EventoSupervisor", "IdSupervisor", "dbo.Supervisores");
            DropForeignKey("dbo.EventoSupervisor", "IdEvento", "dbo.Eventos");
            DropForeignKey("dbo.Eventos", "IdEscola", "dbo.Escolas");
            DropForeignKey("dbo.Eventos", "IdUsuarioCriador", "dbo.Usuarios");
            DropForeignKey("dbo.HabilidadeVoluntario", "IdVoluntario", "dbo.Voluntarios");
            DropForeignKey("dbo.HabilidadeVoluntario", "IdHabilidade", "dbo.Habilidades");
            DropForeignKey("dbo.HabilidadeEvento", "IdEvento", "dbo.Eventos");
            DropForeignKey("dbo.HabilidadeEvento", "IdHabilidade", "dbo.Habilidades");
            DropForeignKey("dbo.EventoVoluntario", "IdEscola", "dbo.Eventos");
            DropForeignKey("dbo.EventoVoluntario", "IdEvento", "dbo.Voluntarios");
            DropForeignKey("dbo.EscolaVoluntario", "IdEscola", "dbo.Escolas");
            DropForeignKey("dbo.EscolaVoluntario", "IdVoluntario", "dbo.Voluntarios");
            DropForeignKey("dbo.EscolaSupervisor", "IdSupervisor", "dbo.Supervisores");
            DropForeignKey("dbo.EscolaSupervisor", "IdEscola", "dbo.Escolas");
            DropForeignKey("dbo.Escolas", "IdEndereco", "dbo.Enderecos");
            DropForeignKey("dbo.Escolas", "IdDiretor", "dbo.Diretores");
            DropForeignKey("dbo.ConviteAprovacao", "IdDiretor", "dbo.Diretores");
            DropIndex("dbo.Voluntarios", new[] { "IdEndereco" });
            DropIndex("dbo.Voluntarios", new[] { "IdUsuario" });
            DropIndex("dbo.Supervisores", new[] { "IdUsuario" });
            DropIndex("dbo.Diretores", new[] { "IdUsuario" });
            DropIndex("dbo.EventoSupervisor", new[] { "IdSupervisor" });
            DropIndex("dbo.EventoSupervisor", new[] { "IdEvento" });
            DropIndex("dbo.HabilidadeVoluntario", new[] { "IdVoluntario" });
            DropIndex("dbo.HabilidadeVoluntario", new[] { "IdHabilidade" });
            DropIndex("dbo.HabilidadeEvento", new[] { "IdEvento" });
            DropIndex("dbo.HabilidadeEvento", new[] { "IdHabilidade" });
            DropIndex("dbo.EventoVoluntario", new[] { "IdEscola" });
            DropIndex("dbo.EventoVoluntario", new[] { "IdEvento" });
            DropIndex("dbo.EscolaVoluntario", new[] { "IdEscola" });
            DropIndex("dbo.EscolaVoluntario", new[] { "IdVoluntario" });
            DropIndex("dbo.EscolaSupervisor", new[] { "IdSupervisor" });
            DropIndex("dbo.EscolaSupervisor", new[] { "IdEscola" });
            DropIndex("dbo.Escolas", new[] { "IdDiretor" });
            DropIndex("dbo.Escolas", new[] { "IdEndereco" });
            DropIndex("dbo.ConviteAprovacao", new[] { "IdDiretor" });
            DropIndex("dbo.Eventos", new[] { "IdEscola" });
            DropIndex("dbo.Eventos", new[] { "IdUsuarioCriador" });
            DropIndex("dbo.Acoes", new[] { "IdEvento" });
            DropTable("dbo.Voluntarios");
            DropTable("dbo.Supervisores");
            DropTable("dbo.Diretores");
            DropTable("dbo.EventoSupervisor");
            DropTable("dbo.HabilidadeVoluntario");
            DropTable("dbo.HabilidadeEvento");
            DropTable("dbo.EventoVoluntario");
            DropTable("dbo.EscolaVoluntario");
            DropTable("dbo.EscolaSupervisor");
            DropTable("dbo.Habilidades");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Escolas");
            DropTable("dbo.ConviteAprovacao");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Eventos");
            DropTable("dbo.Acoes");
        }
    }
}
