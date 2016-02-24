using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pendu
{
    
    public partial class Principale : Form
    {
        internal static bool Enabled;
        public Principale()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        public void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionnaire Dictio = new Dictionnaire();
            Dictio.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MotATrouverEnString = InitialisationAvantJeu();
        }

        private void Principale_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string ComboBoxSaisie;
            AjoutDansLabelSuprrDeComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        //[NombreLigneFichierTexte]       Compte le nombre de  Mot dans le fichier Texte
        public int NombreLigneFichierTexte()
        {
            int Compteur = 0;
            string Parcourir;
            System.IO.StreamReader file = new System.IO.StreamReader("dico.txt");
            while ((Parcourir = file.ReadLine()) != null)
            {
                Compteur++;
            }
            file.Close();
            
            return (Compteur);
        }
        //[RandomMot]    Choisis un Mot dans le fichier Texte
        public string RandomMot()
        {
            int Compteur = 0;
            string RandMot;
            System.IO.StreamReader file = new System.IO.StreamReader("dico.txt");
            Random rnd = new Random();
            int Rand = rnd.Next(0, NombreLigneFichierTexte());
            MessageBox.Show(Convert.ToString(Rand));
            while ((RandMot = file.ReadLine()) != null && Compteur < Rand)
            {
                Compteur++;
            }
            return (RandMot);
           
        }
        //[AffichageTiretLabelMotATrouver]    Remplace le mot a trouver (label.mot a trouver) par des tirets
        public string AffichageTiretLabelMotATrouver(string MotATrouverEnString)
        {
            char[] MotATrouverEnChar = new char[MotATrouverEnString.Length];
            int Compteur = 0;
            while(Compteur < MotATrouverEnString.Length)
            {
                MotATrouverEnChar[Compteur] = '-';
                Compteur++;

            }
            MotATrouverEnString = new string(MotATrouverEnChar);
            return (MotATrouverEnString);
            
        } 
        //
        public string InitialisationAvantJeu()
        {
            button1.Text = "Reset";
            string MotATrouverEnString;
            Difficulte Diff = new Difficulte();
            Diff.ShowDialog();
            comboBox1.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = false;
            label1.Text = Convert.ToString(Program.difficult);
            MotATrouverEnString = RandomMot();
            label4.Text = "";
            label5.Text = AffichageTiretLabelMotATrouver(MotATrouverEnString);
            InitialiseComboBox();
            return (MotATrouverEnString);
        }
        //[InitialiseComboBox] Insert Alphabet Dans le comboBox
        public void InitialiseComboBox()
        {
            System.Object[] ItemObject = new System.Object[26];
            for (int i = 0, c = 65; i <= 25; i++)
            {
                ItemObject[i] = Convert.ToChar(c);
                c++;
            }
            comboBox1.Items.AddRange(ItemObject);
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        //[AjoutDansLabelSuprrDeComboBox]     Ajoute La lettre dans label lettre saisie et supprimer Lettre de la combo box
        public void AjoutDansLabelSuprrDeComboBox()
        {
            label4.Text += comboBox1.Text;
            label4.Text += '-';
            comboBox1.Items.Remove(comboBox1.SelectedItem);
        }

    }
}
