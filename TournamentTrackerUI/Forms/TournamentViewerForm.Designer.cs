namespace TournamentTrackerUI.Forms
{
    partial class TournamentViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
            this.labelTournament = new System.Windows.Forms.Label();
            this.labelTournamentName = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelSecondTeamScore = new System.Windows.Forms.Label();
            this.labelFirstTeamScore = new System.Windows.Forms.Label();
            this.textBoxSecondTeamScore = new System.Windows.Forms.TextBox();
            this.textBoxFirstTeamScore = new System.Windows.Forms.TextBox();
            this.buttonConfirmScore = new System.Windows.Forms.Button();
            this.labelTeamName = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelVs = new System.Windows.Forms.Label();
            this.labelSecondTeamName = new System.Windows.Forms.Label();
            this.labelFirstTeamName = new System.Windows.Forms.Label();
            this.listBoxRoundMatchups = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxUnplayedOnly = new System.Windows.Forms.CheckBox();
            this.comboBoxRound = new System.Windows.Forms.ComboBox();
            this.labelRound = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTournament
            // 
            this.labelTournament.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTournament.AutoSize = true;
            this.labelTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTournament.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTournament.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelTournament.Location = new System.Drawing.Point(12, 18);
            this.labelTournament.Name = "labelTournament";
            this.labelTournament.Size = new System.Drawing.Size(243, 50);
            this.labelTournament.TabIndex = 0;
            this.labelTournament.Text = "Tournament:";
            this.labelTournament.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTournamentName
            // 
            this.labelTournamentName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTournamentName.AutoSize = true;
            this.labelTournamentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTournamentName.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTournamentName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelTournamentName.Location = new System.Drawing.Point(339, 20);
            this.labelTournamentName.Name = "labelTournamentName";
            this.labelTournamentName.Size = new System.Drawing.Size(291, 47);
            this.labelTournamentName.TabIndex = 1;
            this.labelTournamentName.Text = "< actual name >";
            this.labelTournamentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelSecondTeamScore);
            this.panelMain.Controls.Add(this.labelFirstTeamScore);
            this.panelMain.Controls.Add(this.textBoxSecondTeamScore);
            this.panelMain.Controls.Add(this.textBoxFirstTeamScore);
            this.panelMain.Controls.Add(this.buttonConfirmScore);
            this.panelMain.Controls.Add(this.labelTeamName);
            this.panelMain.Controls.Add(this.labelScore);
            this.panelMain.Controls.Add(this.labelVs);
            this.panelMain.Controls.Add(this.labelSecondTeamName);
            this.panelMain.Controls.Add(this.labelFirstTeamName);
            this.panelMain.Controls.Add(this.listBoxRoundMatchups);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(735, 573);
            this.panelMain.TabIndex = 2;
            // 
            // labelSecondTeamScore
            // 
            this.labelSecondTeamScore.AutoSize = true;
            this.labelSecondTeamScore.Location = new System.Drawing.Point(638, 371);
            this.labelSecondTeamScore.Name = "labelSecondTeamScore";
            this.labelSecondTeamScore.Size = new System.Drawing.Size(86, 30);
            this.labelSecondTeamScore.TabIndex = 15;
            this.labelSecondTeamScore.Text = "STScore";
            // 
            // labelFirstTeamScore
            // 
            this.labelFirstTeamScore.AutoSize = true;
            this.labelFirstTeamScore.Location = new System.Drawing.Point(638, 243);
            this.labelFirstTeamScore.Name = "labelFirstTeamScore";
            this.labelFirstTeamScore.Size = new System.Drawing.Size(85, 30);
            this.labelFirstTeamScore.TabIndex = 14;
            this.labelFirstTeamScore.Text = "FTScore";
            // 
            // textBoxSecondTeamScore
            // 
            this.textBoxSecondTeamScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSecondTeamScore.Location = new System.Drawing.Point(598, 369);
            this.textBoxSecondTeamScore.Name = "textBoxSecondTeamScore";
            this.textBoxSecondTeamScore.Size = new System.Drawing.Size(100, 35);
            this.textBoxSecondTeamScore.TabIndex = 13;
            // 
            // textBoxFirstTeamScore
            // 
            this.textBoxFirstTeamScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFirstTeamScore.Location = new System.Drawing.Point(598, 241);
            this.textBoxFirstTeamScore.Name = "textBoxFirstTeamScore";
            this.textBoxFirstTeamScore.Size = new System.Drawing.Size(100, 35);
            this.textBoxFirstTeamScore.TabIndex = 12;
            // 
            // buttonConfirmScore
            // 
            this.buttonConfirmScore.FlatAppearance.BorderSize = 3;
            this.buttonConfirmScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonConfirmScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonConfirmScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmScore.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonConfirmScore.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonConfirmScore.Location = new System.Drawing.Point(438, 499);
            this.buttonConfirmScore.Name = "buttonConfirmScore";
            this.buttonConfirmScore.Size = new System.Drawing.Size(271, 62);
            this.buttonConfirmScore.TabIndex = 11;
            this.buttonConfirmScore.Text = "Confirm";
            this.buttonConfirmScore.UseVisualStyleBackColor = true;
            this.buttonConfirmScore.Click += new System.EventHandler(this.buttonConfirmScore_Click);
            this.buttonConfirmScore.MouseEnter += new System.EventHandler(this.buttonConfirmScore_MouseEnter);
            this.buttonConfirmScore.MouseLeave += new System.EventHandler(this.buttonConfirmScore_MouseLeave);
            this.buttonConfirmScore.MouseHover += new System.EventHandler(this.buttonConfirmScore_MouseHover);
            // 
            // labelTeamName
            // 
            this.labelTeamName.AutoSize = true;
            this.labelTeamName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTeamName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelTeamName.Location = new System.Drawing.Point(464, 170);
            this.labelTeamName.Name = "labelTeamName";
            this.labelTeamName.Size = new System.Drawing.Size(71, 30);
            this.labelTeamName.TabIndex = 8;
            this.labelTeamName.Text = "Name";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelScore.Location = new System.Drawing.Point(613, 170);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(67, 30);
            this.labelScore.TabIndex = 7;
            this.labelScore.Text = "Score";
            // 
            // labelVs
            // 
            this.labelVs.AutoSize = true;
            this.labelVs.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVs.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelVs.Location = new System.Drawing.Point(480, 306);
            this.labelVs.Name = "labelVs";
            this.labelVs.Size = new System.Drawing.Size(55, 30);
            this.labelVs.TabIndex = 6;
            this.labelVs.Text = "-VS-";
            // 
            // labelSecondTeamName
            // 
            this.labelSecondTeamName.AutoSize = true;
            this.labelSecondTeamName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSecondTeamName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelSecondTeamName.Location = new System.Drawing.Point(438, 367);
            this.labelSecondTeamName.Name = "labelSecondTeamName";
            this.labelSecondTeamName.Size = new System.Drawing.Size(141, 30);
            this.labelSecondTeamName.TabIndex = 5;
            this.labelSecondTeamName.Text = "<Team Two>";
            // 
            // labelFirstTeamName
            // 
            this.labelFirstTeamName.AutoSize = true;
            this.labelFirstTeamName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFirstTeamName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelFirstTeamName.Location = new System.Drawing.Point(438, 241);
            this.labelFirstTeamName.Name = "labelFirstTeamName";
            this.labelFirstTeamName.Size = new System.Drawing.Size(140, 30);
            this.labelFirstTeamName.TabIndex = 4;
            this.labelFirstTeamName.Text = "<Team One>";
            // 
            // listBoxRoundMatchups
            // 
            this.listBoxRoundMatchups.FormattingEnabled = true;
            this.listBoxRoundMatchups.ItemHeight = 30;
            this.listBoxRoundMatchups.Location = new System.Drawing.Point(12, 138);
            this.listBoxRoundMatchups.Name = "listBoxRoundMatchups";
            this.listBoxRoundMatchups.Size = new System.Drawing.Size(399, 424);
            this.listBoxRoundMatchups.TabIndex = 3;
            this.listBoxRoundMatchups.SelectedIndexChanged += new System.EventHandler(this.listBoxRoundMatchups_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxUnplayedOnly);
            this.panel2.Controls.Add(this.comboBoxRound);
            this.panel2.Controls.Add(this.labelRound);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 54);
            this.panel2.TabIndex = 2;
            // 
            // checkBoxUnplayedOnly
            // 
            this.checkBoxUnplayedOnly.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxUnplayedOnly.AutoSize = true;
            this.checkBoxUnplayedOnly.Checked = true;
            this.checkBoxUnplayedOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUnplayedOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUnplayedOnly.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxUnplayedOnly.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.checkBoxUnplayedOnly.Location = new System.Drawing.Point(251, 16);
            this.checkBoxUnplayedOnly.Name = "checkBoxUnplayedOnly";
            this.checkBoxUnplayedOnly.Size = new System.Drawing.Size(129, 25);
            this.checkBoxUnplayedOnly.TabIndex = 2;
            this.checkBoxUnplayedOnly.Text = "Unplayed Only";
            this.checkBoxUnplayedOnly.UseVisualStyleBackColor = true;
            this.checkBoxUnplayedOnly.CheckedChanged += new System.EventHandler(this.checkBoxUnplayedOnly_CheckedChanged);
            // 
            // comboBoxRound
            // 
            this.comboBoxRound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxRound.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxRound.FormattingEnabled = true;
            this.comboBoxRound.Location = new System.Drawing.Point(89, 16);
            this.comboBoxRound.Name = "comboBoxRound";
            this.comboBoxRound.Size = new System.Drawing.Size(121, 25);
            this.comboBoxRound.TabIndex = 1;
            this.comboBoxRound.SelectedIndexChanged += new System.EventHandler(this.comboBoxRound_SelectedIndexChanged);
            // 
            // labelRound
            // 
            this.labelRound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRound.AutoSize = true;
            this.labelRound.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRound.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelRound.Location = new System.Drawing.Point(10, 11);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(78, 30);
            this.labelRound.TabIndex = 0;
            this.labelRound.Text = "Round";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTournament);
            this.panel1.Controls.Add(this.labelTournamentName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 75);
            this.panel1.TabIndex = 0;
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 573);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "TournamentViewerForm";
            this.Text = "TournamentViewer";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelTournament;
        private Label labelTournamentName;
        private Panel panelMain;
        private Panel panel1;
        private Panel panel2;
        private ComboBox comboBoxRound;
        private Label labelRound;
        private CheckBox checkBoxUnplayedOnly;
        private ListBox listBoxRoundMatchups;
        private TextBox textBoxSecondTeamScore;
        private TextBox textBoxFirstTeamScore;
        private Button buttonConfirmScore;
        private Label labelTeamName;
        private Label labelScore;
        private Label labelVs;
        private Label labelSecondTeamName;
        private Label labelFirstTeamName;
        private Label labelSecondTeamScore;
        private Label labelFirstTeamScore;
    }
}