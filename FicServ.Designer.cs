
namespace GD_UNO_2021
{
    partial class EcranServ
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LB_console = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_add = new System.Windows.Forms.TextBox();
            this.TB_port = new System.Windows.Forms.TextBox();
            this.TB_num = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.B_stop = new System.Windows.Forms.Button();
            this.B_start = new System.Windows.Forms.Button();
            this.LB_user = new System.Windows.Forms.ListBox();
            this.RTB_chat = new System.Windows.Forms.RichTextBox();
            this.B_rep_admin = new System.Windows.Forms.Button();
            this.TB_admin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LB_console
            // 
            this.LB_console.FormattingEnabled = true;
            this.LB_console.Location = new System.Drawing.Point(153, 113);
            this.LB_console.Name = "LB_console";
            this.LB_console.Size = new System.Drawing.Size(267, 147);
            this.LB_console.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port :";
            // 
            // TB_add
            // 
            this.TB_add.Location = new System.Drawing.Point(62, 5);
            this.TB_add.Name = "TB_add";
            this.TB_add.Size = new System.Drawing.Size(86, 20);
            this.TB_add.TabIndex = 3;
            this.TB_add.Text = "127.0.0.1";
            // 
            // TB_port
            // 
            this.TB_port.Location = new System.Drawing.Point(62, 30);
            this.TB_port.Name = "TB_port";
            this.TB_port.Size = new System.Drawing.Size(86, 20);
            this.TB_port.TabIndex = 4;
            this.TB_port.Text = "9000";
            // 
            // TB_num
            // 
            this.TB_num.Location = new System.Drawing.Point(92, 55);
            this.TB_num.Name = "TB_num";
            this.TB_num.ReadOnly = true;
            this.TB_num.Size = new System.Drawing.Size(56, 20);
            this.TB_num.TabIndex = 6;
            this.TB_num.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre joueur :";
            // 
            // B_stop
            // 
            this.B_stop.Enabled = false;
            this.B_stop.Location = new System.Drawing.Point(153, 58);
            this.B_stop.Name = "B_stop";
            this.B_stop.Size = new System.Drawing.Size(267, 49);
            this.B_stop.TabIndex = 8;
            this.B_stop.Text = "Stop";
            this.B_stop.UseVisualStyleBackColor = true;
            this.B_stop.Click += new System.EventHandler(this.B_stop_Click);
            // 
            // B_start
            // 
            this.B_start.Location = new System.Drawing.Point(153, 3);
            this.B_start.Name = "B_start";
            this.B_start.Size = new System.Drawing.Size(267, 49);
            this.B_start.TabIndex = 9;
            this.B_start.Text = "Start";
            this.B_start.UseVisualStyleBackColor = true;
            this.B_start.Click += new System.EventHandler(this.B_start_Click);
            // 
            // LB_user
            // 
            this.LB_user.FormattingEnabled = true;
            this.LB_user.Location = new System.Drawing.Point(10, 113);
            this.LB_user.Name = "LB_user";
            this.LB_user.Size = new System.Drawing.Size(138, 147);
            this.LB_user.TabIndex = 10;
            // 
            // RTB_chat
            // 
            this.RTB_chat.Location = new System.Drawing.Point(11, 265);
            this.RTB_chat.Name = "RTB_chat";
            this.RTB_chat.Size = new System.Drawing.Size(409, 115);
            this.RTB_chat.TabIndex = 11;
            this.RTB_chat.Text = "";
            // 
            // B_rep_admin
            // 
            this.B_rep_admin.Location = new System.Drawing.Point(11, 385);
            this.B_rep_admin.Name = "B_rep_admin";
            this.B_rep_admin.Size = new System.Drawing.Size(64, 20);
            this.B_rep_admin.TabIndex = 12;
            this.B_rep_admin.Text = "Send";
            this.B_rep_admin.UseVisualStyleBackColor = true;
            this.B_rep_admin.Click += new System.EventHandler(this.B_rep_admin_Click);
            // 
            // TB_admin
            // 
            this.TB_admin.Location = new System.Drawing.Point(81, 386);
            this.TB_admin.Name = "TB_admin";
            this.TB_admin.Size = new System.Drawing.Size(339, 20);
            this.TB_admin.TabIndex = 13;
            // 
            // EcranServ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 414);
            this.Controls.Add(this.TB_admin);
            this.Controls.Add(this.B_rep_admin);
            this.Controls.Add(this.RTB_chat);
            this.Controls.Add(this.LB_user);
            this.Controls.Add(this.B_start);
            this.Controls.Add(this.B_stop);
            this.Controls.Add(this.TB_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_port);
            this.Controls.Add(this.TB_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_console);
            this.Name = "EcranServ";
            this.Text = "Serveur de jeu";
            this.Load += new System.EventHandler(this.EcranServ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_console;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_add;
        private System.Windows.Forms.TextBox TB_port;
        private System.Windows.Forms.TextBox TB_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_stop;
        private System.Windows.Forms.Button B_start;
        private System.Windows.Forms.ListBox LB_user;
        private System.Windows.Forms.RichTextBox RTB_chat;
        private System.Windows.Forms.Button B_rep_admin;
        private System.Windows.Forms.TextBox TB_admin;
    }
}

