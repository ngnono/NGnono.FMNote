using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGnono.FMNote.Datas.Models.Mapping
{
    public partial class BillEntityMap : EntityTypeConfiguration<BillEntity>
    {
        public BillEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(1024);

            this.Property(t => t.ExtendedContent)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Bill");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Mode).HasColumnName("Mode");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Category_Id).HasColumnName("Category_Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DataDateTime).HasColumnName("DataDateTime");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.UpdatedUser).HasColumnName("UpdatedUser");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.ExtendedContentType).HasColumnName("ExtendedContentType");
            this.Property(t => t.ExtendedContent).HasColumnName("ExtendedContent");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Bills)
                .HasForeignKey(d => d.Category_Id);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Bills)
                .HasForeignKey(d => d.User_Id);

            LastInit();
        }

        partial void LastInit();
    }
}
