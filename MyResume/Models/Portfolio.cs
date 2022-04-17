using System.ComponentModel.DataAnnotations;

namespace MyResume.Models
{
    
    public class Portfolio
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Picture { get; set; }

        [Required]
        public string? Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }

    }
}

