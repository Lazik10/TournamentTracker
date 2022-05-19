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
    public partial class TournamentViewerForm : Form
    {
        public TournamentViewerForm()
        {
            InitializeComponent();
        }

        private void buttonConfirmScore_MouseHover(object sender, EventArgs e)
        {
            buttonConfirmScore.ForeColor = System.Drawing.Color.White;
        }

        private void buttonConfirmScore_MouseLeave(object sender, EventArgs e)
        {
            buttonConfirmScore.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }

        private void buttonConfirmScore_MouseEnter(object sender, EventArgs e)
        {
            buttonConfirmScore.ForeColor = System.Drawing.Color.White;
        }
    }
}
