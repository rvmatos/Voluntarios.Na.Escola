namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "DtNascimento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Usuarios", "Idade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Idade", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "DtNascimento");
        }
    }
}
