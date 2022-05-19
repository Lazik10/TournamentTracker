using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournamentTrackerUI.Forms
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void buttonCreatePrize_MouseHover(object sender, EventArgs e)
        {
            buttonCreatePrize.ForeColor = System.Drawing.Color.White;
        }

        private void buttonCreatePrize_MouseEnter(object sender, EventArgs e)
        {
            buttonCreatePrize.ForeColor = System.Drawing.Color.White;
        }

        private void buttonCreatePrize_MouseLeave(object sender, EventArgs e)
        {
            buttonCreatePrize.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }
    }
}
