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
            {
                listBoxRoundMatchups.SelectedIndex = 0;
                DisplayMatchupInfo(true);
            }
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
            GetSelectedMatchupInfo(out MatchupModel? matchup, out MatchupTeamInfoModel firstTeamInfo, out MatchupTeamInfoModel secondTeamInfo);
            UpdateMatchupInfoVisibility(matchup, firstTeamInfo, secondTeamInfo);
        }

        private void listBoxRoundMatchups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedMatchupInfo(out MatchupModel? matchup, out MatchupTeamInfoModel firstTeamInfo, out MatchupTeamInfoModel secondTeamInfo);

            string? firstTeamName = tournament.EntryTeams.Find(x => x.Id == firstTeamInfo?.TeamCompetingId)?.TeamName;
            string? secondTeamName = tournament.EntryTeams.Find(x => x.Id == secondTeamInfo?.TeamCompetingId)?.TeamName;

            labelFirstTeamName.Text = string.IsNullOrEmpty(firstTeamName) ? "Bye" : firstTeamName;
            labelSecondTeamName.Text = string.IsNullOrEmpty(secondTeamName) ? "Bye" : secondTeamName;

            UpdateMatchupInfoVisibility(matchup, firstTeamInfo, secondTeamInfo);
        }

        private void UpdateMatchupInfoVisibility(MatchupModel? matchup, MatchupTeamInfoModel firstTeamInfo, MatchupTeamInfoModel secondTeamInfo)
        {
            if (matchup is null)
            {
                labelFirstTeamName.Visible = false;
                labelSecondTeamName.Visible = false;
                textBoxFirstTeamScore.Visible = false;
                textBoxSecondTeamScore.Visible = false;
                return;
            }

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
            GetSelectedMatchupInfo(out MatchupModel? matchup, out MatchupTeamInfoModel firstTeamInfo, out MatchupTeamInfoModel secondTeamInfo);
            UpdateMatchupInfoVisibility(matchup, firstTeamInfo, secondTeamInfo);
        }

        private void buttonConfirmScore_Click(object sender, EventArgs e)
        {
            MatchupModel matchup = (MatchupModel)listBoxRoundMatchups.SelectedItem;
            if (!PreviousRoundCompleted(matchup))
                return;

            if (ValidateScore())
            {
                if (matchup?.Winner is not null)
                {
                    MessageBox.Show("You can't change score of a matchup that has been already played!");
                    return;
                }

                double firstTeamScore = double.Parse(textBoxFirstTeamScore.Text);
                double secondTeamScore = double.Parse(textBoxSecondTeamScore.Text);

                if (firstTeamScore == secondTeamScore)
                {
                    ClearScore();
                    MessageBox.Show("Game's result can't be tie!");
                    return;
                }

                if (matchup is not null)
                    Matchmaking.UpdateTournamentResults(tournament, matchup, firstTeamScore, secondTeamScore);
                
                LoadMatchups();

                GetSelectedMatchupInfo(out MatchupModel? matchupNew, out MatchupTeamInfoModel firstTeamInfo, out MatchupTeamInfoModel secondTeamInfo);
                UpdateMatchupInfoVisibility(matchupNew, firstTeamInfo, secondTeamInfo);
            }
            else
                MessageBox.Show("Your score is invalid");
        }

        private bool PreviousRoundCompleted(MatchupModel matchup)
        {
            int matchupRoundId = matchup.MatchupRound;
            if (matchupRoundId > 1)
            {
                var matchups = tournament.Rounds[matchupRoundId - 1].Where(x => x.WinnerId == null).ToList();
                if (matchups.Count > 0)
                {
                    ClearScore();
                    MessageBox.Show("Previous round is not finished yet.");
                    return false;
                }
            }
            return true;
        }

        private bool ValidateScore()
        {
            return double.TryParse(textBoxFirstTeamScore.Text, out _) && double.TryParse(textBoxSecondTeamScore.Text, out _);
        }

        private void ClearScore()
        {
            textBoxFirstTeamScore.Text = "";
            textBoxSecondTeamScore.Text = "";
        }

        private void GetSelectedMatchupInfo(out MatchupModel? matchup, out MatchupTeamInfoModel firstTeamInfo, out MatchupTeamInfoModel secondTeamInfo)
        {
            firstTeamInfo = new MatchupTeamInfoModel();
            secondTeamInfo = new MatchupTeamInfoModel();
            matchup = listBoxRoundMatchups.SelectedItem as MatchupModel;
            if (matchup != null)
            {
                firstTeamInfo = matchup.TeamsInfo[0];
                secondTeamInfo = matchup.TeamsInfo[1];
            }
        }
    }
}
