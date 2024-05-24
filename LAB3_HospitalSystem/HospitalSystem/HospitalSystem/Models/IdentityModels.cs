using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalSystem.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HospitalSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

       public  DbSet<Doctor> Doctors { get; set; }
       public   DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientDoctor> PatientsDoctors { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDoctor>()
                .HasKey(pd => new { pd.PatientId, pd.DoctorId });

            modelBuilder.Entity<PatientDoctor>()
                           .HasRequired(pd => pd.Patient)
                           .WithMany(p => p.Doctors)
                          .HasForeignKey(pd => pd.PatientId)
                           .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientDoctor>()
                        .HasRequired(pd => pd.Doctor)
                        .WithMany(d => d.Patients)
                        .HasForeignKey(pd => pd.DoctorId)
                        .WillCascadeOnDelete(false);



            modelBuilder.Entity<Doctor>()
                .HasOptional(d => d.Hospital)
                .WithMany( h => h.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}