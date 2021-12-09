using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GD_UNO_2021
{
    public partial class EcranServ : Form
    {
        public int count = 0;
        private byte[] _buffer = new byte[1024];
        public jeu NewGame = new jeu();
        public List<TCP_Client_CG> _ClientTCP { get; set; }
        private List<string> _names = new List<string>();
        private TcpListener serverTCPl;
        public int bouc = 1;
        private int maxJoueur = 2;
        public int nombreConnect = 0;
        Dictionary<string, Thread> threadDictionary = new Dictionary<string, Thread>();

        public EcranServ()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void EcranServ_Load(object sender, EventArgs e)
        {
            _ClientTCP = new List<TCP_Client_CG>();
            foreach (Carte c in NewGame.Pioche.paquet)
            {
                LB_deck.Items.Add(c.DisplayValue.ToString());
            }
        }

        #region démarrage et recherche des client

        private void SetupServer()
        {
            string IPadd = TB_add.Text;
            int port = int.Parse(TB_port.Text);
            LB_console.Items.Add("Démarrage server . . .");
            B_stop.Enabled = true;
            Thread t = new Thread(ListenClient);
            t.Name = "ClientListenerThread";
            t.IsBackground = true;
            //threadDictionary.Add(t.Name, t);
            t.Start();
        } //démarrage

        private void ListenClient()
        {
            try
            {
                int port = int.Parse(TB_port.Text);
                IPAddress ipLocal = AdresseValide(Dns.GetHostName());
                if (ipLocal != null)
                {
                    nombreConnect = 0;
                    serverTCPl = new TcpListener(ipLocal, port);
                    serverTCPl.Start();
                    B_start.Enabled = false;
                    LB_console.Items.Add("Serveur démarré");
                    List<TcpClient> cli = new List<TcpClient>();
                    List<NetworkStream> flux = new List<NetworkStream>();
                    _ClientTCP = new List<TCP_Client_CG>();
                    while (nombreConnect < maxJoueur) //scan de recherche de client
                    {
                        TcpClient TCPtmp = serverTCPl.AcceptTcpClient();
                        cli.Add(TCPtmp);
                        NetworkStream Tmpflux = cli[nombreConnect].GetStream();
                        flux.Add(Tmpflux);
                        BinaryWriter bw = new BinaryWriter(flux[nombreConnect]);
                        bw.Write("@j" + (nombreConnect + 1) + "@");
                        BinaryReader br = new BinaryReader(flux[nombreConnect]);
                        string tTmp = br.ReadString();
                        if (tTmp == "@newClient@")
                        {
                            TCP_Client_CG CG_tmp = new TCP_Client_CG(cli[nombreConnect]);
                            _ClientTCP.Add(CG_tmp);
                            string tmpName = br.ReadString();
                            _ClientTCP[nombreConnect]._Client = cli[nombreConnect];
                            _ClientTCP[nombreConnect]._Name = tmpName;
                            LB_user.Items.Add("Client " + (nombreConnect + 1) + " : " + tmpName);
                            Thread t = new Thread(ListenComClient);
                            t.IsBackground = true;
                            t.Name = "threadListenClient" + nombreConnect;
                            //threadDictionary.Add(t.Name, t);
                            t.Start(nombreConnect);
                            nombreConnect++;
                            TB_num.Text = nombreConnect.ToString();
                        }
                        LB_console.Items.Add("Client trouvé !");
                    }
                    b_NG.Enabled = true;
                    LB_console.Items.Add("Tout les clients sont connecté");
                }
            }
            catch (SocketException se)
            {
                LB_console.Items.Add("Probleme démarrage serveur.");
                LB_console.Items.Add(se.ToString());
            }
            catch (Exception ex)
            {
                LB_console.Items.Add("Probleme démarrage serveur.");
                LB_console.Items.Add(ex.ToString());
            }
        } //thread recherche

        #endregion démarrage et recherche des client

        #region gestion des paquet

        private void ListenComClient(object io)
        {
            int i = (int)io;
            string input = string.Empty;
            TcpClient Joueur = _ClientTCP[i]._Client;
            TcpClient Adversaire;
            try
            {
                BinaryReader br = new BinaryReader(Joueur.GetStream());
                BinaryWriter bw = new BinaryWriter(Joueur.GetStream());
                while (Joueur.Connected)
                {
                    RTB_chat.Text += "\n Attente d'un msg client "+ _ClientTCP[i]._Name.ToString() +"...";
                    input = br.ReadString(); // blocks here until something is received from client
                    RTB_chat.Text += "\n" + input;
                    switch (input)
                    {
                        case "@j1play@":
                            {
                                RTB_chat.Text += "\n J1: joue une carte :";
                                Carte cTmp = new Carte();
                                cTmp = DeserializeCard(Joueur.GetStream());
                                RTB_chat.Text +=  cTmp.DisplayValue;
                                int SI = br.ReadInt32();
                                Adversaire = _ClientTCP[1]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@advjoue@");
                                Adv_bw.Flush();
                                Serialize(Adversaire.GetStream(), cTmp);
                                Adv_bw.Write(SI);
                                Adv_bw.Flush();
                                Adversaire.GetStream().Flush();
                                break;
                            }
                        case "@j2play@":
                            {
                                RTB_chat.Text += "\n J2: joue une carte :";
                                Carte cTmp = new Carte();
                                cTmp = DeserializeCard(Joueur.GetStream());
                                RTB_chat.Text += cTmp.DisplayValue;
                                int SI = br.ReadInt32();
                                Adversaire = _ClientTCP[0]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@advjoue@");
                                Adv_bw.Flush();
                                Serialize(Adversaire.GetStream(), cTmp);
                                Adv_bw.Write(SI);
                                Adv_bw.Flush();
                                Adversaire.GetStream().Flush();
                                break;
                            }
                        case "@j1piocheJ@":
                            {
                                RTB_chat.Text += "\n J1: pioche une carte et peut rejouer !";
                                Adversaire = _ClientTCP[1]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@advpiocheJ@");
                                Adv_bw.Flush();
                                break;
                            }
                        case "@j1piocheNJ@":
                            {
                                RTB_chat.Text += "\n J1: pioche une carte et ne peut pas rejouer !";
                                Adversaire = _ClientTCP[1]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@advpiocheNJ@");
                                Adv_bw.Flush();
                                break;
                            }
                        case "@j2piocheJ@":
                            {
                                RTB_chat.Text += "\n J2: pioche une carte et peut rejouer !";
                                Adversaire = _ClientTCP[0]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@advpiocheJ@");
                                Adv_bw.Flush();
                                break;
                            }
                        case "@j2piocheNJ@":
                            {
                                RTB_chat.Text += "\n J2: pioche une carte et ne peut pas rejouer !";
                                Adversaire = _ClientTCP[0]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@advpiocheNJ@");
                                Adv_bw.Flush();
                                break;
                            }
                        case "@j1win@":
                            {
                                RTB_chat.Text += "\n J1: gagne la partie !";
                                Adversaire = _ClientTCP[1]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@perdu@");
                                Adv_bw.Flush();
                                foreach(TCP_Client_CG c in _ClientTCP)
                                {
                                    c._Client.Close();
                                }
                                nombreConnect = 0;
                                _ClientTCP.Clear();
                                LB_user.Items.Clear();
                                Thread.CurrentThread.Abort();
                                break;
                            }
                        case "@j2win@":
                            {
                                RTB_chat.Text += "\n J2: gagne la partie  !";
                                Adversaire = _ClientTCP[0]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@perdu@");
                                Adv_bw.Flush();
                                foreach (TCP_Client_CG c in _ClientTCP)
                                {
                                    c._Client.Close();
                                }
                                nombreConnect = 0;
                                _ClientTCP.Clear();
                                LB_user.Items.Clear();
                                Thread.CurrentThread.Abort();
                                break;
                            }
                        case "@j1Ab@":
                            {
                                RTB_chat.Text += "\n J1: abandonne !";
                                Adversaire = _ClientTCP[1]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@win@");
                                Adv_bw.Flush();
                                B_stop_Click(null, null);
                                break;
                            }
                        case "@j2Ab@":
                            {
                                RTB_chat.Text += "\n J2: abandonne !";
                                Adversaire = _ClientTCP[0]._Client;
                                BinaryWriter Adv_bw = new BinaryWriter(Adversaire.GetStream());
                                Adv_bw.Write("@win@");
                                Adv_bw.Flush();
                                B_stop_Click(null, null);
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
                LB_console.Items.Add("Probleme de réception client avec j" + (i+1));
                LB_console.Items.Add(ex.ToString());
                Joueur.Close();
                LB_console.Items.Add("Fin de connexion avec le client " + (i + 1));
                if (LB_user.Items.Count > 1)
                LB_user.Items.RemoveAt(i);
                nombreConnect = _ClientTCP.Count();
                TB_num.Text = nombreConnect.ToString();
            }
        } //thread listen client

        private void SendMsgToUser(string sTextToSend)
        {
            if(LB_user.SelectedIndex == -1)
            {
                MessageBox.Show("Pas d'utilisateur choisi");
            }
            else
            {
                int i = LB_user.SelectedIndex;
                TcpClient MsgToClient = _ClientTCP[i]._Client;
                BinaryWriter bw = new BinaryWriter(MsgToClient.GetStream());
                bw.Write("@msg@");
                bw.Flush();
                bw.Write(sTextToSend);
                bw.Flush();
                MsgToClient.GetStream().Flush();
            }

        } //quand le serveur envoie un msg

        #endregion gestion des paquet

        #region bouton de contrôle du serveur

        private void B_start_Click(object sender, EventArgs e)
        {
            bouc = 1;
            SetupServer();
        }

        private void B_test_ip(object sender, EventArgs e)
        {
            if (TB_add.Text.Length > 0)
            {
                IPAddress IPMachine = AdresseValide(TB_add.Text);
                if (IPMachine == null)
                    MessageBox.Show("pas de ping");
                else
                    MessageBox.Show("ping réussi");
            }
            else
                MessageBox.Show("renseigner le nom de la machine");
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

        private void B_rep_admin_Click(object sender, EventArgs e)
        {
            SendMsgToUser(TB_admin.Text);
        } //send message serveur -> client à la main

        private void B_stop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TCP_Client_CG c in _ClientTCP)
                {
                    c._Client.Close();
                }
            }
            catch (Exception)
            {
                //stop quand même
            }
            serverTCPl.Stop();
            _ClientTCP.Clear();
            LB_user.Items.Clear();
            B_stop.Enabled = false;
            B_start.Enabled = true;
        } //arrêt du serveur

        #endregion bouton de contrôle du serveur


        private void b_NG_Click(object sender, EventArgs e)
        {
            foreach(TCP_Client_CG c in _ClientTCP)
            {
                BinaryWriter bw = new BinaryWriter(c._Client.GetStream());
                bw.Write("@distrib@");
                Serialize(c._Client.GetStream(), NewGame.Pioche.paquet);
                c._Client.GetStream().Flush();
            }
            b_NG.Enabled = false;
        }

        private static void Serialize(NetworkStream stream, object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, obj);
        }

        private Carte DeserializeCard(NetworkStream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (Carte)bf.Deserialize(stream);
        }

        public class TCP_Client_CG
        {
            public TcpClient _Client { get; set; }
            public string _Name { get; set; }

            public TCP_Client_CG(TcpClient TC)
            {
                this._Client = TC;
            }
        }
    }
}