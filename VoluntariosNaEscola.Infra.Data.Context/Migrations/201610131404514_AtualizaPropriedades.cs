namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizaPropriedades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Diretores", "IdEndereco", "dbo.Enderecos");
            DropIndex("dbo.Diretores", new[] { "IdEndereco" });
            AlterColumn("dbo.Usuarios", "DtNascimento", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Diretores", "IdEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diretores", "IdEndereco", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "DtNascimento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            CreateIndex("dbo.Diretores", "IdEndereco");
            AddForeignKey("dbo.Diretores", "IdEndereco", "dbo.Enderecos", "Id");
        }
    }
}
