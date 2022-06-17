﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi_1.DTOs
{
    public class MovieTheaterCreationDTO
    {
        [Required]
        [StringLength(maximumLength:75)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(-90,90)]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        public double Longitude { get; set; }
    }
}
