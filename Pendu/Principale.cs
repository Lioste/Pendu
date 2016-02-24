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
    public partial class Principale : Form
    {
        public Principale()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
      
            Dictionnaire Dictio = new Dictionnaire();
            Dictio.Activate();
            Dictio.Show()
           //Principale.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Difficulte = 0;
            string MotATrouver, LettreSaisie;


        }

        private void Principale_Load(object sender, EventArgs e)
        {

        }
    }
}
