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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
        public static string AccountNumber;
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
                    string query = "insert into AdminTbl(Aid,Aname,Apin) values('" + AId.Text.ToString() + "','" + AName.Text.ToString() + "','" + Pincode.Text.ToString() + "')";
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

        private void AName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            if (AId.Text == ""  )
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                
                    con.Open();
                    string query = "update AdminTbl set Aname='" + AName.Text + "',Apin='" + Pincode.Text + "' where Aid='" + AId.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin information updated successfully.");
                    con.Close();
                  
                
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AId.Text ="";
            AName.Text = "";
            Pincode.Text = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
