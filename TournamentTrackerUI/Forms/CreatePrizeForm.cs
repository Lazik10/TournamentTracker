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

namespace TournamentTrackerUI.Forms
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void buttonCreatePrize_MouseHover(object sender, EventArgs e)
        {
            buttonCreatePrize.ForeColor = System.Drawing.Color.White;
        }

        private void buttonCreatePrize_MouseEnter(object sender, EventArgs e)
        {
            buttonCreatePrize.ForeColor = System.Drawing.Color.White;
        }

        private void buttonCreatePrize_MouseLeave(object sender, EventArgs e)
        {
            buttonCreatePrize.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }

        private void buttonCreatePrize_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel prize = new PrizeModel(
                    textBoxPrizeNumber.Text,
                    textBoxPrizeName.Text,
                    textBoxPrizeAmount.Text,
                    textBoxPrizePercentage.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(prize);
                }

                ClearForm();
            }
            else
                MessageBox.Show("Your entered informations are invalid! Please check it again");
        }

        private bool ValidateForm()
        {
            bool validation = true;

            if (!int.TryParse(textBoxPrizeNumber.Text, out int placeNumber))
                validation = false;

            if (textBoxPrizeName.Text.Length < 0)
                validation = false;

            if (!decimal.TryParse(textBoxPrizeAmount.Text, out decimal prizeAmount))
                validation = false;

            if (!double.TryParse(textBoxPrizePercentage.Text, out double prizePercentage))
                validation = false;

            if (placeNumber < 1)
                validation = false;

            if (prizeAmount <= 0 && prizePercentage <= 0)
                validation = false;

            if (prizePercentage < 0 || prizePercentage > 100)
                validation = false;

            if (prizeAmount > 0 && prizePercentage > 0)
                validation = false;

            return validation;
        }

        private void ClearForm()
        {
            textBoxPrizeNumber.Text = "";
            textBoxPrizeName.Text = "";
            textBoxPrizeAmount.Text = "0";
            textBoxPrizePercentage.Text = "0";
        }
    }
}
