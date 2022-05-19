namespace TournamentTrackerUI.Forms
{
    partial class CreateTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
            this.labelCreateTeam = new System.Windows.Forms.Label();
            this.textBoxTournamentName = new System.Windows.Forms.TextBox();
            this.labelTournamentName = new System.Windows.Forms.Label();
            this.buttonAddTeam = new System.Windows.Forms.Button();
            this.comboBoxSelectTeam = new System.Windows.Forms.ComboBox();
            this.labelSelectTeam = new System.Windows.Forms.Label();
            this.groupBoxNewMember = new System.Windows.Forms.GroupBox();
            this.buttonCreateMember = new System.Windows.Forms.Button();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.listBoxTeamMembers = new System.Windows.Forms.ListBox();
            this.buttonDeleteTeamMember = new System.Windows.Forms.Button();
            this.buttonCreateTeam = new System.Windows.Forms.Button();
            this.groupBoxNewMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCreateTeam
            // 
            this.labelCreateTeam.AutoSize = true;
            this.labelCreateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCreateTeam.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCreateTeam.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelCreateTeam.Location = new System.Drawing.Point(286, 9);
            this.labelCreateTeam.Name = "labelCreateTeam";
            this.labelCreateTeam.Size = new System.Drawing.Size(237, 50);
            this.labelCreateTeam.TabIndex = 2;
            this.labelCreateTeam.Text = "Create Team";
            this.labelCreateTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTournamentName
            // 
            this.textBoxTournamentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTournamentName.Location = new System.Drawing.Point(155, 79);
            this.textBoxTournamentName.Name = "textBoxTournamentName";
            this.textBoxTournamentName.Size = new System.Drawing.Size(263, 35);
            this.textBoxTournamentName.TabIndex = 5;
            // 
            // labelTournamentName
            // 
            this.labelTournamentName.AutoSize = true;
            this.labelTournamentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTournamentName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTournamentName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelTournamentName.Location = new System.Drawing.Point(21, 81);
            this.labelTournamentName.Name = "labelTournamentName";
            this.labelTournamentName.Size = new System.Drawing.Size(128, 30);
            this.labelTournamentName.TabIndex = 4;
            this.labelTournamentName.Text = "Team Name";
            this.labelTournamentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddTeam
            // 
            this.buttonAddTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAddTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddTeam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddTeam.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAddTeam.Location = new System.Drawing.Point(345, 172);
            this.buttonAddTeam.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddTeam.Name = "buttonAddTeam";
            this.buttonAddTeam.Size = new System.Drawing.Size(73, 29);
            this.buttonAddTeam.TabIndex = 15;
            this.buttonAddTeam.Text = "Add";
            this.buttonAddTeam.UseVisualStyleBackColor = true;
            this.buttonAddTeam.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonAddTeam.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.buttonAddTeam.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // comboBoxSelectTeam
            // 
            this.comboBoxSelectTeam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxSelectTeam.FormattingEnabled = true;
            this.comboBoxSelectTeam.Location = new System.Drawing.Point(21, 172);
            this.comboBoxSelectTeam.Name = "comboBoxSelectTeam";
            this.comboBoxSelectTeam.Size = new System.Drawing.Size(321, 29);
            this.comboBoxSelectTeam.TabIndex = 14;
            // 
            // labelSelectTeam
            // 
            this.labelSelectTeam.AutoSize = true;
            this.labelSelectTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSelectTeam.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSelectTeam.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelSelectTeam.Location = new System.Drawing.Point(21, 139);
            this.labelSelectTeam.Name = "labelSelectTeam";
            this.labelSelectTeam.Size = new System.Drawing.Size(216, 30);
            this.labelSelectTeam.TabIndex = 13;
            this.labelSelectTeam.Text = "Select Team Member";
            this.labelSelectTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxNewMember
            // 
            this.groupBoxNewMember.Controls.Add(this.buttonCreateMember);
            this.groupBoxNewMember.Controls.Add(this.textBoxPhoneNumber);
            this.groupBoxNewMember.Controls.Add(this.labelPhoneNumber);
            this.groupBoxNewMember.Controls.Add(this.textBoxEmail);
            this.groupBoxNewMember.Controls.Add(this.labelEmail);
            this.groupBoxNewMember.Controls.Add(this.textBoxLastName);
            this.groupBoxNewMember.Controls.Add(this.labelLastName);
            this.groupBoxNewMember.Controls.Add(this.textBoxFirstName);
            this.groupBoxNewMember.Controls.Add(this.labelFirstName);
            this.groupBoxNewMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxNewMember.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBoxNewMember.Location = new System.Drawing.Point(21, 224);
            this.groupBoxNewMember.Name = "groupBoxNewMember";
            this.groupBoxNewMember.Size = new System.Drawing.Size(397, 279);
            this.groupBoxNewMember.TabIndex = 16;
            this.groupBoxNewMember.TabStop = false;
            this.groupBoxNewMember.Text = "New Member";
            // 
            // buttonCreateMember
            // 
            this.buttonCreateMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateMember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateMember.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateMember.Location = new System.Drawing.Point(134, 233);
            this.buttonCreateMember.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCreateMember.Name = "buttonCreateMember";
            this.buttonCreateMember.Size = new System.Drawing.Size(144, 35);
            this.buttonCreateMember.TabIndex = 16;
            this.buttonCreateMember.Text = "Create Member";
            this.buttonCreateMember.UseVisualStyleBackColor = true;
            this.buttonCreateMember.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonCreateMember.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.buttonCreateMember.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(151, 188);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(240, 29);
            this.textBoxPhoneNumber.TabIndex = 11;
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPhoneNumber.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelPhoneNumber.Location = new System.Drawing.Point(6, 186);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(76, 30);
            this.labelPhoneNumber.TabIndex = 10;
            this.labelPhoneNumber.Text = "Phone";
            this.labelPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Location = new System.Drawing.Point(151, 139);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(240, 29);
            this.textBoxEmail.TabIndex = 9;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelEmail.Location = new System.Drawing.Point(6, 137);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(66, 30);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Text = "Email";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLastName.Location = new System.Drawing.Point(151, 90);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(240, 29);
            this.textBoxLastName.TabIndex = 7;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLastName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLastName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelLastName.Location = new System.Drawing.Point(6, 88);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(116, 30);
            this.labelLastName.TabIndex = 6;
            this.labelLastName.Text = "Last Name";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFirstName.Location = new System.Drawing.Point(151, 39);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(240, 29);
            this.textBoxFirstName.TabIndex = 5;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelFirstName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFirstName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelFirstName.Location = new System.Drawing.Point(6, 37);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(119, 30);
            this.labelFirstName.TabIndex = 4;
            this.labelFirstName.Text = "First Name";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxTeamMembers
            // 
            this.listBoxTeamMembers.FormattingEnabled = true;
            this.listBoxTeamMembers.ItemHeight = 30;
            this.listBoxTeamMembers.Location = new System.Drawing.Point(446, 79);
            this.listBoxTeamMembers.Name = "listBoxTeamMembers";
            this.listBoxTeamMembers.Size = new System.Drawing.Size(348, 394);
            this.listBoxTeamMembers.TabIndex = 17;
            // 
            // buttonDeleteTeamMember
            // 
            this.buttonDeleteTeamMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDeleteTeamMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDeleteTeamMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteTeamMember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteTeamMember.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDeleteTeamMember.Location = new System.Drawing.Point(446, 478);
            this.buttonDeleteTeamMember.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDeleteTeamMember.Name = "buttonDeleteTeamMember";
            this.buttonDeleteTeamMember.Size = new System.Drawing.Size(348, 25);
            this.buttonDeleteTeamMember.TabIndex = 20;
            this.buttonDeleteTeamMember.Text = "Delete";
            this.buttonDeleteTeamMember.UseVisualStyleBackColor = true;
            this.buttonDeleteTeamMember.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonDeleteTeamMember.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.buttonDeleteTeamMember.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // buttonCreateTeam
            // 
            this.buttonCreateTeam.FlatAppearance.BorderSize = 3;
            this.buttonCreateTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateTeam.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateTeam.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateTeam.Location = new System.Drawing.Point(274, 521);
            this.buttonCreateTeam.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCreateTeam.Name = "buttonCreateTeam";
            this.buttonCreateTeam.Size = new System.Drawing.Size(286, 56);
            this.buttonCreateTeam.TabIndex = 21;
            this.buttonCreateTeam.Text = "Create Team";
            this.buttonCreateTeam.UseVisualStyleBackColor = true;
            this.buttonCreateTeam.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonCreateTeam.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.buttonCreateTeam.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(822, 592);
            this.Controls.Add(this.buttonCreateTeam);
            this.Controls.Add(this.buttonDeleteTeamMember);
            this.Controls.Add(this.listBoxTeamMembers);
            this.Controls.Add(this.groupBoxNewMember);
            this.Controls.Add(this.buttonAddTeam);
            this.Controls.Add(this.comboBoxSelectTeam);
            this.Controls.Add(this.labelSelectTeam);
            this.Controls.Add(this.textBoxTournamentName);
            this.Controls.Add(this.labelTournamentName);
            this.Controls.Add(this.labelCreateTeam);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.groupBoxNewMember.ResumeLayout(false);
            this.groupBoxNewMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelCreateTeam;
        private TextBox textBoxTournamentName;
        private Label labelTournamentName;
        private Button buttonAddTeam;
        private ComboBox comboBoxSelectTeam;
        private Label labelSelectTeam;
        private GroupBox groupBoxNewMember;
        private Button buttonCreateMember;
        private TextBox textBoxPhoneNumber;
        private Label labelPhoneNumber;
        private TextBox textBoxEmail;
        private Label labelEmail;
        private TextBox textBoxLastName;
        private Label labelLastName;
        private TextBox textBoxFirstName;
        private Label labelFirstName;
        private ListBox listBoxTeamMembers;
        private Button buttonDeleteTeamMember;
        private Button buttonCreateTeam;
    }
}