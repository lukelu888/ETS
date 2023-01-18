using ETS_Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace CGS_Win
{
    public partial class Login : Form
    {
        int counter = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void bn_submit_Click(object sender, EventArgs e)
        {
             
            if (String.IsNullOrEmpty(txb_username.Text) || String.IsNullOrEmpty(txb_password.Text))
            {
                MessageBox.Show("username or password cannot be empty");
            }
            else
            {


                if (txb_username.Text=="ETS" && txb_password.Text=="admin")
                {
                    this.Hide();
                    ETSTelethon mainForm = new ETSTelethon();
                    mainForm.ShowDialog();
                    this.Close();


                }
                else
                {
                    if (counter == 2)
                    {
                        MessageBox.Show("you reach the maximum times of trying username and password! the application will exit!");
                        this.Close();

                       
                    }
                    MessageBox.Show($"Wrong username or password! {2 - counter} times left to try!");
                    counter++;
                    txb_username.Clear();
                    txb_password.Clear();
                }

              



            }

          

        }


        private void bn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }



    
}
