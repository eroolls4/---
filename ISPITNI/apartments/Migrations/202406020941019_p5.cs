namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Apartmen", newName: "Apartments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Apartments", newName: "Apartmen");
        }
    }
}
