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

namespace GD_UNO_2021
{
    public partial class FicPrinc : Form
    {
        int i;
        public FicPrinc()
        {
            InitializeComponent();
        }

        private void B_quitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_NP_Click(object sender, EventArgs e)
        {
            EcranTerrain NP = new EcranTerrain();
            NP.ShowDialog();
        }

        private void B_charger_Click(object sender, EventArgs e)
        {
            List<Carte> J1 = new List<Carte>();
            List<Carte> J2 = new List<Carte>();
            List<Carte> Pioche = new List<Carte>();
            List<Carte> Defausse = new List<Carte>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string lecture;
                while ((lecture = sr.ReadLine()) != "/")
                {
                    string[] tab = lecture.Split('|');
                    if (tab[0] == "1")
                       i = 1;
                    else
                       i = 0;
                }
                while ((lecture = sr.ReadLine()) != "/")
                {
                    string[] tab = lecture.Split('|');
                    Carte c = new Carte(tab[0], tab[1], int.Parse(tab[2]));
                    Defausse.Add(c);
                }
                while ((lecture = sr.ReadLine()) != "/")
                {
                    string[] tab = lecture.Split('|');
                    Carte c = new Carte(tab[0], tab[1],int.Parse(tab[2]));
                    J1.Add(c);
                }
                while ((lecture = sr.ReadLine()) != "/")
                {
                    string[] tab = lecture.Split('|');
                    Carte c = new Carte(tab[0], tab[1], int.Parse(tab[2]));
                    J2.Add(c);
                }
                while ((lecture = sr.ReadLine()) != "/")
                {
                    string[] tab = lecture.Split('|');
                    Carte c = new Carte(tab[0], tab[1], int.Parse(tab[2]));
                    Pioche.Add(c);
                }
                sr.Close();
                EcranTerrain CP = new EcranTerrain(i,J1,J2,Pioche,Defausse);
                CP.ShowDialog();
            }
            
        }
    }
}
