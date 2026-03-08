using GrifLib;

namespace zygote
{
    public partial class MainForm : Form
    {
        Grod grod = new();

        public MainForm()
        {
            InitializeComponent();
            HideAll();
            groupBoxStart.Visible = true;
            buttonStart.BackColor = Color.LightGreen;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxStart.Visible = true;
            buttonStart.BackColor = Color.LightGreen;
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxRooms.Visible = true;
            buttonRooms.BackColor = Color.LightGreen;
        }

        private void buttonItems_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxItems.Visible = true;
            buttonItems.BackColor = Color.LightGreen;
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxMessages.Visible = true;
            buttonMessages.BackColor = Color.LightGreen;
        }

        private void buttonValues_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxValues.Visible = true;
            buttonValues.BackColor = Color.LightGreen;
        }

        private void buttonVocabulary_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxVocabulary.Visible = true;
            buttonVocabulary.BackColor = Color.LightGreen;
        }

        private void buttonCommands_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxCommands.Visible = true;
            buttonCommands.BackColor = Color.LightGreen;
        }

        private void buttonScripts_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxScripts.Visible = true;
            buttonScripts.BackColor = Color.LightGreen;
        }

        private void buttonFunctions_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxFunctions.Visible = true;
            buttonFunctions.BackColor = Color.LightGreen;
        }

        private void buttonSystem_Click(object sender, EventArgs e)
        {
            HideAll();
            groupBoxSystem.Visible = true;
            buttonSystem.BackColor = Color.LightGreen;
        }

        private void HideAll()
        {
            buttonStart.BackColor = SystemColors.Control;
            buttonRooms.BackColor = SystemColors.Control;
            buttonItems.BackColor = SystemColors.Control;
            buttonMessages.BackColor = SystemColors.Control;
            buttonValues.BackColor = SystemColors.Control;
            buttonVocabulary.BackColor = SystemColors.Control;
            buttonCommands.BackColor = SystemColors.Control;
            buttonScripts.BackColor = SystemColors.Control;
            buttonFunctions.BackColor = SystemColors.Control;
            buttonSystem.BackColor = SystemColors.Control;
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
            var dialog = new EnterKeyForm
            {
                IsFunctionKey = true
            };
            dialog.ShowDialog();
            var newKey = dialog.Key;
            if (dialog.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(newKey))
            {
                if (newKey.Contains('('))
                {
                    var keyStart = newKey[..(newKey.IndexOf('(') + 1)];
                    foreach (var key in listBoxFunctions.Items)
                    {
                        if (key != null && key.ToString()!.StartsWith(keyStart, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"Key already exists: {newKey}");
                            return;
                        }
                    }
                }
                else
                {
                    foreach (var key in listBoxFunctions.Items)
                    {
                        if (key != null && key.ToString()!.Equals(newKey, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"Key already exists: {newKey}");
                            return;
                        }
                    }
                }
                listBoxFunctions.Items.Add(newKey);
            }
        }

        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Grif files|*.grif|GrifStack files|*.grifstack"
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                grod = IO.OpenFile(dialog.FileName) ?? new();
                if (grod == null) return;
                LoadData(grod);
            }
        }

        private void LoadData(Grod grod)
        {
            FillListBox(grod, "message.", listBoxMessages);
            FillListBox(grod, "value.", listBoxValues);
            FillListBox(grod, "verb.", listBoxVocabulary);
            FillListBox(grod, "noun.", listBoxVocabulary);
            FillListBox(grod, "adjective.", listBoxVocabulary);
            FillListBox(grod, "preposition.", listBoxVocabulary);
            FillListBox(grod, "command.", listBoxCommands);
            FillListBox(grod, "script.", listBoxScripts);
            FillListBox(grod, "@", listBoxFunctions);
            FillListBox(grod, "system.", listBoxSystem);
        }

        private static void FillListBox(Grod grod, string prefix, ListBox listbox)
        {
            var keys = grod.Keys(prefix, true, true) ?? [];
            foreach (var item in listbox.Items)
            {
                keys.Add((string)item);
            }
            keys.Sort(Grod.CompareKeys);
            listbox.BeginUpdate();
            listbox.Items.Clear();
            foreach (var key in keys)
            {
                listbox.Items.Add(key);
            }
            listbox.EndUpdate();
        }

        private void listBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxFunctions, richTextBoxFunctions);
        }

        private void listBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxSystem, richTextBoxSystem);
        }

        private void listBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxScripts, richTextBoxScripts);
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxCommands, richTextBoxCommands);
        }

        private void listBoxVocabulary_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxVocabulary, richTextBoxVocabulary);
        }

        private void listBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxValues, richTextBoxValues);
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(listBoxMessages, richTextBoxMessages);
        }

        private void ListBoxSelected(ListBox listbox, RichTextBox rtb)
        {
            if (listbox.SelectedIndex < 0)
            {
                rtb.Text = "";
            }
            else
            {
                var key = (string)(listbox?.SelectedItem ?? "");
                rtb.Clear();
                var script = grod.Get(key, true);
                if (script != null)
                {
                    var items = Dags.ColorizeScript(script);
                    foreach (var item in items)
                    {
                        rtb.AppendText(item.Text, GetColorValue(item.ColorValue));
                    }
                }
            }
        }

        private static Color GetColorValue(TextColorEnum textColor)
        {
            return textColor switch
            {
                TextColorEnum.Default => Color.Black,
                TextColorEnum.PunctuationColor => Color.Gray,
                TextColorEnum.TokenColor => Color.Cyan,
                TextColorEnum.IfColor => Color.Blue,
                TextColorEnum.ForColor => Color.Yellow,
                TextColorEnum.QuoteColor => Color.Green,
                TextColorEnum.ParameterColor => Color.Magenta,
                TextColorEnum.CommentColor => Color.LightGray,
                _ => Color.Black,
            };
        }
    }
}
