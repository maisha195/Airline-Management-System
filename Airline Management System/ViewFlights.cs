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
    public partial class ViewFlights : Form
    {
        public ViewFlights()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string query = "select * from FlightTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FlightData.DataSource = ds.Tables[0];

            con.Close();
        }
        private void ViewFlights_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flight addf = new Flight();
            addf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TFcode.Text = "";
            Numseat.Text = "";
            SourceCb.Text = "";
            DestinationCb.Text = "";
            Date.Text = "";
        }

        private void FlightData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           /* TFcode.Text = FlightData.SelectedRows[0].Cells[0].Value.ToString();
            SourceCb.Text = FlightData.SelectedRows[0].Cells[1].Value.ToString();
            DestinationCb.Text = FlightData.SelectedRows[0].Cells[2].Value.ToString();
            Numseat.Text = FlightData.SelectedRows[0].Cells[4].Value.ToString();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TFcode.Text == "")
            {
                MessageBox.Show("Enter Flight to delete.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from FlightTbl where Fcode='" + TFcode.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight information deleted successfully.");
                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TFcode.Text == "" || Numseat.Text =="")
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update FlightTbl set Fsrc='" + SourceCb.SelectedItem.ToString() + "',FDest='" + DestinationCb.SelectedItem.ToString() + "',FDate='" + Date.Value.Date.ToString() + "',FCap='" + Numseat.Text + "' where Fcode='" + TFcode.Text + "'  ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight information updated successfully.");
                    con.Close();
                    populate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Missing Information");
                }
            }
        }

        private void FCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
