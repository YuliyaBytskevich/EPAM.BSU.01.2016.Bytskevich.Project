using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel
{
    public class CardMark
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public bool IsPositive { get; set; }

        //navigation 
        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
    }
}
