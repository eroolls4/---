namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "HospitalImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hospitals", "HospitalImage");
        }
    }
}
