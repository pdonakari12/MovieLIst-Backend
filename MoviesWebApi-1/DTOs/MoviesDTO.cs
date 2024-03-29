﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi_1.DTOs
{
    public class MoviesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public string Tailer { get; set; }

        public bool InTheaters { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Poster { get; set; }
        public List<GenreDTO> Genres  { get; set; }

        public List<MovieTheaterDTO> MovieTheaters { get; set; }

        public List<ActorsMovieDTO> Actors { get; set; }
        public double AverageVote { get; set; }

        public int UserVote { get; set; }
    }
}
