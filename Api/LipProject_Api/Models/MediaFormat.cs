using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class MediaFormat
    {
        public MediaFormat()
        {
            MediaCopy = new HashSet<MediaCopy>();
            MediaTypeFormat = new HashSet<MediaTypeFormat>();
        }

        public string Id { get; set; }
        public string Format { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<MediaCopy> MediaCopy { get; set; }
        public ICollection<MediaTypeFormat> MediaTypeFormat { get; set; }
    }
}
