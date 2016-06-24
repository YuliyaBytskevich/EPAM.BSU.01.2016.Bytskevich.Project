using System;
using System.ComponentModel.DataAnnotations;

namespace Unifile.Models.MvcModel
{
    public class MvcCard
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        //[Remote()]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        public string Description { get; set; }
        [Display (Name = "Date of creation")]
        [DataType(DataType.DateTime)]
        public string DateOfCreation { get; set; }
        [Required]
        public string Author { get; set; }
        public string Cover { get; set; }
        [Range(0, int.MaxValue)]
        public int PositiveRate { get; set; }
        [Range(int.MinValue, 0)]
        public int NegativeRate { get; set; }
        
    }
}