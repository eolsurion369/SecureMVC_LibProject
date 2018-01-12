using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Media = new HashSet<Media>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<Media> Media { get; set; }
    }
}
