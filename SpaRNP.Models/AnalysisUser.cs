using System;
using System.ComponentModel.DataAnnotations;

namespace SpaRNP.Models
{
    public class AnalysisUser
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisteredAt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ActiveAt { get; set; }
    }
}
