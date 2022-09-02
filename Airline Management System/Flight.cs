using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Airline_Management_System
{
    public partial class Flight : Form
    {
        public Flight()
        {
            InitializeComponent();
        }

        private void Flight_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (TFcode.Text == "" || Source.Text == "" || Destination.Text == "" || Date.Text == "" || Numofseat.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into FlightTbl (Fcode,Fsrc,FDest,FDate,FCap) values ('" + TFcode.Text + "','" + Source.SelectedItem.ToString() + "','" + Destination.SelectedItem.ToString() + "','" + Date.Text + "','" + Numofseat.Text+ "')";
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

        private void Source_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TFcode.Text = "";
            Source.Text = "";
            Destination.Text = "";
            Numofseat.Text = "";
            Date.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewFlights viewf= new ViewFlights();
            viewf.Show();
            this.Hide();
        }

        private void Fcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
