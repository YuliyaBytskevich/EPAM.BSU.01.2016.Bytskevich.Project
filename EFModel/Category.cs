using System.Collections.Generic;

namespace EFModel
{
    public class Category
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        // navigation
        public virtual ICollection<Card> Cards { get; set; }

    }
}
