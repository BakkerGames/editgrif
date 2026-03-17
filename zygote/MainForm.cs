using GrifLib;

namespace zygote
{
    public partial class MainForm : Form
    {
        Grod grod = new();

        string roomPrefix = "room";
        string itemPrefix = "item";
        string shortDescSuffix = "shortdesc";
        string longDescSuffix = "longdesc";
        string locationSuffix = "location";

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
                Filter = "Grif files|*.grif*"
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
            listBoxRooms.Items.Clear();
            listBoxItems.Items.Clear();
            listBoxValues.Items.Clear();
            listBoxMessages.Items.Clear();
            listBoxVocabulary.Items.Clear();
            listBoxCommands.Items.Clear();
            listBoxScripts.Items.Clear();
            listBoxFunctions.Items.Clear();
            listBoxSystem.Items.Clear();
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
            var valueList = grod.Get("system.prefix.value", true)?.Split(',') ?? ["value"];
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
            roomPrefix = grod.Get("system.prefix.room", true) ?? "room";
            itemPrefix = grod.Get("system.prefix.item", true) ?? "item";
            shortDescSuffix = grod.Get("system.suffix.shortdesc", true) ?? "shortdesc";
            longDescSuffix = grod.Get("system.suffix.longdesc", true) ?? "longdesc";
            FillRooms(grod);
            FillItems(grod);
            FillListBox(grod, "@", listBoxFunctions);
            List<string> extraKeys = [];
            foreach (var key in grod.Keys(true, true))
            {
                if (key.StartsWith('@')) continue;
                if (!key.Contains('.'))
                {
                    extraKeys.Add(key);
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
                        !roomPrefix.Equals(prefix, StringComparison.OrdinalIgnoreCase) &&
                        !itemPrefix.Equals(prefix, StringComparison.OrdinalIgnoreCase))
                    {
                        extraKeys.Add(key);
                    }
                }
            }
            AddListBox(extraKeys, listBoxValues);
        }

        private static void FillListBox(Grod grod, string prefix, ListBox listbox)
        {
            var keys = grod.Keys(prefix, true, true) ?? [];
            AddListBox(keys, listbox);
        }

        private static void AddListBox(List<string> keys, ListBox listbox)
        {
            if (keys.Count == 0) return;
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

        private void FillRooms(Grod grod)
        {
            var keys = grod.Keys($"{roomPrefix}.", true, false);
            keys.Sort(Grod.CompareKeys);
            foreach (var key in keys)
            {
                var pos = key.IndexOf('.', roomPrefix.Length + 1);
                if (pos >= 0)
                {
                    var name = key[(roomPrefix.Length + 1)..pos];
                    if (!listBoxRooms.Items.Contains(name))
                    {
                        listBoxRooms.Items.Add(name);
                    }
                }
            }
        }

        private void FillItems(Grod grod)
        {
            var keys = grod.Keys($"{itemPrefix}.", true, false);
            keys.Sort(Grod.CompareKeys);
            foreach (var key in keys)
            {
                var pos = key.IndexOf('.', itemPrefix.Length + 1);
                if (pos >= 0)
                {
                    var name = key[(itemPrefix.Length + 1)..pos];
                    if (!listBoxItems.Items.Contains(name))
                    {
                        listBoxItems.Items.Add(name);
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

        private void ListBoxSelected(ListBox listbox, RichTextBox rtb, string prefix = "")
        {
            rtb.Clear();
            if (listbox.SelectedIndex < 0) return;
            var key = prefix + (string)(listbox.Items[listbox.SelectedIndex] ?? "");
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
            textBoxRoomsShortDesc.Text = "";
            textBoxRoomsLongDesc.Text = "";
            if (listBoxRooms.SelectedIndex < 0) return;
            textBoxRoomsShortDesc.Text = grod.Get($"{roomPrefix}.{listBoxRooms.SelectedItem}.{shortDescSuffix}", true);
            textBoxRoomsLongDesc.Text = grod.Get($"{roomPrefix}.{listBoxRooms.SelectedItem}.{longDescSuffix}", true);
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxItemsShortDesc.Text = "";
            textBoxItemsLongDesc.Text = "";
            textBoxItemsLocation.Text = "";
            listBoxItemsOther.Items.Clear();
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0)
            {
                return;
            }
            var itemNum = listBoxItems.Items[listBoxItems.SelectedIndex].ToString();
            var keys = grod.Keys($"{itemPrefix}.{itemNum}.", true, true) ?? [];
            var prefixLen = $"{itemPrefix}.{itemNum}.".Length;
            foreach (var key in keys)
            {
                if (key.EndsWith($".{shortDescSuffix}", StringComparison.OrdinalIgnoreCase))
                {
                    textBoxItemsShortDesc.Text = grod.Get(key, true);
                }
                else if (key.EndsWith($".{longDescSuffix}", StringComparison.OrdinalIgnoreCase))
                {
                    textBoxItemsLongDesc.Text = grod.Get(key, true);
                }
                else if (key.EndsWith($".{locationSuffix}", StringComparison.OrdinalIgnoreCase))
                {
                    textBoxItemsLocation.Text = grod.Get(key, true);
                }
                else
                {
                    listBoxItemsOther.Items.Add(key[prefixLen..]);
                }
            }
        }

        private void listBoxItemsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0) return;
            var itemNum = listBoxItems.Items[listBoxItems.SelectedIndex].ToString();
            ListBoxSelected(listBoxItemsOther, richTextBoxItemsOther, $"{itemPrefix}.{itemNum}.");
        }
    }
}
