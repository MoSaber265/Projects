namespace WinFormsApp12
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            btnClubs = new Button();
            btnStadiums = new Button();
            btnPlayers = new Button();
            btnReferees = new Button();
            btnLeaguetable = new Button();
            btnMatches = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI Symbol", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(105, 30);
            button1.Name = "button1";
            button1.Size = new Size(593, 73);
            button1.TabIndex = 0;
            button1.Text = "Main Form";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnClubs
            // 
            btnClubs.Location = new Point(0, 0);
            btnClubs.Name = "btnClubs";
            btnClubs.Size = new Size(75, 23);
            btnClubs.TabIndex = 7;
            // 
            // btnStadiums
            // 
            btnStadiums.Location = new Point(511, 254);
            btnStadiums.Name = "btnStadiums";
            btnStadiums.Size = new Size(187, 67);
            btnStadiums.TabIndex = 2;
            btnStadiums.Text = "Stadiums";
            btnStadiums.UseVisualStyleBackColor = true;
            btnStadiums.Click += btnStadiums_Click;
            // 
            // btnPlayers
            // 
            btnPlayers.Location = new Point(511, 161);
            btnPlayers.Name = "btnPlayers";
            btnPlayers.Size = new Size(187, 67);
            btnPlayers.TabIndex = 3;
            btnPlayers.Text = "Players";
            btnPlayers.UseVisualStyleBackColor = true;
            btnPlayers.Click += btnPlayers_Click;
            // 
            // btnReferees
            // 
            btnReferees.Location = new Point(105, 355);
            btnReferees.Name = "btnReferees";
            btnReferees.Size = new Size(187, 67);
            btnReferees.TabIndex = 4;
            btnReferees.Text = "Referees";
            btnReferees.UseVisualStyleBackColor = true;
            btnReferees.Click += btnReferees_Click;
            // 
            // btnLeaguetable
            // 
            btnLeaguetable.Location = new Point(105, 254);
            btnLeaguetable.Name = "btnLeaguetable";
            btnLeaguetable.Size = new Size(187, 67);
            btnLeaguetable.TabIndex = 5;
            btnLeaguetable.Text = "League";
            btnLeaguetable.UseVisualStyleBackColor = true;
            btnLeaguetable.Click += btnLeaguetable_Click;
            // 
            // btnMatches
            // 
            btnMatches.Location = new Point(511, 355);
            btnMatches.Name = "btnMatches";
            btnMatches.Size = new Size(187, 67);
            btnMatches.TabIndex = 6;
            btnMatches.Text = "Matches";
            btnMatches.UseVisualStyleBackColor = true;
            btnMatches.Click += btnMatches_Click;
            // 
            // button2
            // 
            button2.Location = new Point(105, 161);
            button2.Name = "button2";
            button2.Size = new Size(187, 67);
            button2.TabIndex = 8;
            button2.Text = "Clubs";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(button2);
            Controls.Add(btnMatches);
            Controls.Add(btnLeaguetable);
            Controls.Add(btnReferees);
            Controls.Add(btnPlayers);
            Controls.Add(btnStadiums);
            Controls.Add(btnClubs);
            Controls.Add(button1);
            Name = "Main_Form";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnClubs;
        private Button btnStadiums;
        private Button btnPlayers;
        private Button btnReferees;
        private Button btnLeaguetable;
        private Button btnMatches;
        private Button button2;
    }
}
