using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class Media
    {
        public Media()
        {
            MediaContent = new HashSet<MediaContent>();
            MediaCopy = new HashSet<MediaCopy>();
        }

        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display (Name = "Series Id")]
        public int? SeriesId { get; set; }

        [Display (Name = "Author")]
        public string Author { get; set; }

        [Display (Name = "Publisher Id")]
        public int? PublisherId { get; set; }

        [Display (Name = "Copyright Date")]
        public DateTime CopyRightDate { get; set; }

        [Display (Name = "Characteristics")]
        public string Characteristics { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Display(Name = "Inactive")]
        public bool? InActive { get; set; }

        [Display(Name = "Inactive Date")]
        public DateTime? InActiveDate { get; set; }

        public Publisher Publisher { get; set; }
        public Series Series { get; set; }
        public ICollection<MediaContent> MediaContent { get; set; }
        public ICollection<MediaCopy> MediaCopy { get; set; }
    }
}
