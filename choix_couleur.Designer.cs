
namespace GD_UNO_2021
{
    partial class choix_couleur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(choix_couleur));
            this.B_rouge = new System.Windows.Forms.Button();
            this.B_jaune = new System.Windows.Forms.Button();
            this.B_bleu = new System.Windows.Forms.Button();
            this.B_vert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_rouge
            // 
            this.B_rouge.BackColor = System.Drawing.Color.Red;
            this.B_rouge.Location = new System.Drawing.Point(12, 12);
            this.B_rouge.Name = "B_rouge";
            this.B_rouge.Size = new System.Drawing.Size(65, 65);
            this.B_rouge.TabIndex = 0;
            this.B_rouge.Text = "Rouge";
            this.B_rouge.UseVisualStyleBackColor = false;
            this.B_rouge.Click += new System.EventHandler(this.B_rouge_Click);
            // 
            // B_jaune
            // 
            this.B_jaune.BackColor = System.Drawing.Color.Yellow;
            this.B_jaune.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_jaune.Location = new System.Drawing.Point(83, 12);
            this.B_jaune.Name = "B_jaune";
            this.B_jaune.Size = new System.Drawing.Size(65, 65);
            this.B_jaune.TabIndex = 1;
            this.B_jaune.Text = "Jaune";
            this.B_jaune.UseVisualStyleBackColor = false;
            this.B_jaune.Click += new System.EventHandler(this.B_jaune_Click);
            // 
            // B_bleu
            // 
            this.B_bleu.BackColor = System.Drawing.Color.Aqua;
            this.B_bleu.Location = new System.Drawing.Point(12, 83);
            this.B_bleu.Name = "B_bleu";
            this.B_bleu.Size = new System.Drawing.Size(65, 65);
            this.B_bleu.TabIndex = 2;
            this.B_bleu.Text = "Bleu";
            this.B_bleu.UseVisualStyleBackColor = false;
            this.B_bleu.Click += new System.EventHandler(this.B_bleu_Click);
            // 
            // B_vert
            // 
            this.B_vert.BackColor = System.Drawing.Color.Lime;
            this.B_vert.Location = new System.Drawing.Point(83, 83);
            this.B_vert.Name = "B_vert";
            this.B_vert.Size = new System.Drawing.Size(65, 65);
            this.B_vert.TabIndex = 3;
            this.B_vert.Text = "Vert";
            this.B_vert.UseVisualStyleBackColor = false;
            this.B_vert.Click += new System.EventHandler(this.B_vert_Click);
            // 
            // choix_couleur
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(163, 161);
            this.Controls.Add(this.B_vert);
            this.Controls.Add(this.B_bleu);
            this.Controls.Add(this.B_jaune);
            this.Controls.Add(this.B_rouge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "choix_couleur";
            this.Text = "Couleur ?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_rouge;
        private System.Windows.Forms.Button B_jaune;
        private System.Windows.Forms.Button B_bleu;
        private System.Windows.Forms.Button B_vert;
    }
}