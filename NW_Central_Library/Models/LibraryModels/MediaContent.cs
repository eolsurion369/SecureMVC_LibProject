using System;
using System.Collections.Generic;

namespace NW_Central_Library.Models.LibraryModels
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
