namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMappings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Apelido", c => c.String(maxLength: 255, unicode: false));
            DropColumn("dbo.Usuarios", "Excluido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Excluido", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuarios", "Apelido");
        }
    }
}
