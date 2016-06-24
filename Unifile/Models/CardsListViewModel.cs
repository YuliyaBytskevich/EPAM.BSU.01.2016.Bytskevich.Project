using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unifile.Models.MvcModel;

namespace Unifile.Models
{
    public class CardsListViewModel
    {
        public IEnumerable<MvcCard> Cards { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}