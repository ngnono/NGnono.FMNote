using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGnono.FMNote.Datas.Models.Mapping
{
    public partial class BillTagRelationEntityMap : EntityTypeConfiguration<BillTagRelationEntity>
    {
        public BillTagRelationEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("BillTagRelations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Bill_Id).HasColumnName("Bill_Id");
            this.Property(t => t.Tag_Id).HasColumnName("Tag_Id");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
			LastInit();
        }

		partial void LastInit();
    }
}
