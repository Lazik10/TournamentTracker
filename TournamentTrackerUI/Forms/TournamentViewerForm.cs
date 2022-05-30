using TournamentTrackerLibrary;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerUI.Forms
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        bool unplayedOnly;

        public TournamentViewerForm(TournamentModel tournament)
        {
            InitializeComponent();

            this.tournament = tournament;
            unplayedOnly = checkBoxUnplayedOnly.Checked;
            LoadFormData();
        }

        private void LoadFormData()
        {
            labelTournamentName.Text = tournament.TournamentName;

            List<int> roundsInTournament = Enumerable.Range(1, tournament.Rounds.Count).ToList();
            comboBoxRound.DataSource = roundsInTournament;
            comboBoxRound.SelectedIndex = roundsInTournament.Count > 0 ? 0 : -1;

            LoadMatchups();
        }

        private void LoadMatchups()
        {
            if (tournament.Rounds.Count > 0)
            {
                listBoxRoundMatchups.DataSource = null;
                listBoxRoundMatchups.DataSource = unplayedOnly ? tournament.Rounds[comboBoxRound.SelectedIndex].Where(x => x.Winner?.Id == null).ToList()
                                                               : tournament.Rounds[comboBoxRound.SelectedIndex];
                listBoxRoundMatchups.DisplayMember = "TeamsCompeting";
            }

            if (listBoxRoundMatchups.Items.Count > 0)
                DisplayMatchupInfo(true);
            else
                DisplayMatchupInfo(false);
        }

        private void DisplayMatchupInfo(bool show)
        {
            labelFirstTeamName.Visible = show;
            textBoxFirstTeamScore.Visible = show;
            labelSecondTeamName.Visible = show;
            textBoxSecondTeamScore.Visible = show;
            labelScore.Visible = show;
            labelVs.Visible = show;
            labelTeamName.Visible = show;
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

        private void TournamentViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TournamentDashboardForm dashboard = new TournamentDashboardForm();
            dashboard.Show();
        }

        private void comboBoxRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
        }

        private void listBoxRoundMatchups_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchupTeamInfoModel firstTeamInfo = new MatchupTeamInfoModel();
            MatchupTeamInfoModel secondTeamInfo = new MatchupTeamInfoModel();

            MatchupModel? matchup = listBoxRoundMatchups.SelectedItem as MatchupModel;
            if (matchup != null)
            {
                firstTeamInfo = matchup.TeamsInfo[0];
                secondTeamInfo = matchup.TeamsInfo[1];
            }

            string? firstTeamName = tournament.EntryTeams.Find(x => x.Id == firstTeamInfo?.TeamCompetingId)?.TeamName;
            string? secondTeamName = tournament.EntryTeams.Find(x => x.Id == secondTeamInfo?.TeamCompetingId)?.TeamName;

            labelFirstTeamName.Text = string.IsNullOrEmpty(firstTeamName) ? "Bye" : firstTeamName;
            labelSecondTeamName.Text = string.IsNullOrEmpty(secondTeamName) ? "Bye" : secondTeamName;

            textBoxFirstTeamScore.Text = firstTeamInfo?.Score.ToString();
            textBoxSecondTeamScore.Text = secondTeamInfo?.Score.ToString();
        }

        private void checkBoxUnplayedOnly_CheckedChanged(object sender, EventArgs e)
        {
            unplayedOnly = !unplayedOnly;
            LoadMatchups();
        }

        private void buttonConfirmScore_Click(object sender, EventArgs e)
        {
            if (ValidateScore())
            {
                MatchupModel matchup = (MatchupModel)listBoxRoundMatchups.SelectedItem;
                List<MatchupModel> nextRoundMatchups;

                double firstTeamScore = double.Parse(textBoxFirstTeamScore.Text);
                double secondTeamScore = double.Parse(textBoxSecondTeamScore.Text);

                int? winnerId = 0;

                if (firstTeamScore > secondTeamScore)
                    winnerId = matchup.TeamsInfo[0].TeamCompetingId;
                else if (secondTeamScore > firstTeamScore)
                    winnerId = matchup.TeamsInfo[1].TeamCompetingId;
                else
                {
                    MessageBox.Show("Final score can't be tie! Please fix your score!");
                    return;
                }

                matchup.TeamsInfo[0].Score = firstTeamScore;
                matchup.TeamsInfo[1].Score = secondTeamScore;
                matchup.Winner = tournament.EntryTeams.Where(x => x.Id == winnerId).First();
                matchup.WinnerId = winnerId;

                // There is no matchap in next round if we are evaluating last round (finale)
                if (matchup.MatchupRound < tournament.Rounds.Count)
                {
                    // Current matchup round is based from 1 to X, this means it also has an index of next round because of zero based index of List
                    nextRoundMatchups = tournament.Rounds[matchup.MatchupRound];
                    foreach (MatchupModel roundMatchup in nextRoundMatchups)
                    {
                        foreach (MatchupTeamInfoModel infoModel in roundMatchup.TeamsInfo)
                        {
                            if (infoModel.ParentMatchupId == matchup.Id)
                            {
                                infoModel.TeamCompeting = matchup.Winner;
                                infoModel.TeamCompetingId = matchup.WinnerId;
                            }
                        }

                        roundMatchup.TeamsCompeting = roundMatchup.TeamsInfo[0]?.TeamCompeting?.TeamName + " vs " +
                                                      roundMatchup.TeamsInfo[1]?.TeamCompeting?.TeamName;

                        foreach (IDataConnection connection in GlobalConfig.Connections)
                        {
                            connection.UpdateMatchup(roundMatchup);
                        }
                    }
                }

                foreach (IDataConnection connection in GlobalConfig.Connections)
                {
                    connection.UpdateMatchup(matchup);
                }

                LoadMatchups();
            }
            else
                MessageBox.Show("Your score is invalid");
        }

        private bool ValidateScore()
        {
            return double.TryParse(textBoxFirstTeamScore.Text, out _) && double.TryParse(textBoxSecondTeamScore.Text, out _);
        }
    }
}
