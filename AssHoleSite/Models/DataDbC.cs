using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssHoleSite.Models
{
    public class DataDbC
    {
        public IEnumerable<PhoneC> PhoneM { get; set; }
        public IEnumerable<CategoryC> CategoryM { get; set; }
    }
}
