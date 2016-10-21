namespace VoluntariosNaEscola.Infra.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNomeConviteAprovacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConviteAprovacao", "Nome", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConviteAprovacao", "Nome");
        }
    }
}
