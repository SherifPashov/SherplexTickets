﻿using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.AuthorConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Books
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string FullName { get; set; } = string.Empty;
    }
}