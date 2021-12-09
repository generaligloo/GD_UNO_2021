
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
            this.LB_MainAdverse = new System.Windows.Forms.ListBox();
            this.LB_MainJoueur = new System.Windows.Forms.ListBox();
            this.LB_defausse = new System.Windows.Forms.ListBox();
            this.Panel_UNO_LAN = new System.Windows.Forms.Panel();
            this.PB_defausse = new System.Windows.Forms.PictureBox();
            this.PB_pioche = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TB_pseudo = new System.Windows.Forms.TextBox();
            this.L_nom = new System.Windows.Forms.Label();
            this.B_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.RTB_chat = new System.Windows.Forms.RichTextBox();
            this.B_disconnect = new System.Windows.Forms.Button();
            this.lb_tour = new System.Windows.Forms.Label();
            this.TB_tour = new System.Windows.Forms.TextBox();
            this.Panel_UNO_LAN.SuspendLayout();
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
            this.LB_Deck.Visible = false;
            // 
            // LB_MainAdverse
            // 
            this.LB_MainAdverse.FormattingEnabled = true;
            this.LB_MainAdverse.Location = new System.Drawing.Point(176, 413);
            this.LB_MainAdverse.Name = "LB_MainAdverse";
            this.LB_MainAdverse.Size = new System.Drawing.Size(156, 212);
            this.LB_MainAdverse.TabIndex = 1;
            this.LB_MainAdverse.Visible = false;
            // 
            // LB_MainJoueur
            // 
            this.LB_MainJoueur.FormattingEnabled = true;
            this.LB_MainJoueur.Location = new System.Drawing.Point(12, 413);
            this.LB_MainJoueur.Name = "LB_MainJoueur";
            this.LB_MainJoueur.Size = new System.Drawing.Size(158, 212);
            this.LB_MainJoueur.TabIndex = 2;
            // 
            // LB_defausse
            // 
            this.LB_defausse.FormattingEnabled = true;
            this.LB_defausse.Location = new System.Drawing.Point(176, 12);
            this.LB_defausse.Name = "LB_defausse";
            this.LB_defausse.Size = new System.Drawing.Size(158, 134);
            this.LB_defausse.TabIndex = 3;
            this.LB_defausse.Visible = false;
            // 
            // Panel_UNO_LAN
            // 
            this.Panel_UNO_LAN.BackColor = System.Drawing.Color.Green;
            this.Panel_UNO_LAN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_UNO_LAN.Controls.Add(this.PB_defausse);
            this.Panel_UNO_LAN.Controls.Add(this.PB_pioche);
            this.Panel_UNO_LAN.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_UNO_LAN.Location = new System.Drawing.Point(354, 0);
            this.Panel_UNO_LAN.Name = "Panel_UNO_LAN";
            this.Panel_UNO_LAN.Size = new System.Drawing.Size(876, 637);
            this.Panel_UNO_LAN.TabIndex = 9;
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
            this.RTB_chat.ReadOnly = true;
            this.RTB_chat.Size = new System.Drawing.Size(320, 143);
            this.RTB_chat.TabIndex = 17;
            this.RTB_chat.Text = "";
            // 
            // B_disconnect
            // 
            this.B_disconnect.Enabled = false;
            this.B_disconnect.Location = new System.Drawing.Point(259, 178);
            this.B_disconnect.Name = "B_disconnect";
            this.B_disconnect.Size = new System.Drawing.Size(75, 23);
            this.B_disconnect.TabIndex = 18;
            this.B_disconnect.Text = "Deconnexion";
            this.B_disconnect.UseVisualStyleBackColor = true;
            this.B_disconnect.Click += new System.EventHandler(this.B_disconnect_Click);
            // 
            // lb_tour
            // 
            this.lb_tour.AutoSize = true;
            this.lb_tour.Location = new System.Drawing.Point(9, 376);
            this.lb_tour.Name = "lb_tour";
            this.lb_tour.Size = new System.Drawing.Size(71, 13);
            this.lb_tour.TabIndex = 19;
            this.lb_tour.Text = "Votre tour ? : ";
            // 
            // TB_tour
            // 
            this.TB_tour.Location = new System.Drawing.Point(78, 373);
            this.TB_tour.Name = "TB_tour";
            this.TB_tour.ReadOnly = true;
            this.TB_tour.Size = new System.Drawing.Size(254, 20);
            this.TB_tour.TabIndex = 20;
            // 
            // EcranTerrain_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1230, 637);
            this.Controls.Add(this.TB_tour);
            this.Controls.Add(this.lb_tour);
            this.Controls.Add(this.B_disconnect);
            this.Controls.Add(this.RTB_chat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_IP);
            this.Controls.Add(this.B_connect);
            this.Controls.Add(this.L_nom);
            this.Controls.Add(this.TB_pseudo);
            this.Controls.Add(this.Panel_UNO_LAN);
            this.Controls.Add(this.LB_defausse);
            this.Controls.Add(this.LB_MainJoueur);
            this.Controls.Add(this.LB_MainAdverse);
            this.Controls.Add(this.LB_Deck);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranTerrain_LAN";
            this.Text = "Terrain de jeu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EcranTerrain_LAN_FormClosing);
            this.Panel_UNO_LAN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_defausse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_pioche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Deck;
        private System.Windows.Forms.ListBox LB_MainAdverse;
        private System.Windows.Forms.ListBox LB_MainJoueur;
        private System.Windows.Forms.ListBox LB_defausse;
        private System.Windows.Forms.Panel Panel_UNO_LAN;
        private System.Windows.Forms.PictureBox PB_pioche;
        private System.Windows.Forms.PictureBox PB_defausse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox TB_pseudo;
        private System.Windows.Forms.Label L_nom;
        private System.Windows.Forms.Button B_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.RichTextBox RTB_chat;
        private System.Windows.Forms.Button B_disconnect;
        private System.Windows.Forms.Label lb_tour;
        private System.Windows.Forms.TextBox TB_tour;
    }
}

