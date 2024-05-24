namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jasdii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Gender");
        }
    }
}
