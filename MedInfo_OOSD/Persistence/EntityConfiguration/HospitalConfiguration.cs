using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Persistence.EntityConfiguration
{
    public class HospitalConfiguration : EntityTypeConfiguration<Hospital>
    {

        public HospitalConfiguration()
        {
            //Primary Key
            HasKey(h => h.Id);

            #region Properties

            Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(255);


            Property(d => d.DoesHaveEmergencyWard)
                .IsRequired();

            Property(d => d.HospitalAddress)
                .IsRequired()
                .HasMaxLength(255);

            #endregion

            #region Relationships

            HasRequired(d => d.ApplicationUser)
                .WithMany(u => u.Hospitals)
                .HasForeignKey(d => d.ApplicationUserId);

            HasRequired(h => h.Speciality)
                .WithMany(s => s.Hospitals)
                .HasForeignKey(h => h.SpecialityId)
                .WillCascadeOnDelete(false);



            #endregion
        }
    }
}