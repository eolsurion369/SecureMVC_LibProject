using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class MediaContent
    {
        public int ContentId { get; set; }
        public int MediaId { get; set; }
        public int ContentItemOrder { get; set; }
        public string ContentItem { get; set; }

        public Media Media { get; set; }
    }
}
