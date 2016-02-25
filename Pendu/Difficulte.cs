using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu
{
    public partial class Difficulte : Form
    {
        public Difficulte()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Program.difficult = 7;
            Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Program.difficult = 11;
            Close();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            Program.difficult = 15;
            Close();
        }

        private void Difficulte_Load(object sender, EventArgs e)
        {
            Program.difficult = 11;
        }
    }
}
