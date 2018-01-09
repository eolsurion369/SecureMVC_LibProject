using System;
using System.Collections.Generic;

namespace WebApplication4.Models.LibraryModels
{
    public partial class MediaTypeFormat
    {
        public string MediaTypeId { get; set; }
        public string MediaFormatId { get; set; }

        public MediaFormat MediaFormat { get; set; }
        public MediaType MediaType { get; set; }
    }
}
