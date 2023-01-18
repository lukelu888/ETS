using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Sponsor :Person
    {
        private string sponsorId;
        private double totalPriceValue;

        public Sponsor(string sponsorId, string firstName, string lastName, double totalPriceValue ): base(firstName, lastName)
        {
            this.sponsorId = sponsorId;
            this.totalPriceValue = totalPriceValue;
        }
        public string SponsorId { get => sponsorId; set => sponsorId = value; }
        public double TotalPriceValue { get => totalPriceValue; set => totalPriceValue = value; }


        public override string ToString()
        {
            return $"{this.sponsorId,-15}|{base.ToString(),-30}|{this.totalPriceValue,-15}";
        }
        public string GetId()
        {
            return this.sponsorId;
        }
        public void AddValue(double value)
        {
            this.totalPriceValue += value;
        }
    }
}
