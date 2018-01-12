using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class Media
    {
        public Media()
        {
            MediaContent = new HashSet<MediaContent>();
            MediaCopy = new HashSet<MediaCopy>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? SeriesId { get; set; }
        public string Author { get; set; }
        public int? PublisherId { get; set; }
        public DateTime CopyRightDate { get; set; }
        public string Characteristics { get; set; }
        public string Summary { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public Publisher Publisher { get; set; }
        public Series Series { get; set; }
        public ICollection<MediaContent> MediaContent { get; set; }
        public ICollection<MediaCopy> MediaCopy { get; set; }
    }
}
