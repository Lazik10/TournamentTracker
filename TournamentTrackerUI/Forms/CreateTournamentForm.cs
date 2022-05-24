﻿using TournamentTrackerLibrary;
using TournamentTrackerLibrary.Models;
using TournamentTrackerUI.Interfaces;

namespace TournamentTrackerUI.Forms
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
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
            comboBoxSelectTeam.DataSource = availableTeams.OrderBy(x => x.TeamName).ToList();
            comboBoxSelectTeam.DisplayMember = "TeamName";
            comboBoxSelectTeam.ValueMember = "Id";

            listBoxTeams.DataSource = null;
            listBoxTeams.DataSource = selectedTeams.OrderBy(x => x.TeamName).ToList();
            listBoxTeams.DisplayMember = "TeamName";
            listBoxTeams.ValueMember = "Id";

            listBoxPrizes.DataSource = null;
            listBoxPrizes.DataSource = selectedPrizes.OrderBy(x => x.PlaceNumber).ToList();
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

        private void buttonDeleteTeam_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)listBoxTeams.SelectedItem;

            if (team is not null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);
            }

            UpdateFormLists();
        }

        private void buttonCreatePrize_Click(object sender, EventArgs e)
        {
            CreatePrizeForm prizeForm = new CreatePrizeForm(this);
            prizeForm.Show();
        }

        private void buttonPrize_Click(object sender, EventArgs e)
        {
            PrizeModel prize = (PrizeModel)listBoxPrizes.SelectedItem;

            if (prize is not null)
            {
                selectedPrizes.Remove(prize);
            }

            UpdateFormLists();
        }
        public void GetPrize(PrizeModel prize)
        {
            selectedPrizes.Add(prize);
            UpdateFormLists();
        }

        public void GetTeam(TeamModel team)
        {
            selectedTeams.Add(team);
            UpdateFormLists();
        }

        private void linkLabelCreateNewTeam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm teamForm = new CreateTeamForm();
            teamForm.Show();
        }
    }
}
