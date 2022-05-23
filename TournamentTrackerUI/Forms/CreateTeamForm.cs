using TournamentTrackerLibrary;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary.Models;

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

        private void buttonCreateMember_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel contestant = new PersonModel(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPhoneNumber.Text);

                foreach  (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePerson(contestant);
                }

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
    }
}
