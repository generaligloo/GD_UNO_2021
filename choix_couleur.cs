using System;
using System.Windows.Forms;

namespace GD_UNO_2021
{
    public partial class choix_couleur : Form
    {
        public choix_couleur()
        {
            InitializeComponent();
            B_bleu.DialogResult = DialogResult.OK;
            B_rouge.DialogResult = DialogResult.Cancel;
            B_jaune.DialogResult = DialogResult.Abort;
            B_vert.DialogResult = DialogResult.Retry;
        }

        private void B_rouge_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void B_jaune_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void B_bleu_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void B_vert_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}