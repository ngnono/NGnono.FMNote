using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.FMNote.Models.Enums
{
    public enum TagType
    {
        None = 0
    }

    public class TagFilterOptions
    {
        public int? UserId { get; set; }

        public DataStatus? DataStatus { get; set; }
    }

    public enum TagSortOptions
    {
        Default = 0
    }
}
