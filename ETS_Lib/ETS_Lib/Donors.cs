using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ETS_Lib.Paths;
using System.Windows.Forms;

namespace ETS_Lib
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
        public bool remove(string donorId)
        {
            for (int i = 0; i < this.Count; i++) // or List.Count
            {
                if (this[i].GetId() == donorId)
                {
                    this.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool ReadDonors()
        {
            if (!File.Exists(FILEPATH))
            {
                MessageBox.Show("the donors.txt file doesnt exist, cannot read it!");
                return false;
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(FILEPATH))
                    {
                        string line;
                        string[] arr;
                        while (sr.Peek() != -1)
                        {
                            line = sr.ReadLine();
                            arr = line.Replace(" ", "").Split('|');
                            Donor donor = new Donor(arr[0], arr[1], arr[2], arr[3], arr[4], Convert.ToChar(arr[5]), arr[6], arr[7]);
                            add(donor); 
                        }
                        return true;
                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
    }
}
