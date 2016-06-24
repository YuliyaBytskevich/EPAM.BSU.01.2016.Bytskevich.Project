using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unifile.Models.MvcModel;

namespace Unifile.Models
{
    public class FullCardViewModel
    {
        public MvcCard Main { get; set; }
        public IEnumerable<MvcAudioFile> AttachedAudios { get; set; }
        public IEnumerable<MvcImage> AttachedImages { get; set; }
        public IEnumerable<MvcTextFile> AttachedTexts { get; set; }
    }
}