namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class part5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "HospitalId", c => c.Int());
            CreateIndex("dbo.Doctors", "HospitalId");
            AddForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals");
            DropIndex("dbo.Doctors", new[] { "HospitalId" });
            DropColumn("dbo.Doctors", "HospitalId");
        }
    }
}
