using System.ComponentModel.DataAnnotations;

namespace Unifile.Models.MvcModel
{
    public class MvcCategory
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}