using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterface.DALModel
{
    public class DalAudioFile: DalEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }
        public int GenreId { get; set; }
        public int CardId { get; set; }
    }
}
