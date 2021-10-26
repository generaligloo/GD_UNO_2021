using System;
using System.Windows.Forms;

namespace GD_UNO_2021
{
    public partial class choix_carte_triche : Form
    {
        private EcranTerrain terrain = null;

        public choix_carte_triche(jeu partie, Form parent)
        {
            InitializeComponent();
            terrain = parent as EcranTerrain;
            foreach (Carte c in partie.Pioche.paquet)
            {
                LB_Deck.Items.Add(c.DisplayValue);
            }
        }

        private void choix_carte_triche_Load(object sender, EventArgs e)
        {
        }

        private void b_pioche_triche_Click(object sender, EventArgs e)
        {
            if (LB_Deck.SelectedIndex == -1)
            {
                MessageBox.Show("Aucune carte sélectionnée !");
            }
            else
            {
                DialogResult DGP = MessageBox.Show("Vous souhaitez piocher le " + LB_Deck.SelectedItem.ToString() + "?", "choix", MessageBoxButtons.YesNo);
                if (DGP == DialogResult.Yes)
                {
                    terrain.carteText = LB_Deck.SelectedItem.ToString();
                    this.Close();
                }
            }
        }
    }
}