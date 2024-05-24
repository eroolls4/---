namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class part2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DoctorId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDoctors", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientDoctors", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientDoctors", new[] { "DoctorId" });
            DropIndex("dbo.PatientDoctors", new[] { "PatientId" });
            DropTable("dbo.PatientDoctors");
        }
    }
}
