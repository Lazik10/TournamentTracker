using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTrackerLibrary;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerUI.Forms
{
    public partial class CreateTournamentForm : Form
    {
        List<TeamModel> availableTeams = GlobalConfig.Connections[0].GetAllTeams();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            UpdateFormLists();
        }

        private void UpdateFormLists()
        {
            comboBoxSelectTeam.DataSource = null;
            comboBoxSelectTeam.DataSource = availableTeams;
            comboBoxSelectTeam.DisplayMember = "TeamName";
            comboBoxSelectTeam.ValueMember = "Id";

            listBoxTeams.DataSource = null;
            listBoxTeams.DataSource = selectedTeams;
            listBoxTeams.DisplayMember = "TeamName";
            listBoxTeams.ValueMember = "Id";

            listBoxPrizes.DataSource = null;
            listBoxPrizes.DataSource = selectedPrizes;
            listBoxPrizes.DisplayMember = "PlaceName";
            listBoxPrizes.ValueMember = "Id";
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

        private void button_MounseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
                button.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }

        private void buttonAddTeam_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)comboBoxSelectTeam.SelectedItem;

            if (team is not null)
            {
                availableTeams.Remove(team);
                selectedTeams.Add(team);
            }

            UpdateFormLists();
        }
    }
}
