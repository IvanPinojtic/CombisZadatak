namespace CombisApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Podaci", "PostanskiBroj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Podaci", "PostanskiBroj", c => c.String(maxLength: 5));
        }
    }
}
