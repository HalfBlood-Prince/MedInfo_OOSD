using System.Data.Entity;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Persistence.EntityConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MedInfo_OOSD.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DoctorConfiguration());
            modelBuilder.Configurations.Add(new HospitalConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}