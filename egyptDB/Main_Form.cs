namespace WinFormsApp12
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClubsForm clubsForm = new ClubsForm();
            clubsForm.ShowDialog();
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();
            playersForm.ShowDialog();
        }

        private void btnLeaguetable_Click(object sender, EventArgs e)
        {
            LeagueTableForm leagueForm = new LeagueTableForm();
            leagueForm.ShowDialog();
        }

        private void btnStadiums_Click(object sender, EventArgs e)
        {
            StadiumsForm stadiumsForm = new StadiumsForm();
            stadiumsForm.ShowDialog();
        }

        private void btnReferees_Click(object sender, EventArgs e)
        {
            RefereesForm refereesForm = new RefereesForm();
            refereesForm.ShowDialog();
        }

        private void btnMatches_Click(object sender, EventArgs e)
        {
            MatchesForm matchesForm = new MatchesForm();
            matchesForm.ShowDialog();
        }
    }
}
