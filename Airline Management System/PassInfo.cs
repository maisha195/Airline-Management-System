using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Management_System
{
    public partial class PassInfo : Form
    {
        public PassInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");
           
            if (PassId.Text == "" || PassAddress.Text == "" || PassName.Text == "" || Passport.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into PassengerTbl(PassId,PassName,Passport,PassAddress,PassNation,PassGender,PassPhone)values('" + PassId.Text + "','" + PassName.Text + "','" + Passport.Text + "','" + PassAddress.Text + "','" + Nationality.SelectedItem.ToString() + "','" + Gender.SelectedItem.ToString() + "','" + Phone.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger details successfully recorded.");

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PassMenu menu = new PassMenu();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PassId.Text = "";
            PassName.Text = "";
            PassAddress.Text = "";
            Passport.Text = "";
            Gender.Text = "";
            Phone.Text = "";
            Nationality.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Viewpassinfo view = new Viewpassinfo();
            view.Show();
            this.Hide();
        }
    }
}
