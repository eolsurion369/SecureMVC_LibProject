using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class AdultMemberAddress
    {
        [Display(Name = "Adult ID")]
        public int AdultId { get; set; }

        [Display(Name = "Address Id")]
        public int AddressId { get; set; }

        [Display(Name = "Inactive")]
        public bool? InActive { get; set; }

        [Display(Name = "Inactive Date")]
        public DateTime? InActiveDate { get; set; }

        public Address Address { get; set; }
        public AdultMember Adult { get; set; }
    }
}
