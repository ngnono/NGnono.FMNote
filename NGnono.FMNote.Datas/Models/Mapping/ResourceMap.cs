using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGnono.FMNote.Datas.Models.Mapping
{
    public partial class ResourceEntityMap : EntityTypeConfiguration<ResourceEntity>
    {
        public ResourceEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(1024);

            this.Property(t => t.Domain)
                .IsRequired()
                .HasMaxLength(1024);

            this.Property(t => t.Size)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ExtName)
                .IsRequired()
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("Resources");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SourceId).HasColumnName("SourceId");
            this.Property(t => t.SourceType).HasColumnName("SourceType");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Domain).HasColumnName("Domain");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.UpdatedUser).HasColumnName("UpdatedUser");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.ContentSize).HasColumnName("ContentSize");
            this.Property(t => t.ExtName).HasColumnName("ExtName");
			LastInit();
        }

		partial void LastInit();
    }
}
