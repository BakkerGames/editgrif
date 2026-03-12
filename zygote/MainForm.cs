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
            var systemList = grod.Get("system.prefix.system", true)?.Split(',') ?? ["system"];
            foreach (var prefix in systemList)
            {
                FillListBox(grod, $"{prefix}.", listBoxSystem);
            }
            var messageList = grod.Get("system.prefix.message", true)?.Split(',') ?? ["message"];
            foreach (var prefix in messageList)
            {
                FillListBox(grod, $"{prefix}.", listBoxMessages);
            }
            var valueList = grod.Get("system.prefix.zzz", true)?.Split(',') ?? ["value"];
            foreach (var prefix in valueList)
            {
                FillListBox(grod, $"{prefix}.", listBoxValues);
            }
            var verbList = grod.Get("system.prefix.verb", true)?.Split(',') ?? ["verb"];
            foreach (var prefix in verbList)
            {
                FillListBox(grod, $"{prefix}.", listBoxVocabulary);
            }
            var nounList = grod.Get("system.prefix.noun", true)?.Split(',') ?? ["noun"];
            foreach (var prefix in nounList)
            {
                FillListBox(grod, $"{prefix}.", listBoxVocabulary);
            }
            var adjectiveList = grod.Get("system.prefix.adjective", true)?.Split(',') ?? ["adjective"];
            foreach (var prefix in adjectiveList)
            {
                FillListBox(grod, $"{prefix}.", listBoxVocabulary);
            }
            var prepositionList = grod.Get("system.prefix.preposition", true)?.Split(',') ?? ["preposition"];
            foreach (var prefix in prepositionList)
            {
                FillListBox(grod, $"{prefix}.", listBoxVocabulary);
            }
            var articleList = grod.Get("system.prefix.article", true)?.Split(',') ?? ["article"];
            foreach (var prefix in articleList)
            {
                FillListBox(grod, $"{prefix}.", listBoxVocabulary);
            }
            var commandList = grod.Get("system.prefix.command", true)?.Split(',') ?? ["command"];
            foreach (var prefix in commandList)
            {
                FillListBox(grod, $"{prefix}.", listBoxCommands);
            }
            var scriptList = grod.Get("system.prefix.script", true)?.Split(',') ?? ["script", "background"];
            foreach (var prefix in scriptList)
            {
                FillListBox(grod, $"{prefix}.", listBoxScripts);
            }
            var roomList = grod.Get("system.prefix.room", true)?.Split(',') ?? ["room"];
            FillRooms(grod, roomList);
            var itemList = grod.Get("system.prefix.item", true)?.Split(',') ?? ["item"];
            FillItems(grod, itemList);
            FillListBox(grod, "@", listBoxFunctions);
            foreach (var key in grod.Keys(true, true))
            {
                if (key.StartsWith('@')) continue;
                if (!key.Contains('.'))
                {
                    listBoxValues.Items.Add(key);
                }
                else
                {
                    var prefix = key[..key.IndexOf('.')];
                    if (!systemList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !messageList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !valueList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !verbList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !nounList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !adjectiveList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !prepositionList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !articleList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !commandList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !scriptList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !roomList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !itemList.Contains(prefix, StringComparer.OrdinalIgnoreCase))
                    {
                        listBoxValues.Items.Add(key);
                    }
                }
            }
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

        private void FillRooms(Grod grod, string[] roomList)
        {
            foreach (var prefix in roomList)
            {
                var keys = grod.Keys(prefix, true, false);
                keys.Sort(Grod.CompareKeys);
                foreach (var key in keys)
                {
                    var pos = key.IndexOf('.', prefix.Length + 1);
                    if (pos >= 0)
                    {
                        var name = key[(prefix.Length + 1)..pos];
                        if (!listBoxRooms.Items.Contains(name))
                        {
                            listBoxRooms.Items.Add(name);
                        }
                    }
                }
            }
        }

        private void FillItems(Grod grod, string[] itemList)
        {
            foreach (var prefix in itemList)
            {
                var keys = grod.Keys(prefix, true, false);
                keys.Sort(Grod.CompareKeys);
                foreach (var key in keys)
                {
                    var pos = key.IndexOf('.', prefix.Length + 1);
                    if (pos >= 0)
                    {
                        var name = key[(prefix.Length + 1)..pos];
                        if (!listBoxItems.Items.Contains(name))
                        {
                            listBoxItems.Items.Add(name);
                        }
                    }
                }
            }
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
                TextColorEnum.PunctuationColor => Color.LightGray,
                TextColorEnum.TokenColor => Color.Cyan,
                TextColorEnum.IfColor => Color.Blue,
                TextColorEnum.ForColor => Color.Orange,
                TextColorEnum.QuoteColor => Color.ForestGreen,
                TextColorEnum.ParameterColor => Color.Magenta,
                TextColorEnum.CommentColor => Color.ForestGreen,
                _ => Color.Black,
            };
        }

        private void listBoxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRooms.SelectedIndex < 0) return;
            textBoxRoomsShortDesc.Text = grod.Get($"room.{listBoxRooms.SelectedItem}.shortdesc", true);
            textBoxRoomsLongDesc.Text = grod.Get($"room.{listBoxRooms.SelectedItem}.longdesc", true);
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0) return;
            textBoxItemsShortDesc.Text = grod.Get($"item.{listBoxItems.SelectedItem}.shortdesc", true);
            textBoxItemsLongDesc.Text = grod.Get($"item.{listBoxItems.SelectedItem}.longdesc", true);
        }
    }
}
