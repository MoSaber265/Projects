namespace WinFormsApp12
{
    partial class LeagueTableForm
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
            lblleg = new Label();
            lblclub = new Label();
            lblMatch = new Label();
            lblwins = new Label();
            lbldraws = new Label();
            lblGoalsscored = new Label();
            lblGoalsconceded = new Label();
            lbllosses = new Label();
            txtClubId = new TextBox();
            txtMatchesPlayed = new TextBox();
            txtWins = new TextBox();
            txtDraws = new TextBox();
            txtGoalsFor = new TextBox();
            txtGoalsAgainst = new TextBox();
            txtLosses = new TextBox();
            dgvLeagueStandings = new DataGridView();
            label1 = new Label();
            btnback = new Button();
            btnShow = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLeagueStandings).BeginInit();
            SuspendLayout();
            // 
            // lblleg
            // 
            lblleg.AutoSize = true;
            lblleg.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblleg.Location = new Point(537, 9);
            lblleg.Name = "lblleg";
            lblleg.Size = new Size(150, 50);
            lblleg.TabIndex = 0;
            lblleg.Text = "LEAGUE";
            // 
            // lblclub
            // 
            lblclub.AutoSize = true;
            lblclub.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblclub.Location = new Point(33, 102);
            lblclub.Name = "lblclub";
            lblclub.Size = new Size(89, 31);
            lblclub.TabIndex = 0;
            lblclub.Text = "Club ID";
            // 
            // lblMatch
            // 
            lblMatch.AutoSize = true;
            lblMatch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatch.Location = new Point(33, 168);
            lblMatch.Name = "lblMatch";
            lblMatch.Size = new Size(128, 31);
            lblMatch.TabIndex = 0;
            lblMatch.Text = "NO.Matchs";
            // 
            // lblwins
            // 
            lblwins.AutoSize = true;
            lblwins.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblwins.Location = new Point(33, 227);
            lblwins.Name = "lblwins";
            lblwins.Size = new Size(64, 31);
            lblwins.TabIndex = 0;
            lblwins.Text = "Wins";
            // 
            // lbldraws
            // 
            lbldraws.AutoSize = true;
            lbldraws.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbldraws.Location = new Point(33, 283);
            lbldraws.Name = "lbldraws";
            lbldraws.Size = new Size(77, 31);
            lbldraws.TabIndex = 0;
            lbldraws.Text = "Draws";
            // 
            // lblGoalsscored
            // 
            lblGoalsscored.AutoSize = true;
            lblGoalsscored.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGoalsscored.Location = new Point(33, 347);
            lblGoalsscored.Name = "lblGoalsscored";
            lblGoalsscored.Size = new Size(145, 31);
            lblGoalsscored.TabIndex = 0;
            lblGoalsscored.Text = "Goals scored";
            // 
            // lblGoalsconceded
            // 
            lblGoalsconceded.AutoSize = true;
            lblGoalsconceded.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGoalsconceded.Location = new Point(22, 409);
            lblGoalsconceded.Name = "lblGoalsconceded";
            lblGoalsconceded.Size = new Size(177, 31);
            lblGoalsconceded.TabIndex = 0;
            lblGoalsconceded.Text = "Goals conceded";
            // 
            // lbllosses
            // 
            lbllosses.AutoSize = true;
            lbllosses.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbllosses.Location = new Point(33, 467);
            lbllosses.Name = "lbllosses";
            lbllosses.Size = new Size(124, 31);
            lbllosses.TabIndex = 0;
            lbllosses.Text = "NO.lossess";
            // 
            // txtClubId
            // 
            txtClubId.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClubId.Location = new Point(204, 99);
            txtClubId.Name = "txtClubId";
            txtClubId.Size = new Size(370, 38);
            txtClubId.TabIndex = 1;
            // 
            // txtMatchesPlayed
            // 
            txtMatchesPlayed.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatchesPlayed.Location = new Point(204, 165);
            txtMatchesPlayed.Name = "txtMatchesPlayed";
            txtMatchesPlayed.Size = new Size(370, 38);
            txtMatchesPlayed.TabIndex = 1;
            // 
            // txtWins
            // 
            txtWins.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWins.Location = new Point(204, 224);
            txtWins.Name = "txtWins";
            txtWins.Size = new Size(370, 38);
            txtWins.TabIndex = 1;
            // 
            // txtDraws
            // 
            txtDraws.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDraws.Location = new Point(204, 280);
            txtDraws.Name = "txtDraws";
            txtDraws.Size = new Size(370, 38);
            txtDraws.TabIndex = 1;
            // 
            // txtGoalsFor
            // 
            txtGoalsFor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGoalsFor.Location = new Point(204, 341);
            txtGoalsFor.Name = "txtGoalsFor";
            txtGoalsFor.Size = new Size(370, 38);
            txtGoalsFor.TabIndex = 1;
            // 
            // txtGoalsAgainst
            // 
            txtGoalsAgainst.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGoalsAgainst.Location = new Point(204, 406);
            txtGoalsAgainst.Name = "txtGoalsAgainst";
            txtGoalsAgainst.Size = new Size(370, 38);
            txtGoalsAgainst.TabIndex = 1;
            // 
            // txtLosses
            // 
            txtLosses.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLosses.Location = new Point(204, 464);
            txtLosses.Name = "txtLosses";
            txtLosses.Size = new Size(370, 38);
            txtLosses.TabIndex = 1;
            // 
            // dgvLeagueStandings
            // 
            dgvLeagueStandings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeagueStandings.BackgroundColor = SystemColors.Desktop;
            dgvLeagueStandings.BorderStyle = BorderStyle.None;
            dgvLeagueStandings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeagueStandings.GridColor = SystemColors.Desktop;
            dgvLeagueStandings.Location = new Point(829, 127);
            dgvLeagueStandings.Name = "dgvLeagueStandings";
            dgvLeagueStandings.ReadOnly = true;
            dgvLeagueStandings.RowHeadersWidth = 51;
            dgvLeagueStandings.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvLeagueStandings.Size = new Size(415, 495);
            dgvLeagueStandings.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1023, 74);
            label1.Name = "label1";
            label1.Size = new Size(88, 50);
            label1.TabIndex = 0;
            label1.Text = "LIST";
            // 
            // btnback
            // 
            btnback.BackColor = SystemColors.ScrollBar;
            btnback.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnback.Location = new Point(247, 519);
            btnback.Name = "btnback";
            btnback.Size = new Size(103, 75);
            btnback.TabIndex = 9;
            btnback.Text = "BACK";
            btnback.UseVisualStyleBackColor = false;
            btnback.Click += btnback_Click;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.Silver;
            btnShow.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShow.Location = new Point(645, 521);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(103, 77);
            btnShow.TabIndex = 6;
            btnShow.Text = "SHOW";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ImageAlign = ContentAlignment.BottomRight;
            btnDelete.Location = new Point(380, 519);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 77);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Lime;
            btnAdd.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(514, 519);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 77);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(110, 521);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 73);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // LeagueTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1256, 679);
            Controls.Add(btnUpdate);
            Controls.Add(btnback);
            Controls.Add(btnShow);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvLeagueStandings);
            Controls.Add(txtLosses);
            Controls.Add(txtGoalsAgainst);
            Controls.Add(txtGoalsFor);
            Controls.Add(txtDraws);
            Controls.Add(txtWins);
            Controls.Add(txtMatchesPlayed);
            Controls.Add(txtClubId);
            Controls.Add(lbllosses);
            Controls.Add(lblGoalsconceded);
            Controls.Add(lblGoalsscored);
            Controls.Add(lbldraws);
            Controls.Add(lblwins);
            Controls.Add(lblMatch);
            Controls.Add(lblclub);
            Controls.Add(label1);
            Controls.Add(lblleg);
            ForeColor = SystemColors.ControlText;
            Name = "LeagueTableForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLeagueStandings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblleg;
        private Label lblclub;
        private Label lblMatch;
        private Label lblwins;
        private Label lbldraws;
        private Label lblGoalsscored;
        private Label lblGoalsconceded;
        private Label lbllosses;
        private TextBox txtClubId;
        private TextBox txtMatchesPlayed;
        private TextBox txtWins;
        private TextBox txtDraws;
        private TextBox txtGoalsFor;
        private TextBox txtGoalsAgainst;
        private TextBox txtLosses;
        private DataGridView dgvLeagueStandings;
        private Label label1;
        private Button btnback;
        private Button btnShow;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnUpdate;
    }
}