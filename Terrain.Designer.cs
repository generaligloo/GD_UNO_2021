
namespace GD_UNO_2021
{
    partial class EcranTerrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EcranTerrain));
            this.LB_Deck = new System.Windows.Forms.ListBox();
            this.LB_Player2 = new System.Windows.Forms.ListBox();
            this.LB_Player1 = new System.Windows.Forms.ListBox();
            this.LB_defausse = new System.Windows.Forms.ListBox();
            this.B_jouer1 = new System.Windows.Forms.Button();
            this.B_jouer2 = new System.Windows.Forms.Button();
            this.B_piocher1 = new System.Windows.Forms.Button();
            this.B_piocher2 = new System.Windows.Forms.Button();
            this.B_NP = new System.Windows.Forms.Button();
            this.Panel_UNO = new System.Windows.Forms.Panel();
            this.PB_defausse = new System.Windows.Forms.PictureBox();
            this.PB_pioche = new System.Windows.Forms.PictureBox();
            this.B_admin = new System.Windows.Forms.Button();
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
            this.LB_Deck.Size = new System.Drawing.Size(156, 238);
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
            this.LB_defausse.Size = new System.Drawing.Size(158, 238);
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
            // B_NP
            // 
            this.B_NP.Location = new System.Drawing.Point(12, 256);
            this.B_NP.Name = "B_NP";
            this.B_NP.Size = new System.Drawing.Size(107, 23);
            this.B_NP.TabIndex = 8;
            this.B_NP.Text = "Nouvelle partie";
            this.B_NP.UseVisualStyleBackColor = true;
            this.B_NP.Click += new System.EventHandler(this.B_NP_Click);
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
            // B_admin
            // 
            this.B_admin.Location = new System.Drawing.Point(12, 285);
            this.B_admin.Name = "B_admin";
            this.B_admin.Size = new System.Drawing.Size(107, 23);
            this.B_admin.TabIndex = 10;
            this.B_admin.Text = "Mode admin:";
            this.B_admin.UseVisualStyleBackColor = true;
            this.B_admin.Click += new System.EventHandler(this.B_admin_Click);
            // 
            // EcranTerrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1230, 637);
            this.Controls.Add(this.B_admin);
            this.Controls.Add(this.Panel_UNO);
            this.Controls.Add(this.B_NP);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranTerrain";
            this.Text = "Terrain de jeu";
            this.Load += new System.EventHandler(this.Terrain_Load);
            this.Panel_UNO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_defausse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_pioche)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button B_NP;
        private System.Windows.Forms.Panel Panel_UNO;
        private System.Windows.Forms.PictureBox PB_pioche;
        private System.Windows.Forms.PictureBox PB_defausse;
        private System.Windows.Forms.Button B_admin;
    }
}

