using System;
using System.Collections.Generic;

namespace WebApplication4.Models.LibraryModels
{
    public partial class CheckOut
    {
        public int AdultId { get; set; }
        public int? JuvenileId { get; set; }
        public int MediaCopyId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CheckedInDate { get; set; }

        public AdultMember Adult { get; set; }
        public MediaCopy MediaCopy { get; set; }
    }
}
