using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class CheckOut
    {
        [Display(Name = "Adult Id")]
        public int AdultId { get; set; }

        [Display(Name = "Juvenile Id")]
        public int? JuvenileId { get; set; }

        [Display(Name = "Media Copy Id")]
        public int MediaCopyId { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Checked In Date")]
        public DateTime? CheckedInDate { get; set; }

        public AdultMember Adult { get; set; }

        [Display(Name = "Media Copy")]
        public MediaCopy MediaCopy { get; set; }
    }
}
