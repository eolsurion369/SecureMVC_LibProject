using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NW_Central_Library.Models.LibraryModels
{
    public class CheckIns
    {
        [Display(Name = "Adult Id")]
        public int AdultId { get; set; }

        [Display(Name = "Juvenile Id")]
        public int? JuvenileId { get; set; }

        [Display(Name = "Media Copy Id")]
        public int MediaCopyId { get; set; }

        [Display(Name = "Checked In Date")]
        public DateTime? CheckedInDate { get; set; }

        public AdultMember Adult { get; set; }

        [Display(Name = "Media Copy")]
        public MediaCopy MediaCopy { get; set; }
    }
}
