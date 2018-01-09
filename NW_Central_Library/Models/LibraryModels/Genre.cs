using System;
using System.Collections.Generic;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class Genre
    {
        public Genre()
        {
            MediaCopy = new HashSet<MediaCopy>();
            MediaTypeGenre = new HashSet<MediaTypeGenre>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<MediaCopy> MediaCopy { get; set; }
        public ICollection<MediaTypeGenre> MediaTypeGenre { get; set; }
    }
}
