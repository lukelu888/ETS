using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Con
{
    class Donation
    {
        private string donationId;
        private string donationDate;
        private string donorId;
        private double donationAmount;
        private string prizeId;

        public Donation(string donationId, string donationDate, string donorId, double donationAmount, string prizeId)
        {
            this.donationId = donationId;
            this.donationDate = donationDate;
            this.donorId = donorId;
            this.donationAmount = donationAmount;
            this.prizeId = prizeId;
        }

        public string DonationId { get => donationId; set => donationId = value; }
        public string DonationDate { get => donationDate; set => donationDate = value; }
        public string DonorId { get => donorId; set => donorId = value; }
        public double DonationAmount { get => donationAmount; set => donationAmount = value; }
        public string PrizeId { get => prizeId; set => prizeId = value; }


        public override string ToString()
        {
            return $"{this.donationId,-15}|{this.donationDate,-15}|{this.donorId,-15}|{this.donationAmount,-15}|{this.prizeId,-15}";
        }

        public string GetId()
        {
            return this.donorId;
        }
    }
}
