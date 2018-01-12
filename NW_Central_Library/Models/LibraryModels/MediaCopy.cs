using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class MediaCopy
    {
        public MediaCopy()
        {
            CheckOut = new HashSet<CheckOut>();
        }

        public int Id { get; set; }

        [Display(Name = "Media Id")]
        public int MediaId { get; set; }

        [Display(Name = "Media Type Id")]
        public string MediaTypeId { get; set; }

        [Display(Name = "Media Genre Id")]
        public string MediaGenreId { get; set; }

        [Display(Name = "Media Format Id")]
        public string MediaFormatId { get; set; }

        [Display(Name = "Copy Number")]
        public int CopyNumber { get; set; }

        [Display(Name = "Inactive")]
        public bool? InActive { get; set; }

        [Display(Name = "Inactive Date")]
        public DateTime? InActiveDate { get; set; }

        public Media Media { get; set; }
        public MediaFormat MediaFormat { get; set; }
        public Genre MediaGenre { get; set; }
        public MediaType MediaType { get; set; }
        public ICollection<CheckOut> CheckOut { get; set; }
    }
}
