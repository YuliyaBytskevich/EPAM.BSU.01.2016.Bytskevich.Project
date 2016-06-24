using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterface.DALModel
{
    public class DalCardMark: DalEntity
    {
        public int UserId { get; set; }
        public int CardId { get; set; }
        public bool IsPositive { get; set; }
    }
}
