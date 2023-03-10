using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ETS_Con
{
    class ETSManager
    {
        Donors myDonors = new Donors();
        Sponsors mySponsors = new Sponsors();
        Donations myDonations = new Donations();
        Prizes myPrizes = new Prizes();
        public ETSManager() { }



        #region Verifier

        public bool SponsorIdVerifier(string sponsorId)
        {
            foreach (Sponsor spon in mySponsors)
            {
                if (spon.GetId()==sponsorId)
                {
                    return true;
                }
            }
            return false;
        }


        public bool PrizeIdVerifier(string prizeId)
        {
            foreach (Prize prize in myPrizes)
            {
                if (prize.GetId() == prizeId)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DonorIdVerifier(string donorId)
        {
            foreach (Donor donor in myDonors)
            {
                if (donor.GetId() == donorId)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DonationIdVerifier(string donationId)
        {
            foreach (Donation donation in myDonations)
            {
                if (donation.GetId() == donationId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Sponsor

        public string AddSponsor(string sponsorId,string firstName, string lastName, double totalPrizeValue)
        {
            string message = "";
            if (sponsorId.Length!=4)
            {
                message = "Error! SponsorID must be 4 characters!";
            }
            else
            {
                if (SponsorIdVerifier(sponsorId))
                {
                    message = $"Error! the SponsorID {sponsorId} already exist!";
                }
                else
                {
                    if (firstName.Length>15||lastName.Length>15)
                    {
                        message = "Error! the sponsor first name or lastname cannot excess 15 characters!";
                    }
                    else
                    {
                        Sponsor sponsor = new Sponsor(sponsorId, firstName, lastName, totalPrizeValue);
                        mySponsors.add(sponsor);
                        message = $"Success! the sponsor with ID {sponsorId} was added to ETS!";
                    }
                }
            }
            Console.WriteLine(message);
            return message;
        }

        public string ListSponsors()
        {
            string info = "";
            if (mySponsors.Count>0)
            {
                info = "All info of Sponsors:\n" + $"{"SponsorID",-15}|{"FirstName",-15}|{"LastName,-15"}|{"TotalPrizeValue",-15}\n";
               
                for (int i = 0; i < mySponsors.Count; i++)
                {
                    if (i==mySponsors.Count-1)
                    {
                        info += mySponsors[i].ToString();
                        break;
                    }
                    info += mySponsors[i].ToString()+"\n";

                }
               
            }
            else
            {
                info = "There is no Sponsors in the system!";
            }
            Console.WriteLine(info);
            return info;
         
        }



        #endregion


        #region Prize


        public void AddValue(string sponsorId, double value)
        {
            for (int i = 0; i < mySponsors.Count; i++)
            {
                if (mySponsors[i].GetId()==sponsorId)
                {
                    mySponsors[i].AddValue(value);
                }
            }
        }
        public string AddPrize(string prizeId, string description, double value, double donationLimit, int numberOfPrize, string sponsorId)
        {
            string message = "";
            if (prizeId.Length!=4)
            {
                message = "Error! PrizeID must be 4 chars!";
            }
            else
            {
                if (PrizeIdVerifier(prizeId))
                {
                    message = $"Error! the prizeID {prizeId} already exist!";
                }
                else
                {
                    if ( description.Length > 15)
                    {
                        message = "Error! the description cannot excess 15 characters!";
                    }
                    else
                    {
                        if (value>=300||value<=0)
                        {
                            message = "Error! the prize value cannot excess 300 or less than 0!";
                        }
                        else
                        {
                            if (numberOfPrize>=1000)
                            {
                                message = "Error! the max number of prize that can be supplied is 999!";
                            }
                            else
                            {
                                if (!SponsorIdVerifier(sponsorId))
                                {
                                    message = "Error! the input sponsorId dont exist in the system, cannot add prize without a valid sponsorID!";
                                }
                                else
                                {
                                    Prize prize = new Prize(prizeId, description, value, donationLimit, numberOfPrize, sponsorId);
                                    double totalValue = value * numberOfPrize;
                                    AddValue(sponsorId, totalValue);
                                    message = $"Success! The Prize with ID {prizeId} was successfully added to ETS! ";
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(message);
            return message;
        }
       

        public string ListPrizes()
        {
            string info = "";
            if (myPrizes.Count > 0)
            {
                info = "All info of Prizes:\n" + $"{"PrizeID",-15}|{"Description",-15}|{"Value",-15}|{"Donation Limit",-15}|{"CurrentStock",-15}|{"SponsorID",-15}\n";

                for (int i = 0; i < myPrizes.Count; i++)
                {
                    if (i == myPrizes.Count - 1)
                    {
                        info += myPrizes[i].ToString();
                        break;
                    }
                    info += myPrizes[i].ToString() + "\n";

                }

            }
            else
            {
                info = "There is no Prizes in the system!";
            }
            Console.WriteLine(info);
            return info;
        }

        public string ListQualifiedPrizes(double donationAmount)
        {
            string info;
            bool result = false;
           
            info = "All info of qualified Prizes:\n" + $"{"PrizeID",-15}|{"Description",-15}|{"Value",-15}|{"Donation Limit",-15}|{"CurrentStock",-15}|{"SponsorID",-15}\n";

            for (int i = 0; i < myPrizes.Count; i++)
            {
                if (myPrizes[i].DonationLimit<=donationAmount)
                {
                    info += myPrizes[i].ToString() + "\n";
                    result = true;
                }
               
            }

            if (result)
            {
                Console.WriteLine(info);
                return info;
            }
            else
            {
                info = $"Sorry, no qualified Prize can be found with donation limit less than ${donationAmount}";
                Console.WriteLine(info);
                return info;
            }

           
        }

        public void DecreaseStock(string prizeId, int numOfPrizesAwarded)
        {
            for (int i = 0; i < myPrizes.Count; i++)
            {
                if (myPrizes[i].GetId()==prizeId)
                {
                    myPrizes[i].Decrease(numOfPrizesAwarded);
                }
            }
        }

        #endregion

        #region Donor
        public bool isValid(string dateString)
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
        public List<object> AddDonor(string donorId, string firstName, string lastName, string address, string phone, char cardType, string cardNumber, string cardExpiry)
        {
            bool successAddDonor = false;
            string message="";

            if (donorId.Length != 4)
            {
                message = "Error!Donor ID is 4 chars!";
            }
            else
            {
                if (firstName.Length > 15 || lastName.Length>15)
                {
                    message = "Error! firstname or lastname cannot excess 15 chars!";
                }
                else
                {
                    if (address.Length>40)
                    {
                        message = "Error! address cannot more than 40 chars!";
                    }
                    else
                    {
                        if (phone.Length!=10)
                        {
                            message = "Error! Phone number must be 10 digit!";
                        }
                        else
                        {
                            if (cardType!='V'&&cardType!='M'&&cardType!='A')
                            {
                                message = "Error! credit card must be Visa, MasterCard or Amex!";
                            }
                            else
                            {
                                if (cardNumber.Length!=16)
                                {
                                    message = "Error! credit card must be 16 digits!";
                                }
                                else
                                {
                                    Match match = Regex.Match(cardExpiry, @"[0-9]{2}/[0-9]{4}");
                                    if (!match.Success)
                                    {
                                        message = "Error! the card Expiry date must be in mm/yyyy format!";
                                    }
                                    else
                                    {
                                        if (!isValid(cardExpiry))
                                        {
                                            message = "Error! the card already expired!";
                                        }
                                        else
                                        {
                                            Donor donor = new Donor(donorId, firstName, lastName, address, phone, cardType, cardNumber, cardExpiry);
                                            myDonors.add(donor);
                                            message = $"Success! the donor with ID {donorId} is added to the system!";
                                            successAddDonor = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(message);
            List<object> result = new List<object>();
            result.Add(successAddDonor);
            result.Add(message);

            return result;

        }

        public string ListDonors()
        {
            string info = "";
            if (myDonors.Count > 0)
            {
                info = "All info of Donors:\n" + $"{"DonorID",-15}|{"first name",-35}|{"last name",-15}|{"address",-40}|{"phone number",-15}|{"card type",-15}|{"card number",-20}|{"expiry date",-15}\n";

                for (int i = 0; i < myDonors.Count; i++)
                {
                    if (i == myDonors.Count - 1)
                    {
                        info += myDonors[i].ToString();
                        break;
                    }
                    info += myDonors[i].ToString() + "\n";

                }

            }
            else
            {
                info = "There is no Sponsors in the system!";
            }
            Console.WriteLine(info);
            return info;
        }




        #endregion



        #region Donation

        public string addDonation(string donationId, string donationDate, string donorId, double donationAmount, string prizeId)
        {
            string message = "";
            if (donationId.Length != 4)
            {
                message = "Error! DonationId must be 4 characters!";
            }
            else
            {
                if (DonationIdVerifier(donationId))
                {
                    message = $"Error! the donationId {donationId} already exist!";
                }
                else
                {
                    if (donationAmount<5 ||donationAmount>=1000000)
                    {
                        message = "Error! the donation amount must between $5 and $1000000!";
                    }
                    else
                    {

                        if (!PrizeIdVerifier(prizeId))
                        {
                            message = "Error! the prizeID not exist in the system,cannot assign prize for the donation!";
                        }
                        else
                        {
                            Donation donation = new Donation(donationId, donationDate, donorId, donationAmount, prizeId);
                            myDonations.add(donation);
                            message = $"Success! the donation with ID {donationId} was added to ETS!";
                        }
                       
                        
                    }
                }
            }
            Console.WriteLine(message);
            return message;
        }


        public string ListDonations()
        {
            string info = "";
            if (myDonations.Count > 0)
            {
                info = "All info of Donations:\n" + $"{"DonationID",-15}|{"DonationDate",-15}|{"DonorID",-15}|{"DonationAmount",-15}|{"PrizeID",-15}\n";

                for (int i = 0; i < myDonations.Count; i++)
                {
                    if (i == myDonations.Count - 1)
                    {
                        info += myDonations[i].ToString();
                        break;
                    }
                    info += myDonations[i].ToString() + "\n";

                }

            }
            else
            {
                info = "There is no Donations in the system!";
            }
            Console.WriteLine(info);
            return info;
        }

        // this originally was called recordDonation, to make one donnor make multiple donation possible, i break the recordDonation into the windows form and here
        public bool ValidateNumOfPrizeAwarded(string prizeId, int numOfPrizesAwarded)
        {
            foreach (Prize pr in myPrizes)
            {
                if (pr.GetId()==prizeId)
                {
                    if (pr.CurrentAvailable>=numOfPrizesAwarded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion




    }
}
