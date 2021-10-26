
namespace GD_UNO_2021
{
    partial class FicPrinc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicPrinc));
            this.B_NP = new System.Windows.Forms.Button();
            this.B_charger = new System.Windows.Forms.Button();
            this.B_quitter = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // B_NP
            // 
            this.B_NP.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_NP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.B_NP.Location = new System.Drawing.Point(12, 12);
            this.B_NP.Name = "B_NP";
            this.B_NP.Size = new System.Drawing.Size(585, 115);
            this.B_NP.TabIndex = 0;
            this.B_NP.Text = "Nouvelle partie";
            this.B_NP.UseVisualStyleBackColor = true;
            this.B_NP.Click += new System.EventHandler(this.B_NP_Click);
            // 
            // B_charger
            // 
            this.B_charger.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_charger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.B_charger.Location = new System.Drawing.Point(12, 168);
            this.B_charger.Name = "B_charger";
            this.B_charger.Size = new System.Drawing.Size(585, 115);
            this.B_charger.TabIndex = 1;
            this.B_charger.Text = "Charger partie";
            this.B_charger.UseVisualStyleBackColor = true;
            this.B_charger.Click += new System.EventHandler(this.B_charger_Click);
            // 
            // B_quitter
            // 
            this.B_quitter.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_quitter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.B_quitter.Location = new System.Drawing.Point(12, 323);
            this.B_quitter.Name = "B_quitter";
            this.B_quitter.Size = new System.Drawing.Size(585, 115);
            this.B_quitter.TabIndex = 2;
            this.B_quitter.Text = "Quitter";
            this.B_quitter.UseVisualStyleBackColor = true;
            this.B_quitter.Click += new System.EventHandler(this.B_quitter_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Fichier uno|*.uno";
            // 
            // FicPrinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.B_quitter);
            this.Controls.Add(this.B_charger);
            this.Controls.Add(this.B_NP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FicPrinc";
            this.Text = "UNO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_NP;
        private System.Windows.Forms.Button B_charger;
        private System.Windows.Forms.Button B_quitter;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}