using System;
using System.Collections.Generic;

namespace EFModel
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PositiveRate { get; set; }
        public int NegativeRate { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Cover { get; set; }
        public  int CategoryId { get; set; }
        public int AuthorId { get; set; }

        //navigation
        public virtual Category Category { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<AudioFile> AudioFiles { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<TextFile> TextFiles { get; set; }
        public  virtual ICollection<CardMark> RelatedMarks { get; set; }

    }
}
