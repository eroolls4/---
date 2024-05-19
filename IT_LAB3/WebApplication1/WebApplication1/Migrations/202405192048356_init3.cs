namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hospitals", "HospitalImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hospitals", "HospitalImage", c => c.String(nullable: false));
        }
    }
}
