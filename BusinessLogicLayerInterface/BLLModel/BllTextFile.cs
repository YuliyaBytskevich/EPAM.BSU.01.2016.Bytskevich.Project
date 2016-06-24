using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterface.BLLModel
{
    public class BllTextFile: BllEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }
        public int CardId { get; set; }
    }
}
