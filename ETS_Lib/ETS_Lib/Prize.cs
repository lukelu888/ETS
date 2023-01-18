using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Prize
    {
        private string prizeId;
        private string description;
        private double value;
        private double donationLimit;
        private int originalAvailable;
        private int currentAvailable;
        private string sponsorId;



        public Prize(string prizeId, string description, double value, double donationLimit, int originalAvailable, string sponsorId)
        {
            this.prizeId = prizeId;
            this.description = description;
            this.value = value;
            this.donationLimit = donationLimit;
            this.originalAvailable = originalAvailable;
            this.currentAvailable = originalAvailable;
            this.sponsorId = sponsorId;
          
        }
        public string PrizeId { get => prizeId; set => prizeId = value; }
        public string Description { get => description; set => description = value; }
        public double Value { get => value; set => this.value = value; }
        public double DonationLimit { get => donationLimit; set => donationLimit = value; }
        public int OriginalAvailable { get => originalAvailable; set => originalAvailable = value; }
        public int CurrentAvailable { get => currentAvailable; set => currentAvailable = value; }
        public string SponsorId { get => sponsorId; set => sponsorId = value; }
        public override string ToString()
        {
            return $"{this.prizeId,-15}|{this.description,-15}|{this.value,-15}|{this.donationLimit,-15}|{this.currentAvailable,-15}|{this.sponsorId,-15}";
        }

        public string GetId()
        {
            return this.prizeId;
        }


        public void Decrease(int quantity)
        {
            this.currentAvailable-= quantity;
        }

        public void ClearPrize()
        {
            this.currentAvailable = 0;
        }
    }
}
