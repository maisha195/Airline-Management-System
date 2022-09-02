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
    public partial class PassTicket : Form
    {
        public PassTicket()
        {
            InitializeComponent();
        }
        private void populate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "select * from TicketTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TicketData.DataSource = ds.Tables[0];

            con.Close();
        }
        private void PassTicket_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuyTicket bt = new BuyTicket();
            bt.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            int a, b;

            if (Tid.Text == "" || TFcode.Text == "" || Tclass.Text == "" || amount.Text == "" || Date.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    a = Convert.ToInt32(amount.Text);
                    b = Convert.ToInt32(quantity.Text);
                    cost.Text = Convert.ToString(a * b);
                    string query = "insert into BookingTbl (TicketId,Flightcode,Ticketclass,Ticketamount,Ticketdate,Totalcost,Quantity) values ('" + Tid.Text + "','" + TFcode.SelectedItem.ToString() + "','" + Tclass.SelectedItem.ToString() + "','" + amount.Text+ "','" + Date.Text + "','" + cost.Text + "','" + quantity.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight details successfully recorded.");

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

        private void button3_Click(object sender, EventArgs e)
        {
            Tid.Text = "";
            TFcode.Text = "";
            Tclass.Text = "";
            Date.Text = "";
            amount.Text = "";
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TicketData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
