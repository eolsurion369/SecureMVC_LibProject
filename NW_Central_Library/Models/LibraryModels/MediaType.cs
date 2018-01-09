using System;
using System.Collections.Generic;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class MediaType
    {
        public MediaType()
        {
            MediaCopy = new HashSet<MediaCopy>();
            MediaTypeFormat = new HashSet<MediaTypeFormat>();
            MediaTypeGenre = new HashSet<MediaTypeGenre>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<MediaCopy> MediaCopy { get; set; }
        public ICollection<MediaTypeFormat> MediaTypeFormat { get; set; }
        public ICollection<MediaTypeGenre> MediaTypeGenre { get; set; }
    }
}
