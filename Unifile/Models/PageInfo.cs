using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unifile.Models
{
    public class PageInfo
    {
        public int CurrentPageNumber { get; set; } 
        public int PageCapacity { get; set; } 
        public int TotalNumOfItems { get; set; } 
        public int TotalNumOfPages => (int)Math.Ceiling((decimal)TotalNumOfItems / PageCapacity);
    }
}