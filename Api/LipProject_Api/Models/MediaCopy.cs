using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class MediaCopy
    {
        public MediaCopy()
        {
            CheckOut = new HashSet<CheckOut>();
        }

        public int Id { get; set; }
        public int MediaId { get; set; }
        public string MediaTypeId { get; set; }
        public string MediaGenreId { get; set; }
        public string MediaFormatId { get; set; }
        public int CopyNumber { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public Media Media { get; set; }
        public MediaFormat MediaFormat { get; set; }
        public Genre MediaGenre { get; set; }
        public MediaType MediaType { get; set; }
        public ICollection<CheckOut> CheckOut { get; set; }
    }
}
