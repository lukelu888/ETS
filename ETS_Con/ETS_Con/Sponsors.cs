using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Con
{
    class Sponsors:CollectionBase
    {
        public Sponsor this[int index]
        {
            get { return (Sponsor)List[index]; }
            set { List[index] = value; }
        }

        public void add(Sponsor sponsor)
        {
            List.Add(sponsor);
        }

    }
}
