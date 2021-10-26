using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace GD_UNO_2021
{
    public partial class EcranTerrain : Form
    {
        private bool admin = false;
        public jeu partie = new jeu();
        public int i = 0;
        public int color_check = 0;
        public bool varpioche_2 = false;
        public bool varpioche_4 = false;
        public bool varpass = false;
        public bool uno1 = false;
        public bool uno2 = false;
        private List<PictureBox> Images_j1 = new List<PictureBox>();
        private List<PictureBox> Images_j2 = new List<PictureBox>();

        public EcranTerrain()
        {
            InitializeComponent();
        }

        public EcranTerrain(int i_c, List<Carte>J1_c, List<Carte> J2_c, List<Carte> pioche_c, List<Carte> defausse_c)
        {
            InitializeComponent();
            i = i_c;
            partie.charger(J1_c, J2_c, pioche_c, defausse_c);
            turn_charge();
        }

        private void Terrain_Load(object sender, EventArgs e)
        {
            LB_Deck.Visible = LB_defausse.Visible = LB_Player1.Visible = LB_Player2.Visible = B_jouer1.Visible = B_jouer2.Visible = B_piocher1.Visible = B_piocher2.Visible = false;
            B_jouer2.Enabled = false;
            B_piocher2.Enabled = false;
            b_triche.Enabled = false;
            B_jouer1.Enabled = false;
            B_piocher1.Enabled = false;
            B_sauv.Enabled = false;
        }
        private void turn_charge()
        {
            if (i == 0)
            {
                B_jouer1.Enabled = true;
                B_piocher1.Enabled = true;
                B_jouer2.Enabled = false;
                B_piocher2.Enabled = false;
            }
            else
            {
                B_jouer1.Enabled = false;
                B_piocher1.Enabled = false;
                B_jouer2.Enabled = true;
                B_piocher2.Enabled = true;
            }
            refresh_aff();
            mains_aff();
            B_sauv.Enabled = true;
        }
        private void turn()
        {
            B_sauv.Enabled = true;
            b_triche.Enabled = true;
            if (varpass)
            {
                if (varpioche_2)
                {
                    MessageBox.Show("Le joueur adverse pioche 2 cartes");
                    i = 1 - i;
                    for (int j = 0; j < 2; j++)
                    {
                        Carte cartePioche = partie.Pioche.paquet[0];
                        partie.Joueurs[i].Main.Insert(0, cartePioche);
                        partie.Pioche.paquet.RemoveAt(0);
                    }
                    // i = 1 - i;
                    varpioche_2 = !varpioche_2;
                    MessageBox.Show("Le joueur adverse passe son tour");
                    varpass = !varpass;
                }
                else if (varpioche_4)
                {
                    MessageBox.Show("Le joueur adverse pioche 4 cartes");
                    i = 1 - i;
                    for (int j = 0; j < 4; j++)
                    {
                        Carte cartePioche = partie.Pioche.paquet[0];
                        partie.Joueurs[i].Main.Insert(0, cartePioche);
                        partie.Pioche.paquet.RemoveAt(0);
                    }
                    //i = 1 - i;
                    varpioche_4 = !varpioche_4;
                    MessageBox.Show("Le joueur adverse passe son tour");
                    varpass = !varpass;
                }
                else
                {
                    i = 1 - i;
                    MessageBox.Show("Le joueur adverse passe son tour");
                    varpass = !varpass;
                }
            }
            if (partie.Pioche.paquet.Count < 4)
            {
                partie.Remelanger();
                LB_Deck.Refresh();
                LB_defausse.Refresh();
                LB_Player1.Refresh();
                LB_Player2.Refresh();
                MessageBox.Show("Jeu remelangé !");
            }
            if (i == 0)
            {
                B_jouer1.Enabled = true;
                B_piocher1.Enabled = true;
                B_jouer2.Enabled = false;
                B_piocher2.Enabled = false;
            }
            else
            {
                B_jouer1.Enabled = false;
                B_piocher1.Enabled = false;
                B_jouer2.Enabled = true;
                B_piocher2.Enabled = true;
            }
            refresh_aff();
            mains_aff();
        }

        private void newgame()
        {
            i = 0;
            partie.refresh();
            refresh_aff();
            mains_aff();
        }

        private void win(int i)
        {
            i++;
            MessageBox.Show("Le joueur " + i + " gagne la partie");
            Close();
        }

        private void B_jouer1_Click(object sender, EventArgs e)
        {
            if (LB_Player1.SelectedItem != null)
            {
                Carte carteJoue = partie.Joueurs[0].Main[LB_Player1.SelectedIndex];
                if (carteJoue.Carte_couleur == partie.Defausse[0].Carte_couleur || carteJoue.Carte_valeur == partie.Defausse[0].Carte_valeur || carteJoue.Carte_couleur == COULEUR.NOIR)
                {
                    partie.Defausse.Insert(0, carteJoue);
                    partie.Joueurs[i].Main.RemoveAt(LB_Player1.SelectedIndex);
                    refresh_aff();
                    if (carteJoue.Carte_valeur == VALEUR.INVERS)
                    {
                        //i = 1 - i;
                        varpass = true;
                        turn();
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.PASSE)
                    {
                        //i = 1 - i;
                        varpass = true;
                        turn();
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.PLUS_DEUX)
                    {
                        //i = 1 - i;
                        varpioche_2 = true;
                        varpass = true;
                        turn();
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.PLUS_QUATRE)
                    {
                        //i = 1 - i;
                        varpioche_4 = true;
                        varpass = true;
                        do
                        {
                            choix_couleur couleur_choix = new choix_couleur();
                            couleur_choix.ShowDialog();
                            color_check = 0;
                            switch (couleur_choix.DialogResult)
                            {
                                case DialogResult.OK:
                                    MessageBox.Show("Bleu !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.BLEU;
                                    color_check = 1;
                                    break;

                                case DialogResult.Cancel:
                                    MessageBox.Show("Rouge !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.ROUGE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Abort:
                                    MessageBox.Show("jaune !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.JAUNE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Retry:
                                    MessageBox.Show("Vert !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.VERT;
                                    color_check = 1;
                                    break;
                            }
                            turn();
                        } while (color_check == 0);
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.JOKER)
                    {
                        varpass = true;
                        do
                        {
                            choix_couleur couleur_choix = new choix_couleur();
                            couleur_choix.ShowDialog();
                            color_check = 0;
                            switch (couleur_choix.DialogResult)
                            {
                                case DialogResult.OK:
                                    MessageBox.Show("Bleu !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.BLEU;
                                    color_check = 1;
                                    break;

                                case DialogResult.Cancel:
                                    MessageBox.Show("Rouge !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.ROUGE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Abort:
                                    MessageBox.Show("jaune !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.JAUNE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Retry:
                                    MessageBox.Show("Vert !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.VERT;
                                    color_check = 1;
                                    break;
                            }
                            turn();
                        } while (color_check == 0);
                    }
                    turn();
                }
                else
                {
                    MessageBox.Show("Carte invalide");
                    i = 1 - i;
                }
            }
            if (partie.Joueurs[i].Main.Count == 1 && !uno1)
            {
                MessageBox.Show("Uno !");
                uno1 = true;
            }
            else if (partie.Joueurs[i].Main.Count != 1)
            {
                uno1 = false;
            }
            if (partie.Joueurs[i].Main.Count == 0)
            {
                win(i);
            }
            i = 1 - i;
            turn();
        }

        private void B_piocher1_Click(object sender, EventArgs e)
        {
            Carte cartePioche = partie.Pioche.paquet[0];
            partie.Joueurs[i].Main.Add(cartePioche);
            partie.Pioche.paquet.RemoveAt(0);
            refresh_aff();
            if (cartePioche.Carte_couleur == partie.Defausse[0].Carte_couleur || cartePioche.Carte_valeur == partie.Defausse[0].Carte_valeur || cartePioche.Carte_couleur == COULEUR.NOIR)
            {
                MessageBox.Show("Vous pouvez jouer à nouveau !");
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas jouer, passer votre tour !");
                i = 1 - i;
                turn();
            }
            mains_aff();
        }

        private void B_jouer2_Click(object sender, EventArgs e)
        {
            if (LB_Player2.SelectedItem != null)
            {
                Carte carteJoue = partie.Joueurs[1].Main[LB_Player2.SelectedIndex];
                if (carteJoue.Carte_couleur == partie.Defausse[0].Carte_couleur || carteJoue.Carte_valeur == partie.Defausse[0].Carte_valeur || carteJoue.Carte_couleur == COULEUR.NOIR)
                {
                    partie.Defausse.Insert(0, carteJoue);
                    partie.Joueurs[i].Main.RemoveAt(LB_Player2.SelectedIndex);
                    refresh_aff();
                    if (carteJoue.Carte_valeur == VALEUR.INVERS)
                    {
                        //i = 1 - i;
                        varpass = true;
                        turn();
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.PASSE)
                    {
                        //i = 1 - i;
                        varpass = true;
                        turn();
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.PLUS_DEUX)
                    {
                        //i = 1 - i;
                        varpioche_2 = true;
                        varpass = true;
                        turn();
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.PLUS_QUATRE)
                    {
                        //i = 1 - i;
                        varpioche_4 = true;
                        varpass = true;
                        do
                        {
                            choix_couleur couleur_choix = new choix_couleur();
                            couleur_choix.ShowDialog();
                            color_check = 0;
                            switch (couleur_choix.DialogResult)
                            {
                                case DialogResult.OK:
                                    MessageBox.Show("Bleu !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.BLEU;
                                    color_check = 1;
                                    break;

                                case DialogResult.Cancel:
                                    MessageBox.Show("Rouge !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.ROUGE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Abort:
                                    MessageBox.Show("jaune !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.JAUNE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Retry:
                                    MessageBox.Show("Vert !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.VERT;
                                    color_check = 1;
                                    break;
                            }
                            turn();
                        } while (color_check == 0);
                    }
                    else if (carteJoue.Carte_valeur == VALEUR.JOKER)
                    {
                        varpass = true;
                        do
                        {
                            choix_couleur couleur_choix = new choix_couleur();
                            couleur_choix.ShowDialog();
                            color_check = 0;
                            switch (couleur_choix.DialogResult)
                            {
                                case DialogResult.OK:
                                    MessageBox.Show("Bleu !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.BLEU;
                                    color_check = 1;
                                    break;

                                case DialogResult.Cancel:
                                    MessageBox.Show("Rouge !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.ROUGE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Abort:
                                    MessageBox.Show("jaune !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.JAUNE;
                                    color_check = 1;
                                    break;

                                case DialogResult.Retry:
                                    MessageBox.Show("Vert !");
                                    partie.Defausse[0].Carte_couleur = COULEUR.VERT;
                                    color_check = 1;
                                    break;
                            }
                            turn();
                        } while (color_check == 0);
                    }
                    turn();
                }
                else
                {
                    MessageBox.Show("Carte invalide");
                    i = 1 - i;
                }
            }
            if (partie.Joueurs[i].Main.Count == 1 && !uno2)
            {
                MessageBox.Show("Uno !");
                uno2 = true;
            }
            else if (partie.Joueurs[i].Main.Count != 1)
            {
                uno2 = false;
            }
            if (partie.Joueurs[i].Main.Count == 0)
            {
                win(i);
            }
            i = 1 - i;
            turn();
        }

        private void B_piocher2_Click(object sender, EventArgs e)
        {
            Carte cartePioche = partie.Pioche.paquet[0];
            partie.Joueurs[i].Main.Add(cartePioche);
            partie.Pioche.paquet.RemoveAt(0);
            refresh_aff();
            if (cartePioche.Carte_couleur == partie.Defausse[0].Carte_couleur || cartePioche.Carte_valeur == partie.Defausse[0].Carte_valeur || cartePioche.Carte_couleur == COULEUR.NOIR)
            {
                MessageBox.Show("Vous pouvez jouer à nouveau !");
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas jouer, passer votre tour !");
                i = 1 - i;
                turn();
            }
            mains_aff();
        }

        private void B_NP_Click(object sender, EventArgs e)
        {
            i = 0;
            B_sauv.Enabled = true;
            newgame();
            turn();
        }

        private void refresh_aff()
        {
            LB_Deck.Items.Clear();
            LB_defausse.Items.Clear();
            LB_Player1.Items.Clear();
            LB_Player2.Items.Clear();
            foreach (Carte c in partie.Pioche.paquet)
            {
                LB_Deck.Items.Add(c.DisplayValue);
            }
            foreach (Carte c in partie.Joueurs[0].Main)
            {
                LB_Player1.Items.Add(c.DisplayValue);
            }
            foreach (Carte c in partie.Joueurs[1].Main)
            {
                LB_Player2.Items.Add(c.DisplayValue);
            }
            foreach (Carte c in partie.Defausse)
            {
                LB_defausse.Items.Add(c.DisplayValue);
            }
        }

        private void mains_aff()
        {
            string LocaDom = System.AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\uno_assets_2d\\PNGs\\small\\", Path.GetFullPath(Path.Combine(LocaDom, @"..\..\")));
            this.Panel_UNO.Controls.Clear();
            Images_j1.Clear();
            Images_j2.Clear();
            Panel_UNO.Refresh();

            PictureBox PBp = new PictureBox
            {
                Name = "PB_Pioche",
                Location = new Point(PB_pioche.Location.X, PB_pioche.Location.Y),
                Image = Image.FromFile(FileName + "DOS.png"),
                Width = 100,
                Height = 140,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = true
            };
            PBp.MouseClick += new MouseEventHandler(PB_click);
            this.Panel_UNO.Controls.Add(PBp);

            PictureBox PBd = new PictureBox
            {
                Name = "PB_Defausse",
                Location = new Point(PB_defausse.Location.X, PB_defausse.Location.Y),
                Image = Image.FromFile(FileName + partie.Defausse[0].DisplayValue + ".png"),
                Width = 100,
                Height = 140,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = true
            };
            this.Panel_UNO.Controls.Add(PBd);

            if (i == 0)
            {
                int jou = 0;
                foreach (Carte mainj1 in partie.Joueurs[0].Main)
                {
                    PictureBox PB = new PictureBox
                    {
                        Name = "PB_" + jou,
                        Location = new Point(30 + (60 * jou), 490),
                        Image = Image.FromFile(FileName + mainj1.DisplayValue + ".png"),
                        Width = PB_pioche.Width,
                        Height = PB_pioche.Height,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true
                    };
                    PB.MouseClick += new MouseEventHandler(PB_click);
                    Images_j1.Add(PB);
                    this.Panel_UNO.Controls.Add(Images_j1[jou]);
                    jou++;
                }

                jou = 0;
                foreach (Carte mainj2 in partie.Joueurs[1].Main)
                {
                    PictureBox PB = new PictureBox
                    {
                        Name = "PB2_" + jou,
                        Location = new Point(30 + (60 * jou), 0),
                        Image = Image.FromFile(FileName + "DOS.png"),
                        Width = PB_pioche.Width,
                        Height = PB_pioche.Height,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true
                    };

                    Images_j2.Add(PB);
                    this.Panel_UNO.Controls.Add(Images_j2[jou]);
                    jou++;
                }
            }
            else
            {
                int jou = 0;
                foreach (Carte mainj1 in partie.Joueurs[0].Main)
                {
                    PictureBox PB = new PictureBox
                    {
                        Name = "PB_" + jou,
                        Location = new Point(30 + (60 * jou), 490),

                        Image = Image.FromFile(FileName + "DOS.png"),

                        Width = PB_pioche.Width,
                        Height = PB_pioche.Height,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true
                    };
                    Images_j1.Add(PB);
                    this.Panel_UNO.Controls.Add(Images_j1[jou]);
                    jou++;
                }

                jou = 0;
                foreach (Carte mainj2 in partie.Joueurs[1].Main)
                {
                    PictureBox PB = new PictureBox
                    {
                        Name = "PB_" + jou,
                        Location = new Point(30 + (60 * jou), 0),
                        Image = Image.FromFile(FileName + mainj2.DisplayValue + ".png"),
                        Width = PB_pioche.Width,
                        Height = PB_pioche.Height,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true
                    };
                    PB.MouseClick += new MouseEventHandler(PB_click);
                    Images_j2.Add(PB);
                    this.Panel_UNO.Controls.Add(Images_j2[jou]);
                    jou++;
                }
            }
        }

        private void PB_click(object sender, EventArgs e)
        {
            var PB = (PictureBox)sender;
            if (PB.Name == "PB_Pioche") //Carte dans pioche
            {
                if (i == 0)
                {
                    B_piocher1_Click(null, null);
                }
                else
                {
                    B_piocher2_Click(null, null);
                }
            }
            else
            {
                string[] tab = PB.Name.Split('_');
                if (i == 0)
                {
                    LB_Player1.SelectedIndex = int.Parse(tab[1]);
                    PB.Top -= 30;
                    DialogResult DG1 = MessageBox.Show("Vous souhaitez jouer le " + partie.Joueurs[0].Main[LB_Player1.SelectedIndex].Carte_valeur + " " + partie.Joueurs[0].Main[LB_Player1.SelectedIndex].Carte_couleur + "?", "choix", MessageBoxButtons.YesNo);
                    if (DG1 == DialogResult.Yes)
                    {
                        B_jouer1_Click(null, null);
                    }
                }
                else
                {
                    LB_Player2.SelectedIndex = int.Parse(tab[1]);
                    PB.Top += 30;
                    DialogResult DG2 = MessageBox.Show("Vous souhaitez jouer le " + partie.Joueurs[1].Main[LB_Player2.SelectedIndex].Carte_valeur + " " + partie.Joueurs[1].Main[LB_Player2.SelectedIndex].Carte_couleur + "?", "choix", MessageBoxButtons.YesNo);
                    if (DG2 == DialogResult.Yes)
                    {
                        B_jouer2_Click(null, null);
                    }
                }
            }
            mains_aff();
        }

        private void B_admin_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                B_admin.Text = "Mode admin: OFF";
                admin = false;
                LB_Deck.Visible = LB_defausse.Visible = LB_Player1.Visible = LB_Player2.Visible = B_jouer1.Visible = B_jouer2.Visible = B_piocher1.Visible = B_piocher2.Visible = false;
            }
            else
            {
                B_admin.Text = "Mode admin: ON";
                admin = true;
                LB_Deck.Visible = LB_defausse.Visible = LB_Player1.Visible = LB_Player2.Visible = B_jouer1.Visible = B_jouer2.Visible = B_piocher1.Visible = B_piocher2.Visible = true;
            }
        }

        private void PB_pioche_Click(object sender, EventArgs e)
        {
            newgame();
        }

        private void b_triche_Click(object sender, EventArgs e)
        {
            choix_carte_triche carte_choix = new choix_carte_triche(partie, this);
            carte_choix.ShowDialog();
            if (carteText == "")
            {
                MessageBox.Show("Aucune carte sélectionnée !");
            }
            else
            {
                try
                {
                    int index = LB_Deck.Items.IndexOf(carteText);
                    Carte cartePioche = partie.Pioche.paquet[index];
                    partie.Joueurs[i].Main.Add(cartePioche);
                    partie.Pioche.paquet.RemoveAt(index);
                    refresh_aff();
                    if (cartePioche.Carte_couleur == partie.Defausse[0].Carte_couleur || cartePioche.Carte_valeur == partie.Defausse[0].Carte_valeur || cartePioche.Carte_couleur == COULEUR.NOIR)
                    {
                        MessageBox.Show("Vous pouvez jouer à nouveau !");
                    }
                    else
                    {
                        MessageBox.Show("Vous ne pouvez pas jouer, passer votre tour !");
                        i = 1 - i;
                        turn();
                    }
                    mains_aff();
                    carteText = "";
                }
                catch
                {
                    MessageBox.Show("Erreur !");
                }
            }
        }

        public string carteText
        {
            get; set;
        }

        private void B_sauv_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog()== DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.WriteLine(i);
                sw.WriteLine("/");
                foreach(Carte c in partie.Defausse)
                {
                    sw.WriteLine(c.Carte_couleur + "|" + c.Carte_valeur + "|" + c.Carte_score);
                }
                sw.WriteLine("/");
                foreach (Carte c in partie.Joueurs[0].Main)
                {
                    sw.WriteLine(c.Carte_couleur + "|" + c.Carte_valeur + "|" + c.Carte_score);
                }
                sw.WriteLine("/");
                foreach (Carte c in partie.Joueurs[1].Main)
                {
                    sw.WriteLine(c.Carte_couleur + "|" + c.Carte_valeur + "|" + c.Carte_score);
                }
                sw.WriteLine("/");
                foreach (Carte c in partie.Pioche.paquet)
                {
                    sw.WriteLine(c.Carte_couleur + "|" + c.Carte_valeur + "|" + c.Carte_score);
                }
                sw.WriteLine("/");
                sw.Close();
            }
        }
    }
}