using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Prizes :CollectionBase
    {
        public Prize this[int index]
        {
            get { return (Prize)List[index]; }
            set { List[index] = value; }
        }

        public void add(Prize prize)
        {
            List.Add(prize);
        }
    }
}
