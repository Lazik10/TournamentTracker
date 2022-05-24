using TournamentTrackerLibrary;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerUI.Forms
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connections[0].GetAllPersons();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();

/*            CreateSampleData();*/
            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel("Lazik", "Lazik", "", ""));
            availableTeamMembers.Add(new PersonModel("Lazik", "Lazik", "", ""));

            selectedTeamMembers.Add(new PersonModel("Lazik", "Lazik", "", ""));
            selectedTeamMembers.Add(new PersonModel("Lazik", "Lazik", "", ""));
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

        private void buttonCreateMember_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel contestant = new PersonModel(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPhoneNumber.Text);

                foreach  (IDataConnection db in GlobalConfig.Connections)
                {
                    contestant = db.CreatePerson(contestant);
                }

                selectedTeamMembers.Add(contestant);
                WireUpLists();

                ClearForm();
            }
            else
                MessageBox.Show("You need to fill all the required data!");
        }

        private bool ValidateForm()
        {
            if (textBoxFirstName.Text.Length == 0 || textBoxLastName.Text.Length == 0
                || textBoxPhoneNumber.Text.Length == 0 || textBoxPhoneNumber.Text.Length == 0)
                return false;
            return true;
        }

        private void ClearForm()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxPhoneNumber.Text = "";
        }

        private void WireUpLists()
        {
            listBoxTeamMembers.DataSource = null;
            listBoxTeamMembers.DataSource = selectedTeamMembers;
            listBoxTeamMembers.DisplayMember = "FullName";
            listBoxTeamMembers.ValueMember = "Id";

            comboBoxSelectTeamMember.DataSource = null;
            comboBoxSelectTeamMember.DataSource = availableTeamMembers;
            comboBoxSelectTeamMember.DisplayMember = "FullName";
            comboBoxSelectTeamMember.ValueMember = "Id";
        }

        private void buttonAddTeam_Click(object sender, EventArgs e)
        {
            PersonModel person = (PersonModel)comboBoxSelectTeamMember.SelectedItem;
            
            availableTeamMembers.Remove(person);
            selectedTeamMembers.Add(person);

            WireUpLists();
        }

        private void buttonDeleteTeamMember_Click(object sender, EventArgs e)
        {
            PersonModel person = (PersonModel)listBoxTeamMembers.SelectedItem;
            if (person != null)
            {
                availableTeamMembers.Add(person);
                selectedTeamMembers.Remove(person);
            }

            WireUpLists();
        }

        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            TeamModel team = new TeamModel();
            team.TeamName = textBoxTeamName.Text;
            team.TeamMembers.AddRange(selectedTeamMembers);

            foreach (IDataConnection connection in GlobalConfig.Connections)
            {
                connection.CreateTeam(team);
            }

            // TODO - If we aren't closing this form after creation of the team, reset the form
        }
    }
}
