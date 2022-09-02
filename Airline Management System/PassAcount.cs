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
    public partial class PassAcount : Form
    {
        public PassAcount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            if (AId.Text == "" || AName.Text == "" || Pincode.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into PassloginTBl(pid,pname,password) values('" + AId.Text.ToString() + "','" + AName.Text.ToString() + "','" + Pincode.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully!");
                    AId.Clear();
                    AName.Clear();
                    Pincode.Clear();


                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AId.Text = "";
            AName.Text = "";
            Pincode.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            if (AId.Text == "")
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {

                con.Open();
                string query = "update PassloginTBl set pname='" + AName.Text + "',password='" + Pincode.Text + "' where pid='" + AId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin information updated successfully.");
                con.Close();



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PassLogin log = new PassLogin();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
