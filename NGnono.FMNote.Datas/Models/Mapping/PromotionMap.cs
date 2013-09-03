using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGnono.FMNote.Datas.Models.Mapping
{
    public partial class PromotionEntityMap : EntityTypeConfiguration<PromotionEntity>
    {
        public PromotionEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Promotion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.UpdatedUser).HasColumnName("UpdatedUser");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.LikeCount).HasColumnName("LikeCount");
            this.Property(t => t.FavoriteCount).HasColumnName("FavoriteCount");
            this.Property(t => t.ShareCount).HasColumnName("ShareCount");
            this.Property(t => t.InvolvedCount).HasColumnName("InvolvedCount");
            this.Property(t => t.Store_Id).HasColumnName("Store_Id");
            this.Property(t => t.RecommendUser).HasColumnName("RecommendUser");
            this.Property(t => t.RecommendSourceId).HasColumnName("RecommendSourceId");
            this.Property(t => t.RecommendSourceType).HasColumnName("RecommendSourceType");
            this.Property(t => t.Tag_Id).HasColumnName("Tag_Id");
            this.Property(t => t.IsTop).HasColumnName("IsTop");
            this.Property(t => t.IsProdBindable).HasColumnName("IsProdBindable");
            this.Property(t => t.PublicationLimit).HasColumnName("PublicationLimit");
        }
    }
}
