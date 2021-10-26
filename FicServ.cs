using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GD_UNO_2021
{
    public partial class EcranServ : Form
    {
        public int count = 0;
        private byte[] _buffer = new byte[1024];
        public List<SocketClient> __ClientSockets { get; set; }
        private List<string> _names = new List<string>();
        private Socket _serverSocket;
        public int bouc = 1;
        private int maxJoueur = 2;

        public EcranServ()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void EcranServ_Load(object sender, EventArgs e)
        {
            __ClientSockets = new List<SocketClient>();
        }

        #region démarrage et recherche des client

        private void SetupServer()
        {
            string IPadd = TB_add.Text;
            int port = int.Parse(TB_port.Text);
            LB_console.Items.Add("Démarrage server . . .");
            B_stop.Enabled = true;
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse(IPadd), port));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptConnection), _serverSocket);
            B_start.Enabled = false;
        } //démarrage

        private void AcceptConnection(IAsyncResult ar)
        {
            Thread.Sleep(500);
            if (_serverSocket != null && bouc == 1)
            {
                Socket socket_connect = (Socket)ar.AsyncState;
                Socket tmp = socket_connect.EndAccept(ar);
                __ClientSockets.Add(new SocketClient(tmp));
                _names.Add(tmp.RemoteEndPoint.ToString());
                LB_user.Items.Add(tmp.RemoteEndPoint.ToString());
                count++;
                TB_num.Text = count.ToString();
                LB_console.Items.Add("Nombre de clients connectés: " + __ClientSockets.Count.ToString());
                LB_console.Items.Add("Client connecté. . .");
                tmp.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), tmp);
                if (count < maxJoueur)
                {
                    _serverSocket.BeginAccept(new AsyncCallback(AcceptConnection), _serverSocket);
                }
                else
                {
                    MessageBox.Show("Nombre de joueur atteint, la partie va pouvoir commencé");
                }
            }
        } //scan de recherche de client

        #endregion démarrage et recherche des client

        #region gestion des paquet

        private void ReceiveData(IAsyncResult ar)
        {
            if (__ClientSockets.Count != 0)
            {
                Socket socket_receive = (Socket)ar.AsyncState;
                if (socket_receive.Connected)
                {
                    int received;
                    try
                    {
                        received = socket_receive.EndReceive(ar);
                    }
                    catch (Exception)
                    {
                        // le client a fermé la connexion
                        for (int i = 0; i < __ClientSockets.Count; i++)
                        {
                            if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket_receive.RemoteEndPoint.ToString()))
                            {
                                __ClientSockets.RemoveAt(i);
                                _names.RemoveAt(i);
                                LB_user.Items.Clear();
                                foreach (SocketClient c in __ClientSockets)
                                {
                                    LB_user.Items.Add(__ClientSockets[i]._Name);
                                }
                                count--;
                                TB_num.Text = count.ToString();
                                LB_console.Items.Add("Nombre de clients connectés: " + __ClientSockets.Count.ToString());
                            }
                        }
                        // supprimer de la liste
                        return;
                    }
                    if (received != 0)
                    {
                        byte[] dataBuf = new byte[received];
                        Array.Copy(_buffer, dataBuf, received);
                        string text = Encoding.Unicode.GetString(dataBuf);
                        LB_console.Items.Add("Texte recu: " + text);
                        string reponse = string.Empty;
                        if (text.Contains("@@"))
                        {
                            for (int i = 0; i < LB_user.Items.Count; i++)
                            {
                                if (socket_receive.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                                {
                                    LB_user.Items.RemoveAt(i);
                                    LB_user.Items.Insert(i, text.Substring(1, text.Length - 1));
                                    __ClientSockets[i]._Name = text;
                                    socket_receive.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), socket_receive);
                                    return;
                                }
                            }
                        }

                        for (int i = 0; i < __ClientSockets.Count; i++)
                        {
                            if (socket_receive.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                            {
                                RTB_chat.AppendText("\n" + __ClientSockets[i]._Name + ": " + text);
                            }
                        }

                        if (text == "bye")
                        {
                            return;
                        }
                        reponse = text;
                        //Sendata(socket_receive, reponse);
                    }
                    else
                    {
                        for (int i = 0; i < __ClientSockets.Count; i++)
                        {
                            if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket_receive.RemoteEndPoint.ToString()))
                            {
                                __ClientSockets.RemoveAt(i);
                                _names.RemoveAt(i);
                                LB_user.Items.Clear();
                                foreach (SocketClient c in __ClientSockets)
                                {
                                    LB_user.Items.Add(__ClientSockets[i]._Name);
                                }
                                count--;
                                TB_num.Text = count.ToString();
                                LB_console.Items.Add("Nombre de clients connectés: " + __ClientSockets.Count.ToString());
                            }
                        }
                    }
                }
                try
                {
                    socket_receive.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), socket_receive);
                }
                catch
                {
                }
            }
        } //quand le serveur recoit un paquet

        private void Sendata(Socket socket, string sTextToSend)
        {
            byte[] data = Encoding.Unicode.GetBytes(sTextToSend);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendDataEnd), socket);
            if (bouc == 1)
            {
                _serverSocket.BeginAccept(new AsyncCallback(AcceptConnection), _serverSocket);
            }
        } //quand le serveur envoie un paquet

        #endregion gestion des paquet

        #region bouton de contrôle du serveur

        private void B_start_Click(object sender, EventArgs e)
        {
            bouc = 1;
            SetupServer();
        }

        private void B_rep_admin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_user.SelectedItems.Count; i++)
            {
                string t = LB_user.SelectedItems[i].ToString();
                for (int j = 0; j < __ClientSockets.Count; j++)
                {
                    if (__ClientSockets[j]._Socket.Connected && __ClientSockets[j]._Name.Equals("@" + t))
                    {
                        Sendata(__ClientSockets[j]._Socket, TB_admin.Text);
                    }
                }
            }
            RTB_chat.AppendText("\nServer Admin: " + TB_admin.Text);
        } //send message serveur -> client à la main

        private void B_stop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SocketClient Sc in __ClientSockets)
                {
                    byte[] data = Encoding.Unicode.GetBytes("@end");
                    Sc._Socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendDataEnd), Sc._Socket);
                    Sc._Socket.Shutdown(SocketShutdown.Both);
                    Sc._Socket.BeginDisconnect(false, new AsyncCallback(DecoClient), Sc._Socket);
                }
                _serverSocket.Dispose();
                _serverSocket.Close();
                __ClientSockets.Clear();
                LB_user.Items.Clear();
                count = 0;
                TB_num.Text = count.ToString();
                bouc = 0;
                _serverSocket = null;
            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                MessageBox.Show("SocketException : {0}", se.ToString());
            }
            catch (Exception aa)
            {
                MessageBox.Show("Unexpected exception : {0}", aa.ToString());
            }
            LB_console.Items.Add("Fermeture server");
            B_stop.Enabled = false;
            B_start.Enabled = true;
        } //arrêt du serveur

        #endregion bouton de contrôle du serveur

        #region zone de validation Async

        private void SendDataEnd(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }  //fin d'envoi

        private void DecoClient(IAsyncResult ar)
        {
            Socket Tmp = (Socket)ar.AsyncState;
            Tmp.EndDisconnect(ar);
        }   //fin d'une connexion avec le client

        #endregion zone de validation Async
    }

    public class SocketClient
    {
        public Socket _Socket { get; set; }
        public string _Name { get; set; }

        public SocketClient(Socket socket)
        {
            this._Socket = socket;
        }
    }
}