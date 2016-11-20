namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConvite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConviteAprovacao", "DtAceite", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ConviteAprovacao", "DiretorAprovado", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConviteAprovacao", "DiretorAprovado", c => c.Boolean(nullable: false));
            DropColumn("dbo.ConviteAprovacao", "DtAceite");
        }
    }
}
