using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGnono.FMNote.Datas.Models.Mapping
{
    public partial class PriceSettingEntityMap : EntityTypeConfiguration<PriceSettingEntity>
    {
        public PriceSettingEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PriceSetting");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.SourceId).HasColumnName("SourceId");
            this.Property(t => t.SourceType).HasColumnName("SourceType");
            this.Property(t => t.SourceDate).HasColumnName("SourceDate");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedUser).HasColumnName("UpdatedUser");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.PriceSettings)
                .HasForeignKey(d => d.SourceId);

			LastInit();
        }

		partial void LastInit();
    }
}
