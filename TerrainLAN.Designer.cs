
namespace GD_UNO_2021
{
    partial class EcranTerrain_LAN
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LB_Deck = new System.Windows.Forms.ListBox();
            this.LB_Player2 = new System.Windows.Forms.ListBox();
            this.LB_Player1 = new System.Windows.Forms.ListBox();
            this.LB_defausse = new System.Windows.Forms.ListBox();
            this.B_jouer1 = new System.Windows.Forms.Button();
            this.B_jouer2 = new System.Windows.Forms.Button();
            this.B_piocher1 = new System.Windows.Forms.Button();
            this.B_piocher2 = new System.Windows.Forms.Button();
            this.Panel_UNO = new System.Windows.Forms.Panel();
            this.PB_defausse = new System.Windows.Forms.PictureBox();
            this.PB_pioche = new System.Windows.Forms.PictureBox();
            this.B_sauv = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TB_pseudo = new System.Windows.Forms.TextBox();
            this.L_nom = new System.Windows.Forms.Label();
            this.B_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.RTB_chat = new System.Windows.Forms.RichTextBox();
            this.B_disconnect = new System.Windows.Forms.Button();
            this.Panel_UNO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_defausse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_pioche)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_Deck
            // 
            this.LB_Deck.FormattingEnabled = true;
            this.LB_Deck.Location = new System.Drawing.Point(14, 12);
            this.LB_Deck.Name = "LB_Deck";
            this.LB_Deck.Size = new System.Drawing.Size(156, 134);
            this.LB_Deck.TabIndex = 0;
            // 
            // LB_Player2
            // 
            this.LB_Player2.FormattingEnabled = true;
            this.LB_Player2.Location = new System.Drawing.Point(176, 413);
            this.LB_Player2.Name = "LB_Player2";
            this.LB_Player2.Size = new System.Drawing.Size(156, 212);
            this.LB_Player2.TabIndex = 1;
            // 
            // LB_Player1
            // 
            this.LB_Player1.FormattingEnabled = true;
            this.LB_Player1.Location = new System.Drawing.Point(12, 413);
            this.LB_Player1.Name = "LB_Player1";
            this.LB_Player1.Size = new System.Drawing.Size(158, 212);
            this.LB_Player1.TabIndex = 2;
            // 
            // LB_defausse
            // 
            this.LB_defausse.FormattingEnabled = true;
            this.LB_defausse.Location = new System.Drawing.Point(176, 12);
            this.LB_defausse.Name = "LB_defausse";
            this.LB_defausse.Size = new System.Drawing.Size(158, 134);
            this.LB_defausse.TabIndex = 3;
            // 
            // B_jouer1
            // 
            this.B_jouer1.Location = new System.Drawing.Point(14, 384);
            this.B_jouer1.Name = "B_jouer1";
            this.B_jouer1.Size = new System.Drawing.Size(75, 23);
            this.B_jouer1.TabIndex = 4;
            this.B_jouer1.Text = "Jouer";
            this.B_jouer1.UseVisualStyleBackColor = true;
            this.B_jouer1.Click += new System.EventHandler(this.B_jouer1_Click);
            // 
            // B_jouer2
            // 
            this.B_jouer2.Location = new System.Drawing.Point(176, 384);
            this.B_jouer2.Name = "B_jouer2";
            this.B_jouer2.Size = new System.Drawing.Size(75, 23);
            this.B_jouer2.TabIndex = 5;
            this.B_jouer2.Text = "Jouer";
            this.B_jouer2.UseVisualStyleBackColor = true;
            this.B_jouer2.Click += new System.EventHandler(this.B_jouer2_Click);
            // 
            // B_piocher1
            // 
            this.B_piocher1.Location = new System.Drawing.Point(95, 384);
            this.B_piocher1.Name = "B_piocher1";
            this.B_piocher1.Size = new System.Drawing.Size(75, 23);
            this.B_piocher1.TabIndex = 6;
            this.B_piocher1.Text = "Piocher";
            this.B_piocher1.UseVisualStyleBackColor = true;
            this.B_piocher1.Click += new System.EventHandler(this.B_piocher1_Click);
            // 
            // B_piocher2
            // 
            this.B_piocher2.Location = new System.Drawing.Point(257, 384);
            this.B_piocher2.Name = "B_piocher2";
            this.B_piocher2.Size = new System.Drawing.Size(75, 23);
            this.B_piocher2.TabIndex = 7;
            this.B_piocher2.Text = "Piocher";
            this.B_piocher2.UseVisualStyleBackColor = true;
            this.B_piocher2.Click += new System.EventHandler(this.B_piocher2_Click);
            // 
            // Panel_UNO
            // 
            this.Panel_UNO.BackColor = System.Drawing.Color.Green;
            this.Panel_UNO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_UNO.Controls.Add(this.PB_defausse);
            this.Panel_UNO.Controls.Add(this.PB_pioche);
            this.Panel_UNO.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_UNO.Location = new System.Drawing.Point(354, 0);
            this.Panel_UNO.Name = "Panel_UNO";
            this.Panel_UNO.Size = new System.Drawing.Size(876, 637);
            this.Panel_UNO.TabIndex = 9;
            // 
            // PB_defausse
            // 
            this.PB_defausse.Image = global::GD_UNO_2021.Properties.Resources.DOS_DIFF;
            this.PB_defausse.Location = new System.Drawing.Point(340, 235);
            this.PB_defausse.Name = "PB_defausse";
            this.PB_defausse.Size = new System.Drawing.Size(100, 140);
            this.PB_defausse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_defausse.TabIndex = 1;
            this.PB_defausse.TabStop = false;
            // 
            // PB_pioche
            // 
            this.PB_pioche.Image = global::GD_UNO_2021.Properties.Resources.card_back_large;
            this.PB_pioche.Location = new System.Drawing.Point(458, 235);
            this.PB_pioche.Name = "PB_pioche";
            this.PB_pioche.Size = new System.Drawing.Size(100, 140);
            this.PB_pioche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_pioche.TabIndex = 0;
            this.PB_pioche.TabStop = false;
            this.PB_pioche.Click += new System.EventHandler(this.PB_pioche_Click);
            // 
            // B_sauv
            // 
            this.B_sauv.Location = new System.Drawing.Point(14, 355);
            this.B_sauv.Name = "B_sauv";
            this.B_sauv.Size = new System.Drawing.Size(318, 23);
            this.B_sauv.TabIndex = 11;
            this.B_sauv.Text = "Sauvegarder";
            this.B_sauv.UseVisualStyleBackColor = true;
            this.B_sauv.Click += new System.EventHandler(this.B_sauv_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Fichier uno|*.uno";
            // 
            // TB_pseudo
            // 
            this.TB_pseudo.Location = new System.Drawing.Point(97, 154);
            this.TB_pseudo.Name = "TB_pseudo";
            this.TB_pseudo.Size = new System.Drawing.Size(156, 20);
            this.TB_pseudo.TabIndex = 12;
            // 
            // L_nom
            // 
            this.L_nom.AutoSize = true;
            this.L_nom.Location = new System.Drawing.Point(45, 157);
            this.L_nom.Name = "L_nom";
            this.L_nom.Size = new System.Drawing.Size(46, 13);
            this.L_nom.TabIndex = 13;
            this.L_nom.Text = "Pseudo:";
            // 
            // B_connect
            // 
            this.B_connect.Location = new System.Drawing.Point(259, 152);
            this.B_connect.Name = "B_connect";
            this.B_connect.Size = new System.Drawing.Size(75, 23);
            this.B_connect.TabIndex = 14;
            this.B_connect.Text = "Connexion";
            this.B_connect.UseVisualStyleBackColor = true;
            this.B_connect.Click += new System.EventHandler(this.B_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "IP du serveur:";
            // 
            // TB_IP
            // 
            this.TB_IP.Location = new System.Drawing.Point(97, 180);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(156, 20);
            this.TB_IP.TabIndex = 15;
            // 
            // RTB_chat
            // 
            this.RTB_chat.Location = new System.Drawing.Point(12, 206);
            this.RTB_chat.Name = "RTB_chat";
            this.RTB_chat.Size = new System.Drawing.Size(320, 143);
            this.RTB_chat.TabIndex = 17;
            this.RTB_chat.Text = "";
            // 
            // B_disconnect
            // 
            this.B_disconnect.Location = new System.Drawing.Point(259, 178);
            this.B_disconnect.Name = "B_disconnect";
            this.B_disconnect.Size = new System.Drawing.Size(75, 23);
            this.B_disconnect.TabIndex = 18;
            this.B_disconnect.Text = "Deconnexion";
            this.B_disconnect.UseVisualStyleBackColor = true;
            this.B_disconnect.Click += new System.EventHandler(this.B_disconnect_Click);
            // 
            // EcranTerrain_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1230, 637);
            this.Controls.Add(this.B_disconnect);
            this.Controls.Add(this.RTB_chat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_IP);
            this.Controls.Add(this.B_connect);
            this.Controls.Add(this.L_nom);
            this.Controls.Add(this.TB_pseudo);
            this.Controls.Add(this.B_sauv);
            this.Controls.Add(this.Panel_UNO);
            this.Controls.Add(this.B_piocher2);
            this.Controls.Add(this.B_piocher1);
            this.Controls.Add(this.B_jouer2);
            this.Controls.Add(this.B_jouer1);
            this.Controls.Add(this.LB_defausse);
            this.Controls.Add(this.LB_Player1);
            this.Controls.Add(this.LB_Player2);
            this.Controls.Add(this.LB_Deck);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranTerrain_LAN";
            this.Text = "Terrain de jeu";
            this.Load += new System.EventHandler(this.Terrain_Load);
            this.Panel_UNO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_defausse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_pioche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Deck;
        private System.Windows.Forms.ListBox LB_Player2;
        private System.Windows.Forms.ListBox LB_Player1;
        private System.Windows.Forms.ListBox LB_defausse;
        private System.Windows.Forms.Button B_jouer1;
        private System.Windows.Forms.Button B_jouer2;
        private System.Windows.Forms.Button B_piocher1;
        private System.Windows.Forms.Button B_piocher2;
        private System.Windows.Forms.Panel Panel_UNO;
        private System.Windows.Forms.PictureBox PB_pioche;
        private System.Windows.Forms.PictureBox PB_defausse;
        private System.Windows.Forms.Button B_sauv;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox TB_pseudo;
        private System.Windows.Forms.Label L_nom;
        private System.Windows.Forms.Button B_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.RichTextBox RTB_chat;
        private System.Windows.Forms.Button B_disconnect;
    }
}

