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

    public class BloodBankConfiguration : EntityTypeConfiguration<BloodBank>
    {
        public BloodBankConfiguration()
        {
            HasKey(b => b.Id);

            #region Properties

            Property(b => b.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(b => b.Name)
                .HasMaxLength(255)
                .IsRequired();

            Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(255);

            Property(b => b.AvailableDays)
                .IsRequired()
                .HasMaxLength(255);

            Property(b => b.Email)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Relationships

            HasRequired(b => b.ApplicationUser)
                .WithMany(a => a.BloodBanks)
                .HasForeignKey(b => b.ApplicationUserId);

            #endregion
        }
    }
}