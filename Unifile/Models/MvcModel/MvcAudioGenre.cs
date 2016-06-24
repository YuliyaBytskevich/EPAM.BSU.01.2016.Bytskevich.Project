using System.ComponentModel.DataAnnotations;

namespace Unifile.Models.MvcModel
{
    public class MvcAudioGenre
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        //[Remote()]
        public string Name { get; set; }
    }
}