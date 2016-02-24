using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Pendu
{
    class Initialisation
    {
        public static void FichierDico()
        {
            string path = @"Dico.txt"; // Chemin du Fichier(ici a la racine du .exe) "C: .....\Dico.txt"
            try
            {
                if (!File.Exists(path))//Verif Si le fichier est inexistant on le crée + 
                {
                    string[] LigneDicoDefault = { "ACCENTUE", "PENDERIE", "INCASSABLE", "DEVELOPPEUR", "LOGICIEL", "CAFETIERE" };
                    System.IO.File.AppendAllLines("dico.txt", LigneDicoDefault);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Erreur : " + er);
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialisation.FichierDico();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principale());
        }
    }
}
