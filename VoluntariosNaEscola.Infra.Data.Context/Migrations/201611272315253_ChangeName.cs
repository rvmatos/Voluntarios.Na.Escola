namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventos", "DtTermino", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Eventos", "DtTerminino");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eventos", "DtTerminino", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Eventos", "DtTermino");
        }
    }
}
