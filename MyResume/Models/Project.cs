﻿using System.ComponentModel.DataAnnotations;

namespace MyResume.Models
{
    
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Pictrue { get; set; }

        [Required]
        public string? Body { get; set; }

        [Required]
        public string? Period { get; set; }

        public string? Tags { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }

    }
}

