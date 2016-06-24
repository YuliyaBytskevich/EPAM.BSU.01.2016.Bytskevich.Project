using System.ComponentModel.DataAnnotations;

namespace Unifile.Models.MvcModel
{
    public class MvcAudioFile: MvcAttachmentEntity
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }

    }
}