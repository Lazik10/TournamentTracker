namespace TournamentTrackerUI.Forms
{
    partial class TournamentDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboardForm));
            this.labelDashboard = new System.Windows.Forms.Label();
            this.comboLoadExistingTournament = new System.Windows.Forms.ComboBox();
            this.labelLoadExistingTournament = new System.Windows.Forms.Label();
            this.buttonLoadTournament = new System.Windows.Forms.Button();
            this.buttonCreateTournament = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDashboard.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDashboard.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelDashboard.Location = new System.Drawing.Point(137, 9);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(432, 50);
            this.labelDashboard.TabIndex = 4;
            this.labelDashboard.Text = "Tournament Dashboard";
            this.labelDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboLoadExistingTournament
            // 
            this.comboLoadExistingTournament.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboLoadExistingTournament.FormattingEnabled = true;
            this.comboLoadExistingTournament.Location = new System.Drawing.Point(159, 114);
            this.comboLoadExistingTournament.Name = "comboLoadExistingTournament";
            this.comboLoadExistingTournament.Size = new System.Drawing.Size(321, 29);
            this.comboLoadExistingTournament.TabIndex = 16;
            // 
            // labelLoadExistingTournament
            // 
            this.labelLoadExistingTournament.AutoSize = true;
            this.labelLoadExistingTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLoadExistingTournament.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLoadExistingTournament.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelLoadExistingTournament.Location = new System.Drawing.Point(226, 81);
            this.labelLoadExistingTournament.Name = "labelLoadExistingTournament";
            this.labelLoadExistingTournament.Size = new System.Drawing.Size(270, 30);
            this.labelLoadExistingTournament.TabIndex = 15;
            this.labelLoadExistingTournament.Text = "Load Existing Tournament";
            this.labelLoadExistingTournament.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLoadTournament
            // 
            this.buttonLoadTournament.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonLoadTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonLoadTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadTournament.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoadTournament.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonLoadTournament.Location = new System.Drawing.Point(483, 114);
            this.buttonLoadTournament.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoadTournament.Name = "buttonLoadTournament";
            this.buttonLoadTournament.Size = new System.Drawing.Size(70, 29);
            this.buttonLoadTournament.TabIndex = 23;
            this.buttonLoadTournament.Text = "Load";
            this.buttonLoadTournament.UseVisualStyleBackColor = true;
            this.buttonLoadTournament.Click += new System.EventHandler(this.buttonLoadTournament_Click);
            this.buttonLoadTournament.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonLoadTournament.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.buttonLoadTournament.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // buttonCreateTournament
            // 
            this.buttonCreateTournament.FlatAppearance.BorderSize = 3;
            this.buttonCreateTournament.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateTournament.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateTournament.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCreateTournament.Location = new System.Drawing.Point(217, 165);
            this.buttonCreateTournament.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCreateTournament.Name = "buttonCreateTournament";
            this.buttonCreateTournament.Size = new System.Drawing.Size(286, 56);
            this.buttonCreateTournament.TabIndex = 24;
            this.buttonCreateTournament.Text = "Create Tournament";
            this.buttonCreateTournament.UseVisualStyleBackColor = true;
            this.buttonCreateTournament.Click += new System.EventHandler(this.buttonCreateTournament_Click);
            this.buttonCreateTournament.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonCreateTournament.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.buttonCreateTournament.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 250);
            this.Controls.Add(this.buttonCreateTournament);
            this.Controls.Add(this.buttonLoadTournament);
            this.Controls.Add(this.comboLoadExistingTournament);
            this.Controls.Add(this.labelLoadExistingTournament);
            this.Controls.Add(this.labelDashboard);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelDashboard;
        private ComboBox comboLoadExistingTournament;
        private Label labelLoadExistingTournament;
        private Button buttonLoadTournament;
        private Button buttonCreateTournament;
    }
}