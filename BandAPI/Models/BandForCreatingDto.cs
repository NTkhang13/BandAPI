using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BandAPI.Models
{
    public class BandForCreatingDto
    {
        public string Name { get; set; }
        public string Founded { get; set; }
        public string MainGener { get; set; }

        public ICollection<AlbumForCreatingDto> Album { get; set; } = new List<AlbumForCreatingDto>(); 
    }
}
