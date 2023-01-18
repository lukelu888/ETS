using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Con
{
    class Donor :Person
    {
        private string donorId;
        private string address;
        private string phone;
        private char cardType;
        private string cardNumber;
        private string cardExpiry;

        public Donor(string donorId, string firstName, string lastName, string address, string phone, char cardType, string cardNumber, string cardExpiry):base (firstName,lastName)
        {
            this.donorId = donorId;
            this.address = address;
            this.phone = phone;
            this.cardType = cardType;
            this.cardNumber = cardNumber;
            this.cardExpiry = cardExpiry;
        }

        public string DonorId { get => donorId; set => donorId = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public char CardType { get => cardType; set => cardType = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string CardExpiry { get => cardExpiry; set => cardExpiry = value; }

        public override string ToString()
        {
            return $"{this.donorId,-15}|{base.ToString(),-30}|{this.address,-40}|{this.phone,-15}|{this.cardType,-15}|{this.cardNumber,-20}|{this.cardExpiry,-15}";
        }

        public string GetId()
        {
            return this.donorId;
        }

    }
}
