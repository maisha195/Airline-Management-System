using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Management_System
{
    public partial class PassMenu : Form
    {
        public PassMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PassInfo infor = new PassInfo();
            infor.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PassTicket tick = new PassTicket();
            tick.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PassFlight fly = new PassFlight();
            fly.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panels pan = new Panels();
            pan.Show();
            this.Hide();
        }
    }
}
