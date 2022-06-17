using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi_1.DTOs
{
    public class LandingPageDTO
    {
        public List<MoviesDTO> InTheaters { get; set; }
        public List<MoviesDTO> UpcomingReleases { get; set; }
    }
}
