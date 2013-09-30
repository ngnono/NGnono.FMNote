using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.FMNote.Models.Enums
{
    public enum CategoryType
    {
        None = 0
    }

    public class CategoryFilterOptions
    {
        public int? UserId { get; set; }

        public DataStatus? DataStatus { get; set; }
    }

    public enum CategorySortOptions
    {
        Default = 0
    }
}
