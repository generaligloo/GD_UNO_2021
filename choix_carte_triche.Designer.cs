
namespace GD_UNO_2021
{
    partial class choix_carte_triche
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(choix_carte_triche));
            this.b_pioche_triche = new System.Windows.Forms.Button();
            this.LB_Deck = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // b_pioche_triche
            // 
            this.b_pioche_triche.Location = new System.Drawing.Point(12, 256);
            this.b_pioche_triche.Name = "b_pioche_triche";
            this.b_pioche_triche.Size = new System.Drawing.Size(156, 23);
            this.b_pioche_triche.TabIndex = 0;
            this.b_pioche_triche.Text = "Piocher";
            this.b_pioche_triche.UseVisualStyleBackColor = true;
            this.b_pioche_triche.Click += new System.EventHandler(this.b_pioche_triche_Click);
            // 
            // LB_Deck
            // 
            this.LB_Deck.FormattingEnabled = true;
            this.LB_Deck.Location = new System.Drawing.Point(12, 12);
            this.LB_Deck.Name = "LB_Deck";
            this.LB_Deck.Size = new System.Drawing.Size(156, 238);
            this.LB_Deck.TabIndex = 1;
            // 
            // choix_carte_triche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 291);
            this.Controls.Add(this.LB_Deck);
            this.Controls.Add(this.b_pioche_triche);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "choix_carte_triche";
            this.Text = "choix_carte_triche";
            this.Load += new System.EventHandler(this.choix_carte_triche_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_pioche_triche;
        private System.Windows.Forms.ListBox LB_Deck;
    }
}