using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace GD_UNO_2021
{
    public partial class EcranTerrain_LAN : Form
    {
        public jeu partie = new jeu();
        public int color_check = 0;
        public bool Bconnect = false;
        public Paquet Paquet_jeu = new Paquet();
        private List<PictureBox> Images_main = new List<PictureBox>();
        private List<PictureBox> Images_adv = new List<PictureBox>();
        private TcpClient _clientTCP;
        private IPAddress _serveur;
        private byte[] receivedBuf = new byte[1024];
        private string joueur;
        private int QuiJoueTour;
        private int aGagner = 0;
        private int test = 1;

        public EcranTerrain_LAN()
        {
            InitializeComponent();
            test = 1;
            aGagner = 0;
            CheckForIllegalCrossThreadCalls = false;
        }

        #region connexion au serveur

        private void B_connect_Click(object sender, EventArgs e)
        {
            if (TB_pseudo.Text.Length > 0)
            {
                _serveur = AdresseValide(TB_IP.Text);
                if (_serveur == null)
                {
                    MessageBox.Show("Adresse invalide !");
                }
                else
                {
                    _clientTCP = new TcpClient();
                    Thread t = new Thread(LoopConnect);
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                MessageBox.Show("Insérer un pseudo !");
            }
        }

        private void LoopConnect()
        {
            B_connect.Enabled = false;
            B_disconnect.Enabled = false;
            int attempts = 0;
            while (!_clientTCP.Connected && attempts <= 20)
            {
                try
                {
                    attempts++;
                    IPAddress tmpIP = AdresseValide(TB_IP.Text);
                    if (tmpIP != null)
                        _clientTCP.Connect(_serveur, 9000);
                }
                catch (SocketException)
                {
                    RTB_chat.AppendText("\nConnection attempts: " + attempts.ToString());
                    RTB_chat.Focus();
                }
            }
            if (attempts <= 20)
            {
                RTB_chat.AppendText("\nConnected!");
                NetworkStream flux = _clientTCP.GetStream();
                BinaryReader br = new BinaryReader(flux);
                BinaryWriter bw = new BinaryWriter(flux);
                bw.Write("@newClient@");
                bw.Flush();
                string com = br.ReadString();
                RTB_chat.AppendText("\n" + com);
                com = string.Join("", com.Split('@'));
                switch (com)
                {
                    case "j1":
                        RTB_chat.AppendText("\nVous êtes le joueur 1");
                        joueur = "j1";
                        QuiJoueTour = 1;
                        this.Text = "Écran joueur 1";
                        break;

                    case "j2":
                        RTB_chat.AppendText("\nVous êtes le joueur 2");
                        joueur = "j2";
                        QuiJoueTour = 1;
                        this.Text = "Écran joueur 2";
                        break;

                    default:
                        MessageBox.Show("Erreur ? " + com);
                        break;
                }
                bw.Write(TB_pseudo.Text);
                bw.Flush();
                B_connect.Enabled = false;
                Bconnect = true;
                Thread t = new Thread(ListenServer);
                t.Name = "ListenServ";
                t.IsBackground = true;
                t.Start(_clientTCP);
                B_connect.Enabled = false;
                B_disconnect.Enabled = true;
            }
            else
            {
                RTB_chat.AppendText("\nServeur introuvale (+20 essais de connexion)!");
                B_connect.Enabled = true;
            }
        }

        private IPAddress AdresseValide(string nomPC)
        {
            IPAddress ipReponse = null;
            if (nomPC.Length > 0)
            {
                IPAddress[] ipsMachine = Dns.GetHostEntry(nomPC).AddressList;
                for (int i = 0; i < ipsMachine.Length; i++)
                {
                    Ping ping = new Ping();
                    PingReply pingReponse = ping.Send(ipsMachine[i]);
                    if (pingReponse.Status == IPStatus.Success)
                        if (ipsMachine[i].AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipReponse = ipsMachine[i];
                            break;
                        }
                }
            }
            return ipReponse;
        }

        #endregion connexion au serveur

        #region gestion des paquets

        private void ListenServer(object clientTCP)
        {
            TcpClient client = (TcpClient)clientTCP;
            string input = string.Empty;
            BinaryReader br = null;
            BinaryWriter bw = null;
            try
            {
                br = new BinaryReader(client.GetStream());
                bw = new BinaryWriter(client.GetStream());
                while (client.Connected && Bconnect == true)
                {
                    input = br.ReadString(); // stop ici en attendant un message
                    input = string.Join("", input.Split('@'));
                    switch (input)
                    {
                        case "distrib":
                            {
                                Paquet pqTmp = new Paquet();
                                pqTmp.paquet = Deserialize(client.GetStream());
                                foreach (Carte c in pqTmp.paquet)
                                {
                                    LB_Deck.Items.Add(c.DisplayValue);
                                }
                                partie.RefreshLan(pqTmp);
                                RefreshLB();
                                mains_aff_LAN(QuiJoueTour);
                                break;
                            }
                        case "disco":
                            {
                                DisconnectFromServer(1);
                                break;
                            }
                        case "msg":
                            {
                                string msg = br.ReadString();
                                RTB_chat.Text += "\nMessage admin: " + msg;
                                break;
                            }
                        case "advjoue":
                            {
                                Carte cTmp = new Carte();
                                cTmp = DeserializeCard(client.GetStream());
                                int SI = br.ReadInt32();
                                if (joueur == "j1")
                                {
                                    RTB_chat.Text += "\n @j2play@:" + cTmp.DisplayValue;
                                    if (cTmp.Carte_valeur == VALEUR.PLUS_DEUX)
                                    {
                                        RTB_chat.Text += "\nVous devez piochez 2 cartes !";
                                        for (int j = 0; j < 2; j++)
                                        {
                                            Carte cartePioche = partie.Pioche.paquet[0];
                                            partie.Joueurs[0].Main.Insert(0, cartePioche);
                                            partie.Pioche.paquet.RemoveAt(0);
                                        }
                                        RTB_chat.Text += "\nVous devez passer votre tour !";
                                        partie.Joueurs[1].Main.RemoveAt(SI);
                                        QuiJoueTour = 2;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                    else if (cTmp.Carte_valeur == VALEUR.PLUS_QUATRE)
                                    {
                                        RTB_chat.Text += "\nVous devez piochez 4 cartes !";
                                        for (int j = 0; j < 4; j++)
                                        {
                                            Carte cartePioche = partie.Pioche.paquet[0];
                                            partie.Joueurs[0].Main.Insert(0, cartePioche);
                                            partie.Pioche.paquet.RemoveAt(0);
                                        }
                                        RTB_chat.Text += "\nVous devez passer votre tour !";
                                        partie.Joueurs[1].Main.RemoveAt(SI);
                                        QuiJoueTour = 2;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                    else if (cTmp.Carte_valeur == VALEUR.INVERS || cTmp.Carte_valeur == VALEUR.PASSE)
                                    {
                                        RTB_chat.Text += "\nVous devez passer votre tour !";
                                        partie.Joueurs[1].Main.RemoveAt(SI);
                                        QuiJoueTour = 2;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                    else
                                    {
                                        partie.Joueurs[1].Main.RemoveAt(SI);
                                        QuiJoueTour = 1;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                }
                                else if (joueur == "j2")
                                {
                                    RTB_chat.Text += "\n @j1play@:" + cTmp.DisplayValue;
                                    if (cTmp.Carte_valeur == VALEUR.PLUS_DEUX)
                                    {
                                        RTB_chat.Text += "Vous devez piochez 2 cartes !";
                                        for (int j = 0; j < 2; j++)
                                        {
                                            Carte cartePioche = partie.Pioche.paquet[0];
                                            partie.Joueurs[1].Main.Insert(0, cartePioche);
                                            partie.Pioche.paquet.RemoveAt(0);
                                        }
                                        RTB_chat.Text += "Vous devez passer votre tour !";
                                        partie.Joueurs[0].Main.RemoveAt(SI);
                                        QuiJoueTour = 1;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                    else if (cTmp.Carte_valeur == VALEUR.PLUS_QUATRE)
                                    {
                                        RTB_chat.Text += "Vous devez piochez 4 cartes !";
                                        for (int j = 0; j < 4; j++)
                                        {
                                            Carte cartePioche = partie.Pioche.paquet[0];
                                            partie.Joueurs[1].Main.Insert(0, cartePioche);
                                            partie.Pioche.paquet.RemoveAt(0);
                                        }
                                        RTB_chat.Text += "Vous devez passer votre tour !";
                                        partie.Joueurs[0].Main.RemoveAt(SI);
                                        QuiJoueTour = 1;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                    else if (cTmp.Carte_valeur == VALEUR.INVERS || cTmp.Carte_valeur == VALEUR.PASSE)
                                    {
                                        RTB_chat.Text += "Vous devez passer votre tour !";
                                        partie.Joueurs[0].Main.RemoveAt(SI);
                                        QuiJoueTour = 1;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                    else
                                    {
                                        partie.Joueurs[0].Main.RemoveAt(SI);
                                        QuiJoueTour = 2;
                                        RefreshLB();
                                        mains_aff_LAN(QuiJoueTour);
                                    }
                                }
                                partie.Defausse.Insert(0, cTmp);
                                RefreshLB();
                                break;
                            }
                        case "advpiocheNJ":
                            {
                                Carte cartePioche = partie.Pioche.paquet[0];
                                if (joueur == "j1")
                                {
                                    partie.Joueurs[1].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                    QuiJoueTour = 1;
                                    RefreshLB();
                                    mains_aff_LAN(QuiJoueTour);
                                }
                                else if (joueur == "j2")
                                {
                                    partie.Joueurs[0].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                    QuiJoueTour = 2;
                                    RefreshLB();
                                    mains_aff_LAN(QuiJoueTour);
                                }
                                break;
                            }
                        case "advpiocheJ":
                            {
                                Carte cartePioche = partie.Pioche.paquet[0];
                                if (joueur == "j1")
                                {
                                    partie.Joueurs[1].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                    QuiJoueTour = 2;
                                    RefreshLB();
                                    mains_aff_LAN(QuiJoueTour);
                                }
                                else if (joueur == "j2")
                                {
                                    partie.Joueurs[0].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                    QuiJoueTour = 1;
                                    RefreshLB();
                                    mains_aff_LAN(QuiJoueTour);
                                }
                                break;
                            }
                        case "perdu":
                            {
                                MessageBox.Show("Vous avez perdu la partie !");
                                LB_Deck.Items.Clear();
                                LB_defausse.Items.Clear();
                                LB_MainJoueur.Items.Clear();
                                LB_MainAdverse.Items.Clear();
                                Images_main.Clear();
                                Images_adv.Clear();
                                Panel_UNO_LAN.Controls.Clear();
                                this.Close();
                                break;
                            }
                        case "win":
                            {
                                MessageBox.Show("Vous avez gagné ! (Abandon de l'adversaire)");
                                aGagner = 1;
                                DisconnectFromServer(aGagner);
                                this.Close();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                if (test == 1)
                {
                    RTB_chat.AppendText("\nConnexion perdu avec le serveur ! " + ex.ToString());
                    _clientTCP.Dispose();
                    _clientTCP.Close();
                    B_connect.Enabled = true;
                    B_disconnect.Enabled = false;
                }
            }
        }

        private Carte DeserializeCard(NetworkStream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (Carte)bf.Deserialize(stream);
        }

        private List<Carte> Deserialize(NetworkStream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (List<Carte>)bf.Deserialize(stream);
        }

        private static void SendSerial(NetworkStream stream, object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, obj);
        }

        #endregion gestion des paquets

        private void B_disconnect_Click(object sender, EventArgs e)
        {
            if(DisconnectFromServer(aGagner)==true)
            {
                this.Close();
            }
        }

        private bool DisconnectFromServer(int i)
        {
            if (i == 0)
            {
                DialogResult DG = MessageBox.Show("Voulez vous vraiment Quitter (si une partie est en cours cela sera comptez comme un abandon) ?", "Choix", MessageBoxButtons.YesNo);
                if (DG == DialogResult.Yes)
                {
                    NetworkStream NS = _clientTCP.GetStream();
                    BinaryWriter bw = new BinaryWriter(NS);
                    if (joueur == "j1")
                    {
                        bw.Write("@j1Ab@");
                        bw.Flush();
                    }
                    else
                    {
                        bw.Write("@j2Ab@");
                        bw.Flush();
                    }
                    test = 0;
                    _clientTCP.Close();
                    RTB_chat.AppendText("\nDisconnected from the server!");
                    Bconnect = false;
                    B_connect.Enabled = true;
                    B_disconnect.Enabled = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                test = 0;
                return true;
            }
        }

        #region methode de jeu

        private void RefreshLB()
        {
            LB_Deck.Items.Clear();
            LB_defausse.Items.Clear();
            LB_MainAdverse.Items.Clear();
            LB_MainJoueur.Items.Clear();
            partie.Joueurs[0].TrierMain();
            partie.Joueurs[1].TrierMain();
            if (joueur == "j1")
            {
                foreach (Carte c in partie.Joueurs[0].Main)
                {
                    LB_MainJoueur.Items.Add(c.DisplayValue);
                }
                foreach (Carte c in partie.Joueurs[1].Main)
                {
                    LB_MainAdverse.Items.Add(c.DisplayValue);
                }
            }
            else if (joueur == "j2")
            {
                foreach (Carte c in partie.Joueurs[0].Main)
                {
                    LB_MainAdverse.Items.Add(c.DisplayValue);
                }
                foreach (Carte c in partie.Joueurs[1].Main)
                {
                    LB_MainJoueur.Items.Add(c.DisplayValue);
                }
            }
            foreach (Carte c in partie.Pioche.paquet)
            {
                LB_Deck.Items.Add(c.DisplayValue);
            }
            foreach (Carte c in partie.Defausse)
            {
                LB_defausse.Items.Add(c.DisplayValue);
            }
        }

        private void mains_aff_LAN(int QuiJoue)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                string LocaDom = System.AppDomain.CurrentDomain.BaseDirectory;
                string FileName = string.Format("{0}Resources\\uno_assets_2d\\PNGs\\small\\", Path.GetFullPath(Path.Combine(LocaDom, @"..\..\")));
                Panel_UNO_LAN.Controls.Clear();
                Images_main.Clear();
                Images_adv.Clear();
                Panel_UNO_LAN.Refresh();

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
                Panel_UNO_LAN.Controls.Add(PBp);

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
                Panel_UNO_LAN.Controls.Add(PBd);

                if (joueur == "j1")
                {
                    int jou = 0;
                    foreach (Carte mainJ in partie.Joueurs[0].Main)
                    {
                        if (QuiJoue == 1)
                        {
                            PictureBox PB = new PictureBox
                            {
                                Name = "PB1_" + jou,
                                Location = new Point(30 + (60 * jou), 490),
                                Image = Image.FromFile(FileName + mainJ.DisplayValue + ".png"),
                                Width = PB_pioche.Width,
                                Height = PB_pioche.Height,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Visible = true,
                                Enabled = true
                            };
                            PB.MouseClick += new MouseEventHandler(PB_click);
                            Images_main.Add(PB);
                            this.Panel_UNO_LAN.Controls.Add(Images_main[jou]);
                            jou++;
                        }
                        else
                        {
                            PictureBox PB = new PictureBox
                            {
                                Name = "PB1_" + jou,
                                Location = new Point(30 + (60 * jou), 490),
                                Image = Image.FromFile(FileName + mainJ.DisplayValue + ".png"),
                                Width = PB_pioche.Width,
                                Height = PB_pioche.Height,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Visible = true,
                                Enabled = false
                            };
                            PB.MouseClick += new MouseEventHandler(PB_click);
                            Images_main.Add(PB);
                            this.Panel_UNO_LAN.Controls.Add(Images_main[jou]);
                            jou++;
                        }
                    }

                    jou = 0;
                    foreach (Carte mainAd in partie.Joueurs[1].Main)
                    {
                        PictureBox PB = new PictureBox
                        {
                            Name = "PB2_" + jou,
                            Location = new Point(30 + (60 * jou), 0),
                            Image = Image.FromFile(FileName + "DOS.png"),
                            Width = PB_pioche.Width,
                            Height = PB_pioche.Height,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Visible = true,
                            Enabled = false
                        };

                        Images_adv.Add(PB);
                        this.Panel_UNO_LAN.Controls.Add(Images_adv[jou]);
                        jou++;
                    }
                }
                else if (joueur == "j2")
                {
                    int jou = 0;
                    foreach (Carte mainJ in partie.Joueurs[1].Main)
                    {
                        if (QuiJoue == 1)
                        {
                            PictureBox PB = new PictureBox
                            {
                                Name = "PB2_" + jou,
                                Location = new Point(30 + (60 * jou), 490),
                                Image = Image.FromFile(FileName + mainJ.DisplayValue + ".png"),
                                Width = PB_pioche.Width,
                                Height = PB_pioche.Height,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Visible = true,
                                Enabled = false
                            };
                            PB.MouseClick += new MouseEventHandler(PB_click);
                            Images_main.Add(PB);
                            this.Panel_UNO_LAN.Controls.Add(Images_main[jou]);
                            jou++;
                        }
                        else
                        {
                            PictureBox PB = new PictureBox
                            {
                                Name = "PB2_" + jou,
                                Location = new Point(30 + (60 * jou), 490),
                                Image = Image.FromFile(FileName + mainJ.DisplayValue + ".png"),
                                Width = PB_pioche.Width,
                                Height = PB_pioche.Height,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Visible = true,
                                Enabled = true
                            };
                            PB.MouseClick += new MouseEventHandler(PB_click);
                            Images_main.Add(PB);
                            this.Panel_UNO_LAN.Controls.Add(Images_main[jou]);
                            jou++;
                        }
                    }
                    jou = 0;
                    foreach (Carte mainAd in partie.Joueurs[0].Main)
                    {
                        PictureBox PB = new PictureBox
                        {
                            Name = "PB1_" + jou,
                            Location = new Point(30 + (60 * jou), 0),
                            Image = Image.FromFile(FileName + "DOS.png"),
                            Width = PB_pioche.Width,
                            Height = PB_pioche.Height,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Visible = true
                        };
                        Images_adv.Add(PB);
                        this.Panel_UNO_LAN.Controls.Add(Images_adv[jou]);
                        jou++;
                    }
                }

                if (QuiJoue == 1 && joueur == "j1")
                {
                    TB_tour.BackColor = Color.Green;
                    TB_tour.Text = "C'est à vous de jouer !";
                }
                else if (QuiJoue == 2 && joueur == "j2")
                {
                    TB_tour.BackColor = Color.Green;
                    TB_tour.Text = "C'est à vous de jouer !";
                }
                else
                {
                    TB_tour.BackColor = Color.Red;
                    TB_tour.Text = "C'est au tour de l'adversaire !";
                }
            });
        }

        private void PB_click(object sender, MouseEventArgs e)
        {
            var PB = (PictureBox)sender;
            if (PB.Name == "PB_Pioche") //Carte dans pioche
            {
                DialogResult DG = MessageBox.Show("Voulez vous vraiment piocher ?", "Choix", MessageBoxButtons.YesNo);
                if (DG == DialogResult.Yes)
                {
                    if (QuiJoueTour == 1 && joueur == "j1")
                    {
                        Pioche_to_server(joueur);
                    }
                    else if (QuiJoueTour == 2 && joueur == "j2")
                    {
                        Pioche_to_server(joueur);
                    }
                    else
                    {
                        MessageBox.Show("Attendez votre tour pour piocher !");
                    }
                }
            }
            else
            {
                string[] tab = PB.Name.Split('_');
                LB_MainJoueur.SelectedIndex = int.Parse(tab[1]);
                PB.Top -= 30;
                int o = 0;
                if (joueur == "j1")
                {
                    o = 0;
                }
                else
                {
                    o = 1;
                }
                DialogResult DG = MessageBox.Show("Vous souhaitez jouer le " + partie.Joueurs[o].Main[LB_MainJoueur.SelectedIndex].Carte_valeur + " " + partie.Joueurs[o].Main[LB_MainJoueur.SelectedIndex].Carte_couleur + "?", "choix", MessageBoxButtons.YesNo);
                if (DG == DialogResult.Yes)
                {
                    Joueur_to_server(joueur);
                }
            }
            mains_aff_LAN(QuiJoueTour);
        }

        private void Joueur_to_server(string joueur)
        {
            NetworkStream NS = _clientTCP.GetStream();
            BinaryWriter bw = new BinaryWriter(NS);
            Carte carteJoue;
            if (joueur == "j1")
            {
                carteJoue = partie.Joueurs[0].Main[LB_MainJoueur.SelectedIndex];
                if (carteJoue.Carte_couleur == partie.Defausse[0].Carte_couleur || carteJoue.Carte_valeur == partie.Defausse[0].Carte_valeur || carteJoue.Carte_couleur == COULEUR.NOIR)
                {
                    switch (carteJoue.Carte_valeur)
                    {
                        case VALEUR.ZERO:
                        case VALEUR.UN:
                        case VALEUR.DEUX:
                        case VALEUR.TROIS:
                        case VALEUR.QUATRE:
                        case VALEUR.CINQ:
                        case VALEUR.SIX:
                        case VALEUR.SEPT:
                        case VALEUR.HUIT:
                        case VALEUR.NEUF:
                            {
                                bw.Write("@j1play@");
                                RTB_chat.Text += "\n @j1play@ :" + carteJoue.DisplayValue;
                                bw.Flush();
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                QuiJoueTour = 2;
                                break;
                            }
                        case VALEUR.PASSE:
                        case VALEUR.INVERS:
                            {
                                bw.Write("@j1play@");
                                RTB_chat.Text += "\n @j1play@ :" + carteJoue.DisplayValue;
                                bw.Flush();
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                QuiJoueTour = 1;
                                break;
                            }
                        case VALEUR.PLUS_DEUX:
                            {
                                bw.Write("@j1play@");
                                RTB_chat.Text += "\n @j1play@ :" + carteJoue.DisplayValue;
                                bw.Flush();
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                for (int j = 0; j < 2; j++)
                                {
                                    Carte cartePioche = partie.Pioche.paquet[0];
                                    partie.Joueurs[1].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                }
                                QuiJoueTour = 1;
                                break;
                            }
                        case VALEUR.PLUS_QUATRE:
                            {
                                bw.Write("@j1play@");
                                bw.Flush();
                                do
                                {
                                    choix_couleur couleur_choix = new choix_couleur();
                                    couleur_choix.ShowDialog();
                                    color_check = 0;
                                    switch (couleur_choix.DialogResult)
                                    {
                                        case DialogResult.OK:
                                            RTB_chat.Text += "Bleu !";
                                            carteJoue.Carte_couleur = COULEUR.BLEU;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Cancel:
                                            RTB_chat.Text += "Rouge !";
                                            carteJoue.Carte_couleur = COULEUR.ROUGE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Abort:
                                            RTB_chat.Text += "jaune !";
                                            carteJoue.Carte_couleur = COULEUR.JAUNE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Retry:
                                            RTB_chat.Text += "Vert !";
                                            carteJoue.Carte_couleur = COULEUR.VERT;
                                            color_check = 1;
                                            break;
                                    }
                                } while (color_check == 0);
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                RTB_chat.Text += "\n @j1play@ :" + carteJoue.DisplayValue;
                                color_check = 0;
                                for (int j = 0; j < 4; j++)
                                {
                                    Carte cartePioche = partie.Pioche.paquet[0];
                                    partie.Joueurs[1].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                }
                                QuiJoueTour = 1;
                                break;
                            }
                        case VALEUR.JOKER:
                            {
                                bw.Write("@j1play@");
                                bw.Flush();
                                do
                                {
                                    choix_couleur couleur_choix = new choix_couleur();
                                    couleur_choix.ShowDialog();
                                    color_check = 0;
                                    switch (couleur_choix.DialogResult)
                                    {
                                        case DialogResult.OK:
                                            RTB_chat.Text += "Bleu !";
                                            carteJoue.Carte_couleur = COULEUR.BLEU;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Cancel:
                                            RTB_chat.Text += "Rouge !";
                                            carteJoue.Carte_couleur = COULEUR.ROUGE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Abort:
                                            RTB_chat.Text += "jaune !";
                                            carteJoue.Carte_couleur = COULEUR.JAUNE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Retry:
                                            RTB_chat.Text += "Vert !";
                                            carteJoue.Carte_couleur = COULEUR.VERT;
                                            color_check = 1;
                                            break;
                                    }
                                } while (color_check == 0);
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                QuiJoueTour = 2;
                                RTB_chat.Text += "\n @j1play@ :" + carteJoue.DisplayValue;
                                color_check = 0;
                                break;
                            }
                        default:
                            RTB_chat.Text += "\n @j1play@ : erreur";
                            break;
                    }
                    partie.Defausse.Insert(0, carteJoue);
                    bw.Write(LB_MainJoueur.SelectedIndex);
                    partie.Joueurs[0].Main.RemoveAt(LB_MainJoueur.SelectedIndex);
                    RefreshLB();
                    mains_aff_LAN(QuiJoueTour);
                }
                else
                {
                    RTB_chat.Text += " \n Carte invalide !";
                }
            }
            else
            {
                carteJoue = partie.Joueurs[1].Main[LB_MainJoueur.SelectedIndex];
                if (carteJoue.Carte_couleur == partie.Defausse[0].Carte_couleur || carteJoue.Carte_valeur == partie.Defausse[0].Carte_valeur || carteJoue.Carte_couleur == COULEUR.NOIR)
                {
                    switch (carteJoue.Carte_valeur)
                    {
                        case VALEUR.ZERO:
                        case VALEUR.UN:
                        case VALEUR.DEUX:
                        case VALEUR.TROIS:
                        case VALEUR.QUATRE:
                        case VALEUR.CINQ:
                        case VALEUR.SIX:
                        case VALEUR.SEPT:
                        case VALEUR.HUIT:
                        case VALEUR.NEUF:
                            {
                                bw.Write("@j2play@");
                                RTB_chat.Text += "\n @j2play@ :" + carteJoue.DisplayValue;
                                bw.Flush();
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                QuiJoueTour = 1;
                                break;
                            }
                        case VALEUR.PASSE:
                        case VALEUR.INVERS:
                            {
                                bw.Write("@j2play@");
                                RTB_chat.Text += "\n @j2play@ :" + carteJoue.DisplayValue;
                                bw.Flush();
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                QuiJoueTour = 2;
                                break;
                            }
                        case VALEUR.PLUS_DEUX:
                            {
                                bw.Write("@j2play@");
                                RTB_chat.Text += "\n @j2play@ :" + carteJoue.DisplayValue;
                                bw.Flush();
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                for (int j = 0; j < 2; j++)
                                {
                                    Carte cartePioche = partie.Pioche.paquet[0];
                                    partie.Joueurs[0].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                }
                                QuiJoueTour = 2;
                                break;
                            }
                        case VALEUR.PLUS_QUATRE:
                            {
                                bw.Write("@j2play@");
                                bw.Flush();
                                do
                                {
                                    choix_couleur couleur_choix = new choix_couleur();
                                    couleur_choix.ShowDialog();
                                    color_check = 0;
                                    switch (couleur_choix.DialogResult)
                                    {
                                        case DialogResult.OK:
                                            RTB_chat.Text += "Bleu !";
                                            carteJoue.Carte_couleur = COULEUR.BLEU;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Cancel:
                                            RTB_chat.Text += "Rouge !";
                                            carteJoue.Carte_couleur = COULEUR.ROUGE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Abort:
                                            RTB_chat.Text += "jaune !";
                                            carteJoue.Carte_couleur = COULEUR.JAUNE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Retry:
                                            RTB_chat.Text += "Vert !";
                                            carteJoue.Carte_couleur = COULEUR.VERT;
                                            color_check = 1;
                                            break;
                                    }
                                } while (color_check == 0);
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                RTB_chat.Text += "\n @j2play@ :" + carteJoue.DisplayValue;
                                color_check = 0;
                                for (int j = 0; j < 4; j++)
                                {
                                    Carte cartePioche = partie.Pioche.paquet[0];
                                    partie.Joueurs[0].Main.Insert(0, cartePioche);
                                    partie.Pioche.paquet.RemoveAt(0);
                                }
                                QuiJoueTour = 2;
                                break;
                            }
                        case VALEUR.JOKER:
                            {
                                bw.Write("@j2play@");
                                bw.Flush();
                                do
                                {
                                    choix_couleur couleur_choix = new choix_couleur();
                                    couleur_choix.ShowDialog();
                                    color_check = 0;
                                    switch (couleur_choix.DialogResult)
                                    {
                                        case DialogResult.OK:
                                            RTB_chat.Text += "Bleu !";
                                            carteJoue.Carte_couleur = COULEUR.BLEU;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Cancel:
                                            RTB_chat.Text += "Rouge !";
                                            carteJoue.Carte_couleur = COULEUR.ROUGE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Abort:
                                            RTB_chat.Text += "jaune !";
                                            carteJoue.Carte_couleur = COULEUR.JAUNE;
                                            color_check = 1;
                                            break;

                                        case DialogResult.Retry:
                                            RTB_chat.Text += "Vert !";
                                            carteJoue.Carte_couleur = COULEUR.VERT;
                                            color_check = 1;
                                            break;
                                    }
                                } while (color_check == 0);
                                SendSerial(NS, carteJoue);
                                _clientTCP.GetStream().Flush();
                                RTB_chat.Text += "\n @j2play@ :" + carteJoue.DisplayValue;
                                color_check = 0;
                                QuiJoueTour = 1;
                                break;
                            }
                        default:
                            RTB_chat.Text += "\n @j2play@ : erreur";
                            break;
                    }
                    partie.Defausse.Insert(0, carteJoue);
                    bw.Write(LB_MainJoueur.SelectedIndex);
                    partie.Joueurs[1].Main.RemoveAt(LB_MainJoueur.SelectedIndex);
                    RefreshLB();
                    mains_aff_LAN(QuiJoueTour);
                }
                else
                {
                    RTB_chat.Text += " \n Carte invalide !";
                }
            }
            _clientTCP.GetStream().Flush();
            check_win();
        }

        private void check_win()
        {
            int o;
            if (joueur == "j1")
                o = 0;
            else
                o = 1;
            if (partie.Joueurs[o].Main.Count == 0)
            {
                MessageBox.Show("Le Joueur " + (o + 1) + " gagne la partie !");
                NetworkStream NS = _clientTCP.GetStream();
                BinaryWriter bw = new BinaryWriter(NS);
                bw.Write("@j" + (o + 1) + "win@");
                bw.Flush();
                this.Close();
            }
            else if(partie.Joueurs[0].Main.Count == 1)
            {
                RTB_chat.AppendText("\n@j1@: UNO!");
            }
            else if(partie.Joueurs[1].Main.Count == 1)
            {
                RTB_chat.AppendText("\n@j2@: UNO!");
            }
        }

        private void Pioche_to_server(string joueur)
        {
            NetworkStream NS = _clientTCP.GetStream();
            BinaryWriter bw = new BinaryWriter(NS);
            Carte cartePioche = partie.Pioche.paquet[0];
            if (joueur == "j1")
            {
                partie.Joueurs[0].Main.Insert(0, cartePioche);
                if (cartePioche.Carte_couleur == partie.Defausse[0].Carte_couleur || cartePioche.Carte_valeur == partie.Defausse[0].Carte_valeur || cartePioche.Carte_couleur == COULEUR.NOIR)
                {
                    bw.Write("@j1piocheJ@");
                    bw.Flush();
                    RTB_chat.Text += " \n Vous pouvez jouer à nouveau !";
                    partie.Pioche.paquet.RemoveAt(0);
                    QuiJoueTour = 1;
                    RefreshLB();
                    mains_aff_LAN(QuiJoueTour);
                }
                else
                {
                    bw.Write("@j1piocheNJ@");
                    bw.Flush();
                    partie.Pioche.paquet.RemoveAt(0);
                    QuiJoueTour = 2;
                    RefreshLB();
                    mains_aff_LAN(QuiJoueTour);
                }
            }
            else if (joueur == "j2")
            {
                partie.Joueurs[1].Main.Insert(0, cartePioche);
                if (cartePioche.Carte_couleur == partie.Defausse[0].Carte_couleur || cartePioche.Carte_valeur == partie.Defausse[0].Carte_valeur || cartePioche.Carte_couleur == COULEUR.NOIR)
                {
                    bw.Write("@j2piocheJ@");
                    bw.Flush();
                    RTB_chat.Text += " \n Vous pouvez jouer à nouveau !";
                    partie.Pioche.paquet.RemoveAt(0);
                    QuiJoueTour = 2;
                    RefreshLB();
                    mains_aff_LAN(QuiJoueTour);
                }
                else
                {
                    bw.Write("@j2piocheNJ@");
                    bw.Flush();
                    partie.Pioche.paquet.RemoveAt(0);
                    QuiJoueTour = 1;
                    RefreshLB();
                    mains_aff_LAN(QuiJoueTour);
                }
            }
            _clientTCP.GetStream().Flush();
        }

        #endregion methode de jeu

        private void EcranTerrain_LAN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "j1" || this.Text == "j2")
            {
                if (DisconnectFromServer(aGagner) == false)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}