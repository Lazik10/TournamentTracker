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
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
                button.ForeColor = System.Drawing.Color.White;
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button button)
                button.ForeColor = System.Drawing.Color.White;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
                button.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }
    }
}
