namespace WinFormsApp12
{
    partial class UpdateLeagueForm
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
            btnUpdate = new Button();
            txtLosses = new TextBox();
            txtGoalsAgainst = new TextBox();
            txtGoalsFor = new TextBox();
            txtDraws = new TextBox();
            txtWins = new TextBox();
            txtMatchesPlayed = new TextBox();
            txtClubID = new TextBox();
            lbllosses = new Label();
            lblGoalsconceded = new Label();
            lblGoalsscored = new Label();
            lbldraws = new Label();
            lblwins = new Label();
            lblMatch = new Label();
            lblclub = new Label();
            lblleg = new Label();
            btnCancle = new Button();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(537, 547);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(306, 73);
            btnUpdate.TabIndex = 30;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtLosses
            // 
            txtLosses.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLosses.Location = new Point(238, 479);
            txtLosses.Name = "txtLosses";
            txtLosses.Size = new Size(370, 38);
            txtLosses.TabIndex = 24;
            // 
            // txtGoalsAgainst
            // 
            txtGoalsAgainst.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGoalsAgainst.Location = new Point(238, 421);
            txtGoalsAgainst.Name = "txtGoalsAgainst";
            txtGoalsAgainst.Size = new Size(370, 38);
            txtGoalsAgainst.TabIndex = 23;
            // 
            // txtGoalsFor
            // 
            txtGoalsFor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGoalsFor.Location = new Point(238, 356);
            txtGoalsFor.Name = "txtGoalsFor";
            txtGoalsFor.Size = new Size(370, 38);
            txtGoalsFor.TabIndex = 22;
            // 
            // txtDraws
            // 
            txtDraws.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDraws.Location = new Point(238, 295);
            txtDraws.Name = "txtDraws";
            txtDraws.Size = new Size(370, 38);
            txtDraws.TabIndex = 25;
            // 
            // txtWins
            // 
            txtWins.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWins.Location = new Point(238, 239);
            txtWins.Name = "txtWins";
            txtWins.Size = new Size(370, 38);
            txtWins.TabIndex = 21;
            // 
            // txtMatchesPlayed
            // 
            txtMatchesPlayed.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatchesPlayed.Location = new Point(238, 180);
            txtMatchesPlayed.Name = "txtMatchesPlayed";
            txtMatchesPlayed.Size = new Size(370, 38);
            txtMatchesPlayed.TabIndex = 20;
            // 
            // txtClubID
            // 
            txtClubID.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClubID.Location = new Point(238, 114);
            txtClubID.Name = "txtClubID";
            txtClubID.ReadOnly = true;
            txtClubID.Size = new Size(370, 38);
            txtClubID.TabIndex = 19;
            // 
            // lbllosses
            // 
            lbllosses.AutoSize = true;
            lbllosses.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbllosses.Location = new Point(67, 482);
            lbllosses.Name = "lbllosses";
            lbllosses.Size = new Size(124, 31);
            lbllosses.TabIndex = 17;
            lbllosses.Text = "NO.lossess";
            // 
            // lblGoalsconceded
            // 
            lblGoalsconceded.AutoSize = true;
            lblGoalsconceded.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGoalsconceded.Location = new Point(56, 424);
            lblGoalsconceded.Name = "lblGoalsconceded";
            lblGoalsconceded.Size = new Size(177, 31);
            lblGoalsconceded.TabIndex = 16;
            lblGoalsconceded.Text = "Goals conceded";
            // 
            // lblGoalsscored
            // 
            lblGoalsscored.AutoSize = true;
            lblGoalsscored.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGoalsscored.Location = new Point(67, 362);
            lblGoalsscored.Name = "lblGoalsscored";
            lblGoalsscored.Size = new Size(145, 31);
            lblGoalsscored.TabIndex = 15;
            lblGoalsscored.Text = "Goals scored";
            // 
            // lbldraws
            // 
            lbldraws.AutoSize = true;
            lbldraws.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbldraws.Location = new Point(67, 298);
            lbldraws.Name = "lbldraws";
            lbldraws.Size = new Size(77, 31);
            lbldraws.TabIndex = 14;
            lbldraws.Text = "Draws";
            // 
            // lblwins
            // 
            lblwins.AutoSize = true;
            lblwins.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblwins.Location = new Point(67, 242);
            lblwins.Name = "lblwins";
            lblwins.Size = new Size(64, 31);
            lblwins.TabIndex = 13;
            lblwins.Text = "Wins";
            // 
            // lblMatch
            // 
            lblMatch.AutoSize = true;
            lblMatch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatch.Location = new Point(67, 183);
            lblMatch.Name = "lblMatch";
            lblMatch.Size = new Size(128, 31);
            lblMatch.TabIndex = 12;
            lblMatch.Text = "NO.Matchs";
            // 
            // lblclub
            // 
            lblclub.AutoSize = true;
            lblclub.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblclub.Location = new Point(67, 117);
            lblclub.Name = "lblclub";
            lblclub.Size = new Size(89, 31);
            lblclub.TabIndex = 18;
            lblclub.Text = "Club ID";
            // 
            // lblleg
            // 
            lblleg.AutoSize = true;
            lblleg.BackColor = SystemColors.Desktop;
            lblleg.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblleg.Location = new Point(434, 0);
            lblleg.Name = "lblleg";
            lblleg.Size = new Size(269, 50);
            lblleg.TabIndex = 11;
            lblleg.Text = "Update League";
            // 
            // btnCancle
            // 
            btnCancle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancle.Location = new Point(199, 547);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new Size(306, 73);
            btnCancle.TabIndex = 31;
            btnCancle.Text = "Cancle";
            btnCancle.UseVisualStyleBackColor = true;
            btnCancle.Click += btnCancle_Click;
            // 
            // UpdateLeagueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1159, 664);
            Controls.Add(btnCancle);
            Controls.Add(btnUpdate);
            Controls.Add(txtLosses);
            Controls.Add(txtGoalsAgainst);
            Controls.Add(txtGoalsFor);
            Controls.Add(txtDraws);
            Controls.Add(txtWins);
            Controls.Add(txtMatchesPlayed);
            Controls.Add(txtClubID);
            Controls.Add(lbllosses);
            Controls.Add(lblGoalsconceded);
            Controls.Add(lblGoalsscored);
            Controls.Add(lbldraws);
            Controls.Add(lblwins);
            Controls.Add(lblMatch);
            Controls.Add(lblclub);
            Controls.Add(lblleg);
            Name = "UpdateLeagueForm";
            Text = "UpdateLeagueForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private TextBox txtLosses;
        private TextBox txtGoalsAgainst;
        private TextBox txtGoalsFor;
        private TextBox txtDraws;
        private TextBox txtWins;
        private TextBox txtMatchesPlayed;
        private TextBox txtClubID;
        private Label lbllosses;
        private Label lblGoalsconceded;
        private Label lblGoalsscored;
        private Label lbldraws;
        private Label lblwins;
        private Label lblMatch;
        private Label lblclub;
        private Label lblleg;
        private Button btnCancle;
    }
}