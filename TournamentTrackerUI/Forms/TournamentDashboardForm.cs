using TournamentTrackerLibrary;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerUI.Forms
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connections[0].GetAllTournaments();

        public TournamentDashboardForm()
        {
            InitializeComponent();

            UpdateFormLists();
        }

        private void UpdateFormLists()
        {
            comboLoadExistingTournament.DataSource = null;
            comboLoadExistingTournament.DataSource = tournaments.OrderBy(x => x.TournamentName).ToList();
            comboLoadExistingTournament.DisplayMember = "TournamentName";
            comboLoadExistingTournament.ValueMember = "Id";
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

        private void button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
                button.ForeColor = System.Drawing.Color.White;
        }

        private void buttonCreateTournament_Click(object sender, EventArgs e)
        {
            CreateTournamentForm tournamentForm = new CreateTournamentForm();
            tournamentForm.Show();
        }

        private void buttonLoadTournament_Click(object sender, EventArgs e)
        {
            TournamentModel selectedTournament = (TournamentModel)comboLoadExistingTournament.SelectedItem;
            TournamentViewerForm viewTournamentForm = new TournamentViewerForm(selectedTournament);
            viewTournamentForm.Show();
        }
    }
}
