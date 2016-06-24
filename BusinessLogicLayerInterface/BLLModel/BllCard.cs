using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterface.BLLModel
{
    public class BllCard: BllEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Cover { get; set; }
        public int PositiveRate { get; set; }
        public int NegativeRate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
