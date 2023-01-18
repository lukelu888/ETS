using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Con
{
    class Donations :CollectionBase
    {
        public Donation this[int index]
        {
            get { return (Donation)List[index]; }
            set { List[index] = value; }
        }

        public void add(Donation donation)
        {
            List.Add(donation);
        }
    }
}
