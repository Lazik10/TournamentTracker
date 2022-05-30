using TournamentTrackerLibrary;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary.Models;
using TournamentTrackerLibrary.Logic;

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
            labelFirstTeamScore.Visible = show;
            labelSecondTeamScore.Visible = show;
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

            UpdateMatchupInfoVisibility(matchup, firstTeamInfo, secondTeamInfo);
        }

        private void UpdateMatchupInfoVisibility(MatchupModel? matchup, MatchupTeamInfoModel firstTeamInfo, MatchupTeamInfoModel secondTeamInfo)
        {
            if (matchup?.Winner is null)
            {
                labelFirstTeamScore.Visible = false;
                labelSecondTeamScore.Visible = false;
                textBoxFirstTeamScore.Visible = true;
                textBoxSecondTeamScore.Visible = true;
            }
            else
            {
                labelFirstTeamScore.Visible = true;
                labelSecondTeamScore.Visible = true;
                textBoxFirstTeamScore.Visible = false;
                textBoxSecondTeamScore.Visible = false;
            }

            textBoxFirstTeamScore.Text = firstTeamInfo?.Score.ToString();
            textBoxSecondTeamScore.Text = secondTeamInfo?.Score.ToString();
            labelFirstTeamScore.Text = firstTeamInfo?.Score.ToString();
            labelSecondTeamScore.Text = secondTeamInfo?.Score.ToString();
        }

        private void checkBoxUnplayedOnly_CheckedChanged(object sender, EventArgs e)
        {
            unplayedOnly = !unplayedOnly;
            LoadMatchups();

            MatchupTeamInfoModel firstTeamInfo = new MatchupTeamInfoModel();
            MatchupTeamInfoModel secondTeamInfo = new MatchupTeamInfoModel();
            MatchupModel? matchup = listBoxRoundMatchups.SelectedItem as MatchupModel;
            if (matchup != null)
            {
                firstTeamInfo = matchup.TeamsInfo[0];
                secondTeamInfo = matchup.TeamsInfo[1];
            }
            UpdateMatchupInfoVisibility(matchup, firstTeamInfo, secondTeamInfo);
        }

        private void buttonConfirmScore_Click(object sender, EventArgs e)
        {
            if (ValidateScore())
            {
                MatchupModel matchup = (MatchupModel)listBoxRoundMatchups.SelectedItem;
                if (matchup?.Winner is not null)
                {
                    MessageBox.Show("You can't change score of a matchup that has been already played!");
                    return;
                }

                double firstTeamScore = double.Parse(textBoxFirstTeamScore.Text);
                double secondTeamScore = double.Parse(textBoxSecondTeamScore.Text);

                if (firstTeamScore == secondTeamScore)
                {
                    textBoxFirstTeamScore.Text = "";
                    textBoxSecondTeamScore.Text = "";
                    MessageBox.Show("Game's result can't be tie!");
                    return;
                }

                if (matchup is not null)
                    Matchmaking.UpdateTournamentResults(tournament, matchup, firstTeamScore, secondTeamScore);
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
