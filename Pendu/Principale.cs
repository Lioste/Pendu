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
    
    public partial class  Principale : Form
    {
        //internal static bool Enabled;
        bool Reset = false;
        string  MotATrouverEnString;
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

        public void button1_Click(object sender, EventArgs e)
        {
            if (!Reset)
            {
                string MotATrouverEnString2 = InitialisationAvantJeu();
                Reset = true;
            }
            else
            {
                Application.Restart();
                //Reset = false;
              /*  //Close();
                Principale ResetWindow = new Principale();
                ResetWindow.Show();
                Close();*/
            }

        }

        private void Principale_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 1)
            {
                //int Test = 0; 
                AjoutDansLabel_SuprrDeComboBox();
                //Program.difficult = Program.difficult - Verif_SaisieMotATrouver(MotATrouverEnString);

                Verif_SaisieMotATrouver(MotATrouverEnString);
                if (FonctionDecompte() == 0)
                {
                    Program.difficult = Program.difficult - 1;
                    label1.Text = Convert.ToString(Program.difficult);
                }
                
                if (verif_silemotestbon() == 1)
                {
                    MessageBox.Show("GAGNE");

                }
                
                if(Program.difficult == 0)
                {
                    MessageBox.Show("PERDU");
                }
                    //MotATrouverEnString = Verif_SaisieMotATrouver(ref MotATrouverEnString);
            }
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
            while ((RandMot = file.ReadLine()) != null && Compteur < Rand)
            {
                Compteur++;
            }
            return (RandMot);
           
        }
        //[AffichageTiretLabelMotATrouver]    Remplace le mot a trouver (label.mot a trouver) par des tirets
        public void AffichageTiretLabelMotATrouver(string MotATrouverEnString)
        {
            char[] MotATrouverEnChar = new char[MotATrouverEnString.Length];
            int Compteur = 0;
            while(Compteur < MotATrouverEnString.Length)
            {
                MotATrouverEnChar[Compteur] = '-';
                Compteur++;

            }
            //MotATrouverEnString = new string(MotATrouverEnChar);
            label5.Text = new string(MotATrouverEnChar);
           // return (MotATrouverEnString);
            
        } 
        //
        public string InitialisationAvantJeu()
        {
            button1.Text = "Reset";
          // string MotATrouverEnString;
            //Fenetre difficulte
            Difficulte Diff = new Difficulte();
            Diff.ShowDialog();

            comboBox1.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = false;
            label1.Text = Convert.ToString(Program.difficult);
            MotATrouverEnString = RandomMot();
            label4.Text = "";
            AffichageTiretLabelMotATrouver(MotATrouverEnString);
            //label5.Text = AffichageTiretLabelMotATrouver(MotATrouverEnString);
            InitialiseComboBox();
            return (MotATrouverEnString);
        }
        //[InitialiseComboBox] Insert Alphabet Dans le comboBox
        public void InitialiseComboBox()
        {
            comboBox1.Items.Clear();
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
        public void AjoutDansLabel_SuprrDeComboBox()
        {
            label4.Text += comboBox1.Text;
            label4.Text += '-';
            comboBox1.Items.Remove(comboBox1.SelectedItem);
        }
        //[] 

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public int Verif_SaisieMotATrouver(string MotATrouverEnString)
        {
            int Compteur = 0,Compteur2 = 0;
            bool Modif = false;
            char[] MotATrouverEnChar = new char[MotATrouverEnString.Length];
            while(Compteur < MotATrouverEnString.Length)
            {
                MotATrouverEnChar[Compteur] = '-';
                Compteur++;
            }
            Compteur = 0;
            //char[] MotAComparer = new char[label4.Text.Length];
            
            while (Compteur < MotATrouverEnString.Length)//verif de toute les lettre dans label4
            {
                while (Compteur2 < label4.Text.Length)
                {
                    if (label4.Text[Compteur2] == MotATrouverEnString[Compteur])
                    {
                        MotATrouverEnChar[Compteur] = label4.Text[Compteur2];
                        Modif = true;
                    }
                     Compteur2 = Compteur2 + 2;   
                     
                }
                
                Compteur2 = 0;
                Compteur++;
            }
            label5.Text = new string(MotATrouverEnChar);
            if (Modif)
                return (0);
            else 
                return (1);
            
           // MotATrouverEnString = new string(MotATrouverEnChar);
           // return (MotATrouverEnString);
          }
            public int FonctionDecompte()
        {
            
            char C;
            C = label4.Text[label4.Text.Length - 2];MessageBox.Show(Convert.ToString(C));
            int I = 0;
            while(I < label5.Text.Length)
            {
                if(C == label5.Text[I])
                {
                    return(1);
                }
                I++;
            }
            return (0);
        }
            public int verif_silemotestbon()
            {
                int Compteur = 0;
                while(Compteur < MotATrouverEnString.Length)
                {
                    if (label5.Text[Compteur] == '-')
                        return (0);
                    Compteur++;
                }
                return (1);
            }
        }
           
    }
      

