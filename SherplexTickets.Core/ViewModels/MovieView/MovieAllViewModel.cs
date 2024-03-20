﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.ViewModels.MovieView
{
    public class MovieAllViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;
        public string YoutubeTrailerUrl { get; set; } = string.Empty;

        public string ReleaseDate { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;
    }
}
