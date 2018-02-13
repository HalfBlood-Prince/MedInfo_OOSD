using System.Data.Entity.ModelConfiguration;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Persistence.EntityConfiguration
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>    
    {
        public CommentConfiguration()
        {
            //Primary Key
            HasKey(c => c.Id);

            #region Properties

            Property(c => c.PostComment)
                .IsRequired()
                .HasMaxLength(255);

            #endregion

            #region Relationship

            HasRequired(c => c.ApplicationUser)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ApplicationUserId);

            #endregion
        }
    }
}