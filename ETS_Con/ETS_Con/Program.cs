using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Con
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DateTime today = DateTime.Today.ToString("dd/mm/yyyy");
            //Console.WriteLine(DateTime.Today.ToString("dd/MM/yyyy"));
            //Console.WriteLine(DateTime.Today.ToString("dd/MM/yy"));
            //Console.WriteLine(DateTime.Today.Year.ToString("yy"));
            //Console.WriteLine(isValid("12/2022")); 



            ETSManager manager = new ETSManager();
            manager.ListSponsors();
            //manager.AddSponsor("1");
        }

        static bool isValid(string dateString)
        {
            DateTime dateValue;

            if (DateTime.TryParse(dateString, out dateValue))
                if (dateValue < DateTime.Now)
                    return false;
                else
                    return true;
            else
                return false;
        }
    }
}
