﻿using System;
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
    public partial class ViewPassengers : Form
    {
        public ViewPassengers()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\AirPlaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string query = "select * from PassengerTbl";
            SqlDataAdapter sda= new SqlDataAdapter(query,con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            var ds=new DataSet();
            sda.Fill(ds);
            PassangerData.DataSource = ds.Tables[0];

            con.Close();
        }
        private void ViewPassengers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu addpass= new MainMenu();
            addpass.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(PId.Text == "")
            {
                MessageBox.Show("Enter Passenger Id to delete.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query="delete from PassengerTbl where PassId='"+PId.Text.ToString()+"'";
                    SqlCommand cmd=new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger information deleted successfully.");
                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PassangerData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* PId.Text = PassangerData.SelectedRows[0].Cells[0].Value.ToString();
            PName.Text = PassangerData.SelectedRows[0].Cells[1].Value.ToString();
            Passport.Text = PassangerData.SelectedRows[0].Cells[2].Value.ToString();
            PAddress.Text = PassangerData.SelectedRows[0].Cells[3].Value.ToString();
            PNationality.Text = PassangerData.SelectedRows[0].Cells[4].Value.ToString();
            PGender.Text = PassangerData.SelectedRows[0].Cells[5].Value.ToString(); */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(PId.Text==""||PName.Text == "" ||Passport.Text == "" ||PAddress.Text == "")
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update PassengerTbl set PassName='" + PName.Text + "',Passport='" + Passport.Text + "',PassAddress='" + PAddress.Text + "',PassNation='" + PNationality.SelectedItem.ToString() + "',PassGender='" + PGender.SelectedItem.ToString() + "',PassPhone='" + Phone.Text + "' where PassId='"+PId.Text+"'";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger information updated successfully.");
                    PName.Clear();
                    Passport.Clear();
                    PAddress.Clear();
                    Phone.Clear();

                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Missing Information");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PId.Text = "";
            PName.Text = "";
            Passport.Text = "";
            PAddress.Text = "";
            PNationality.Text = "";
            PGender.Text = "";
        }

        private void PGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Passport_TextChanged(object sender, EventArgs e)
        {

        }

        private void PName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void PNationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void PId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Phone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
