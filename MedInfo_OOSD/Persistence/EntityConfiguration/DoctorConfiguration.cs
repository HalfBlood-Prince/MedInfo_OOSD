using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Persistence.EntityConfiguration
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
            HasKey(d => d.Id);

            #region Properties

            Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Name)
                .HasMaxLength(255)
                .IsRequired();

            Property(d => d.ChemberAddress)
                .IsRequired()
                .HasMaxLength(255);

            Property(d => d.AvailableDays)
                .HasMaxLength(100)
                .IsRequired();

            Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(255);

            #endregion

            #region Relationships

            HasRequired(d => d.Speciality)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialityId)
                .WillCascadeOnDelete(false);

            HasRequired(d => d.ApplicationUser)
                .WithMany(u => u.Doctors)
                .HasForeignKey(d => d.ApplicationUserId);

            #endregion
        }
    }
}