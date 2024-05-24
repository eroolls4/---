namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class part4 : DbMigration
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
