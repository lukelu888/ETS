using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETS_Lib;
using static ETS_Lib.Paths;

namespace ETS_Win
{
    public partial class ETSTelethon : Form
    {
        ETSManager manager = new ETSManager();
        public ETSTelethon()
        {
            InitializeComponent();
        }

       

        private void bn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bn_addSponsor_Click(object sender, EventArgs e)
        {
          

            if (String.IsNullOrEmpty(tb_sponsor_id.Text) || String.IsNullOrEmpty(tb_sponsor_firstName.Text) || String.IsNullOrEmpty(tb_sponsor_lastName.Text))
            {
                MessageBox.Show("First Name or Last Name or SponsorID cannot be empty to add a sponsor!");
            }
            else
            {
                string message = manager.AddSponsor(tb_sponsor_id.Text, tb_sponsor_firstName.Text, tb_sponsor_lastName.Text, 0);
                MessageBox.Show(message);
               
                tb_sponsor_firstName.Clear();
                tb_sponsor_lastName.Clear();
            }
        }

        private void bn_viewSponsors_Click(object sender, EventArgs e)
        {

            rtb_main.Clear();
            string info = manager.ListSponsors();
            rtb_main.AppendText(info);
        }

        private void bn_addPrize_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_prize_id.Text) || String.IsNullOrEmpty(tb_prize_description.Text) || String.IsNullOrEmpty(tb_prize_value.Text)|| String.IsNullOrEmpty(tb_prize_numOfPrize.Text) || String.IsNullOrEmpty(tb_prize_donationLimit.Text) || String.IsNullOrEmpty(tb_sponsor_id.Text))
            {
                MessageBox.Show("Prize ID,Description,Value, Number of prizes supplied, Minimum donation limit, Sponsor ID  cannot be empty to add a prize!");
            }
            else
            {
                string message = manager.AddPrize(tb_prize_id.Text, tb_prize_description.Text, double.Parse(tb_prize_value.Text), double.Parse(tb_prize_donationLimit.Text), int.Parse(tb_prize_numOfPrize.Text), tb_sponsor_id.Text);
      
                MessageBox.Show(message);
                tb_prize_id.Clear();
                tb_prize_description.Clear();
                tb_prize_donationLimit.Clear();
                tb_prize_numOfPrize.Clear();
                tb_prize_value.Clear();
                tb_sponsor_id.Clear();
              
            }
        }

        private void bn_viewPrizes_Click(object sender, EventArgs e)
        {
            rtb_main.Clear();
            string info = manager.ListPrizes();
            rtb_main.AppendText(info);
        }

        private void bn_addDonor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_donor_id.Text) || String.IsNullOrEmpty(tb_donor_firstName.Text) || String.IsNullOrEmpty(tb_donor_lastName.Text) || String.IsNullOrEmpty(tb_donor_address.Text) || String.IsNullOrEmpty(tb_donor_phone.Text) )
            {
                MessageBox.Show("DonorID, First Name , Last Name , address, phone number cannot be empty to add a sponsor!");
            }
            else
            {
                if (String.IsNullOrEmpty(tb_donor_cardNumber.Text) || String.IsNullOrEmpty(tb_donor_cardExpiry.Text)||(!rb_donor_visa.Checked&&!rb_donor_mastercard.Checked&&!rb_donor_amex.Checked))
                {
                    MessageBox.Show("All Credit Info cannot be empty!");
                }
                else

                {
                    char cardType;
                    if (rb_donor_visa.Checked)
                    {
                        cardType ='V';
                    }
                    else if (rb_donor_mastercard.Checked)
                    {
                        cardType = 'M';
                    }
                    else
                    {
                        cardType = 'A';
                    }
                    string message = manager.AddDonor(tb_donor_id.Text, tb_donor_firstName.Text, tb_donor_lastName.Text, tb_donor_address.Text, tb_donor_phone.Text,cardType,tb_donor_cardNumber.Text, tb_donor_cardExpiry.Text);

                    MessageBox.Show(message);

                    tb_donor_firstName.Clear();
                    tb_donor_lastName.Clear();
                    tb_donor_address.Clear();
                    tb_donor_phone.Clear();
                    tb_donor_cardNumber.Clear();
                    tb_donor_cardExpiry.Clear();
                    rb_donor_visa.Checked = false;
                    rb_donor_mastercard.Checked = false;
                    rb_donor_amex.Checked = false;
                }
            }

           
        }

        private void bn_listDonors_Click(object sender, EventArgs e)
        {
            rtb_main.Clear();
            string info = manager.ListDonors();
            rtb_main.AppendText(info);
        }

        private void bn_addDonation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_donor_id.Text) || String.IsNullOrEmpty(tb_donation_id.Text) || String.IsNullOrEmpty(tb_donation_amount.Text) || String.IsNullOrEmpty(tb_award_prizeId.Text) || String.IsNullOrEmpty(tb_award_number.Text))
            {
                MessageBox.Show("donationID, donorID , donation amount , PrizeID, number of prize awarded cannot be empty to add a donation!");
            }
            else
            {
                string donationDate = DateTime.Today.ToString("dd/MM/yyyy");
                string message = manager.RecordDonation(tb_award_prizeId.Text, int.Parse(tb_award_number.Text), tb_donation_id.Text, donationDate, tb_donor_id.Text, double.Parse(tb_donation_amount.Text));
                MessageBox.Show(message);
                tb_donor_id.Clear();
                tb_donation_id.Clear();
                tb_donation_amount.Clear();
                tb_award_number.Clear();
                tb_award_prizeId.Clear();

               
            }
        }

        private void bn_listDonations_Click(object sender, EventArgs e)
        {
            rtb_main.Clear();
            string info = manager.ListDonations();
            rtb_main.AppendText(info);
        }

        private void bn_showPrizes_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrEmpty(tb_donation_amount.Text))
            {
                MessageBox.Show("Donation amount cannot be empty to show eligible prizes!");
            }
            else
            {
                rtb_main.Clear();
                string info = manager.ListQualifiedPrizes(double.Parse(tb_donation_amount.Text));
                rtb_main.AppendText(info);
            }
           
        }

        private void bn_saveDonors_Click(object sender, EventArgs e)
        {
            if (manager.WriteDonors())
            {
                MessageBox.Show($"All info of donors are successfully saved to donors.txt @ {FILEPATH}");
            }
        }

        private void bn_readDonors_Click(object sender, EventArgs e)
        {
            if (manager.GetDonors())
            {
                MessageBox.Show("The donors.txt are succesfully read and all content are saved to donors collection!");
            }
        }

        private void bn_bonus_displayADonor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_bonus_donor_id.Text))
            {
                MessageBox.Show("Donor ID in the bonus section cannot be empty!");
            }
            else
            {
               string message =  manager.DisplayADonor(tb_bonus_donor_id.Text);
               rtb_main.Clear();
               rtb_main.AppendText(message);
            }
        }

        private void bn_bonus_deleteDonor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_bonus_donor_id.Text))
            {
                MessageBox.Show("Donor ID in the bonus section cannot be empty!");
            }
            else
            {
                string message = manager.DeleteDonor(tb_bonus_donor_id.Text);
                rtb_main.Clear();
                rtb_main.AppendText(message);
            }
        }

        private void bn_bonus_displayASponsor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_bonus_sponsor_id.Text))
            {
                MessageBox.Show("Sponsor ID in the bonus section cannot be empty!");
            }
            else
            {
                string message = manager.DisplayASponsor(tb_bonus_sponsor_id.Text);
                rtb_main.Clear();
                rtb_main.AppendText(message);
            }
        }

      



        private void tab_sponsors_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Sponsors, Prizes";
        }

        private void tab_donors_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Donors, Donations";
        }

        private void bn_dropDownList_loadPrize_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_donation_amount.Text))
            {
                MessageBox.Show("Donation amount cannot be empty to load eligible prizes!");
            }
            else
            {
                ComboBox_EligiblePrizes.Items.Clear();
                List<string> items = manager.PackEligiblePrizesToDropDownList(double.Parse(tb_donation_amount.Text));
                foreach (string item in items)
                {
                    ComboBox_EligiblePrizes.Items.Add(item);
                }


            }
        }

        private void bn_dropDownList_addDonation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_donor_id.Text) || String.IsNullOrEmpty(tb_donation_id.Text) || String.IsNullOrEmpty(tb_donation_amount.Text) || String.IsNullOrEmpty(ComboBox_EligiblePrizes.SelectedItem.ToString()))
            {
                MessageBox.Show("donationID, donorID , donation amount , selected Prize cannot be empty to add a donation!");
            }
            else
            {
                string prizeId = ComboBox_EligiblePrizes.SelectedItem.ToString().Split('-')[0];
                string donationDate = DateTime.Today.ToString("dd/MM/yyyy");
                string message = manager.RecordDonation(prizeId, 1, tb_donation_id.Text, donationDate, tb_donor_id.Text, double.Parse(tb_donation_amount.Text));
                MessageBox.Show(message);
                tb_donor_id.Clear();
                tb_donation_id.Clear();
                tb_donation_amount.Clear();
                
                ComboBox_EligiblePrizes.Items.Clear();

                //ComboBox_EligiblePrizes.SelectedIndex=-1;
                ComboBox_EligiblePrizes.ResetText();



            }
        }

  
    }
}
