using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_and_E_Games
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TheHeroIsComingForm().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new EasterBunnyAndTheEggs().Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new RiseOfTheZombies().Show();
            this.Close();
        }
    }
}
