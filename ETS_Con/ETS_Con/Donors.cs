using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Con
{
    class Donors:CollectionBase
    {
        public Donor this[int index]
        {
            get { return (Donor)List[index]; }
            set { List[index] = value; }
        }
        public void add(Donor donor)
        {
            List.Add(donor);
        }
        public void remove(string donorId)
        {
            for (int i = 0; i < this.Count; i++) // or List.Count
            {
                if (this[i].GetId() == donorId)
                {
                    this.RemoveAt(i);
                }
            }
        }
    }
}
