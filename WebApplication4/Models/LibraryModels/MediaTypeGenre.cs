using System;
using System.Collections.Generic;

namespace WebApplication4.Models.LibraryModels
{
    public partial class MediaTypeGenre
    {
        public string MediaTypeId { get; set; }
        public string GenreId { get; set; }

        public Genre Genre { get; set; }
        public MediaType MediaType { get; set; }
    }
}
