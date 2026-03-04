namespace zygote
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxStart.Visible = true;
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxRooms.Visible = true;
        }

        private void buttonItems_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxItems.Visible = true;
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxMessages.Visible = true;
        }

        private void buttonValues_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxValues.Visible = true;
        }

        private void buttonVocabulary_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxVocabulary.Visible = true;
        }

        private void buttonCommands_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxCommands.Visible = true;
        }

        private void buttonScripts_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxScripts.Visible = true;
        }

        private void buttonFunctions_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxFunctions.Visible = true;
        }

        private void buttonSystem_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxSystem.Visible = true;
        }

        private void HideAll()
        {
            groupBoxStart.Visible = false;
            groupBoxRooms.Visible = false;
            groupBoxItems.Visible = false;
            groupBoxMessages.Visible = false;
            groupBoxValues.Visible = false;
            groupBoxVocabulary.Visible = false;
            groupBoxCommands.Visible = false;
            groupBoxScripts.Visible = false;
            groupBoxFunctions.Visible = false;
            groupBoxSystem.Visible = false;
        }

        private void buttonVersionToday_Click(object sender, EventArgs e)
        {
            textBoxStartVersion.Text = DateTime.Today.ToString("yyyy.MM.dd");
        }

        private void buttonFunctionsAdd_Click(object sender, EventArgs e)
        {
            var dialog = new EnterKeyForm();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(dialog.Key))
            {
                if (listBoxFunctions.Items.Contains(dialog.Key))
                {
                    MessageBox.Show($"Key already exists: {dialog.Key}");
                    return;
                }
                listBoxFunctions.Items.Add(dialog.Key);
            }
        }
    }
}
