using GrifLib;
using static GrifLib.Common;
using static zygote.ConfigValues;
using static zygote.StaticRoutines;

namespace zygote
{
    public partial class MainForm : Form
    {
        Grod grod = new();

        public MainForm()
        {
            InitializeComponent();
            SelectTab(buttonStart, groupBoxStart);
        }

        #region Menu Buttons

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

        #endregion

        #region Tab Buttons

        private void buttonStart_Click(object sender, EventArgs e)
        {
            SelectTab(buttonStart, groupBoxStart);
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            SelectTab(buttonRooms, groupBoxRooms);
        }

        private void buttonItems_Click(object sender, EventArgs e)
        {
            SelectTab(buttonItems, groupBoxItems);
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            SelectTab(buttonMessages, groupBoxMessages);
        }

        private void buttonValues_Click(object sender, EventArgs e)
        {
            SelectTab(buttonValues, groupBoxValues);
        }

        private void buttonVocabulary_Click(object sender, EventArgs e)
        {
            SelectTab(buttonVocabulary, groupBoxVocabulary);
        }

        private void buttonCommands_Click(object sender, EventArgs e)
        {
            SelectTab(buttonCommands, groupBoxCommands);
        }

        private void buttonScripts_Click(object sender, EventArgs e)
        {
            SelectTab(buttonScripts, groupBoxScripts);
        }

        private void buttonFunctions_Click(object sender, EventArgs e)
        {
            SelectTab(buttonFunctions, groupBoxFunctions);
        }

        private void buttonSystem_Click(object sender, EventArgs e)
        {
            SelectTab(buttonSystem, groupBoxSystem);
        }

        private void SelectTab(Button button, GroupBox groupBox)
        {
            HideAll();
            groupBox.Visible = true;
            button.BackColor = Color.LightGreen;
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

        #endregion

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

        private void ClearStartTab()
        {
            textBoxStartGameName.Text = "";
            textBoxStartGameTitle.Text = "";
            textBoxStartVersion.Text = "";
            richTextBoxStartIntroduction.Text = "";
            textBoxStartStartingRoom.Text = "";
        }

        private void ClearRoomsTab()
        {
            listBoxRooms.Items.Clear();
            textBoxRoomsShortDesc.Text = "";
            textBoxRoomsLongDesc.Text = "";
            listBoxRoomsExits.Items.Clear();
            richTextBoxRoomsExits.Clear();
            listBoxRoomsOther.Items.Clear();
            richTextBoxRoomsOther.Clear();
        }

        private void ClearItemsTab()
        {
            listBoxItems.Items.Clear();
            textBoxItemsShortDesc.Text = "";
            textBoxItemsLongDesc.Text = "";
            textBoxItemsLocation.Text = "";
            listBoxItemsOther.Items.Clear();
            richTextBoxItemsOther.Clear();
        }

        private void ClearMessagesTab()
        {
            listBoxMessages.Items.Clear();
            richTextBoxMessages.Clear();
        }

        private void ClearValuesTab()
        {
            listBoxValues.Items.Clear();
            richTextBoxValues.Clear();
        }

        private void ClearVocabularyTab()
        {
            listBoxVocabulary.Items.Clear();
            richTextBoxVocabulary.Clear();
        }

        private void ClearCommandsTab()
        {
            listBoxCommands.Items.Clear();
            richTextBoxCommands.Clear();
        }

        private void ClearScriptsTab()
        {
            listBoxScripts.Items.Clear();
            richTextBoxScripts.Clear();
        }

        private void ClearFunctionsTab()
        {
            listBoxFunctions.Items.Clear();
            richTextBoxFunctions.Clear();
        }

        private void ClearSystemTab()
        {
            listBoxSystem.Items.Clear();
            richTextBoxSystem.Clear();
        }

        private void LoadData(Grod grod)
        {
            ClearStartTab();
            ClearRoomsTab();
            ClearItemsTab();
            ClearMessagesTab();
            ClearValuesTab();
            ClearVocabularyTab();
            ClearCommandsTab();
            ClearScriptsTab();
            ClearFunctionsTab();
            ClearSystemTab();

            textBoxStartGameName.Text = grod.Get(SYSTEM_GAMENAME, true) ?? "";
            textBoxStartGameTitle.Text = grod.Get(SYSTEM_GAMETITLE, true) ?? "";
            textBoxStartVersion.Text = grod.Get(SYSTEM_VERSION, true) ?? "";
            richTextBoxStartIntroduction.Clear();
            var script = grod.Get(SYSTEM_INTRO, true);
            if (script != null)
            {
                var items = Dags.ColorizeScript(script);
                foreach (var item in items)
                {
                    richTextBoxStartIntroduction.AppendText(item.Text, GetColorValue(item.ColorValue));
                }
            }
            var playerLocationKey = grod.Get(SYSTEM_PLAYER_LOCATION, true) ?? DEFAULT_PLAYER_LOCATION;
            if (!string.IsNullOrEmpty(playerLocationKey))
            {
                textBoxStartStartingRoom.Text = grod.Get(playerLocationKey, true) ?? "";
            }
            var directionList = grod.Get(SYSTEM_PREFIX_DIRECTION_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_DIRECTION.Split(',');
            FillListBoxFromPrefixUnique(grod, directionList, listBoxStartDirection);

            var roomPrefix = grod.Get(SYSTEM_PREFIX_ROOM_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_ROOM.Split(',');
            if (roomPrefix.Length != 1)
            {
                throw new SystemException("Room can only have one prefix");
            }
            FillListBoxFromPrefixUnique(grod, roomPrefix, listBoxRooms);

            var itemPrefix = grod.Get(SYSTEM_PREFIX_ITEM_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_ITEM.Split(',');
            if (itemPrefix.Length != 1)
            {
                throw new SystemException("Item can only have one prefix");
            }
            FillListBoxFromPrefixUnique(grod, itemPrefix, listBoxItems);

            var messageList = grod.Get(SYSTEM_PREFIX_MESSAGE_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_MESSAGE.Split(',');
            FillListBoxFromPrefixes(grod, messageList, listBoxMessages);

            var valueList = grod.Get(SYSTEM_PREFIX_VALUE_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_VALUE.Split(',');
            FillListBoxFromPrefixes(grod, valueList, listBoxValues);

            var vocabularyList = grod.Get(SYSTEM_PREFIX_VOCABULARY_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_VOCABULARY.Split(',');
            FillListBoxFromPrefixes(grod, vocabularyList, listBoxVocabulary);

            var commandList = grod.Get(SYSTEM_PREFIX_COMMAND_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_COMMAND.Split(',');
            FillListBoxFromPrefixes(grod, commandList, listBoxCommands);

            var scriptList = grod.Get(SYSTEM_PREFIX_SCRIPT_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_SCRIPT.Split(',');
            FillListBoxFromPrefixes(grod, scriptList, listBoxScripts);

            // function keys all start with '@'
            FillListBox(grod, SCRIPT_CHAR.ToString(), listBoxFunctions);

            var systemList = grod.Get(SYSTEM_PREFIX_SYSTEM_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_SYSTEM.Split(',');
            FillListBoxFromPrefixes(grod, systemList, listBoxSystem);

            List<string> extraKeys = [];
            foreach (var key in grod.Keys(true, true))
            {
                if (key.StartsWith(SCRIPT_CHAR)) continue;
                if (!key.Contains('.'))
                {
                    extraKeys.Add(key);
                    continue;
                }
                var prefix = key[..key.IndexOf('.')];
                if (!systemList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !messageList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !valueList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !vocabularyList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !commandList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !scriptList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !directionList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !roomPrefix.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !itemPrefix.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !key.Equals(playerLocationKey, StringComparison.OrdinalIgnoreCase))
                {
                    extraKeys.Add(key);
                }
            }
            AddListBox(extraKeys, listBoxValues);
        }

        private static void FillListBox(Grod grod, string prefix, ListBox listbox)
        {
            var keys = grod.Keys(prefix, true, true) ?? [];
            AddListBox(keys, listbox);
        }

        private void listBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxFunctions, richTextBoxFunctions);
        }

        private void listBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxSystem, richTextBoxSystem);
        }

        private void listBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxScripts, richTextBoxScripts);
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxCommands, richTextBoxCommands);
        }

        private void listBoxVocabulary_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxVocabulary, richTextBoxVocabulary);
        }

        private void listBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxValues, richTextBoxValues);
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSelected(grod, listBoxMessages, richTextBoxMessages);
        }

        private void listBoxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxRoomsShortDesc.Text = "";
            textBoxRoomsLongDesc.Text = "";
            listBoxRoomsExits.Items.Clear();
            richTextBoxRoomsExits.Clear();
            listBoxRoomsOther.Items.Clear();
            richTextBoxRoomsOther.Clear();
            if (listBoxRooms.SelectedIndex < 0) return;

            var roomName = listBoxRooms.Items[listBoxRooms.SelectedIndex].ToString();
            var shortDescKey = DEFAULT_PATTERN_ROOM_SHORTDESC.Replace("{room}", roomName);
            textBoxRoomsShortDesc.Text = grod.Get(shortDescKey, true) ?? "";
            var longDescKey = DEFAULT_PATTERN_ROOM_LONGDESC.Replace("{room}", roomName);
            textBoxRoomsLongDesc.Text = grod.Get(longDescKey, true) ?? "";

            var exitsPrefix = DEFAULT_PATTERN_ROOM_EXIT.Replace("{room}", roomName).Replace("{direction}", "");
            var exitsKeys = grod.Keys(exitsPrefix, true, true);
            foreach (var key in exitsKeys)
            {
                var exitKey = key[exitsPrefix.Length..];
                listBoxRoomsExits.Items.Add(exitKey);
            }

            var otherPrefix = $"{DEFAULT_PREFIX_ROOM}.{roomName}.";
            var otherKeys = grod.Keys(otherPrefix, true, true);
            foreach (var key in otherKeys)
            {
                if (key.Equals(shortDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.Equals(longDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.StartsWith(exitsPrefix, StringComparison.OrdinalIgnoreCase)) continue;
                var otherKey = key[otherPrefix.Length..];
                listBoxRoomsOther.Items.Add(otherKey);
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxItemsShortDesc.Text = "";
            textBoxItemsLongDesc.Text = "";
            textBoxItemsLocation.Text = "";
            listBoxItemsOther.Items.Clear();
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0) return;
            var itemName = listBoxItems.Items[listBoxItems.SelectedIndex].ToString();
            var shortDescKey = DEFAULT_PATTERN_ITEM_SHORTDESC.Replace("{item}", itemName);
            textBoxItemsShortDesc.Text = grod.Get(shortDescKey, true) ?? "";
            var longDescKey = DEFAULT_PATTERN_ITEM_LONGDESC.Replace("{item}", itemName);
            textBoxItemsLongDesc.Text = grod.Get(longDescKey, true) ?? "";
            var locationKey = DEFAULT_PATTERN_ITEM_LOCATION.Replace("{item}", itemName);
            textBoxItemsLocation.Text = grod.Get(locationKey, true) ?? "";
            var otherPrefix = $"{DEFAULT_PREFIX_ITEM}.{itemName}.";
            var otherKeys = grod.Keys(otherPrefix, true, true);
            foreach (var key in otherKeys)
            {
                if (key.Equals(shortDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.Equals(longDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.Equals(locationKey, StringComparison.OrdinalIgnoreCase)) continue;
                var otherKey = key[otherPrefix.Length..];
                listBoxItemsOther.Items.Add(otherKey);
            }
        }

        private void listBoxItemsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0) return;
            if (listBoxItemsOther.SelectedIndex < 0) return;
            var itemName = listBoxItems.Items[listBoxItems.SelectedIndex].ToString();
            var otherPrefix = $"{DEFAULT_PREFIX_ITEM}.{itemName}.";
            ListBoxSelected(grod, listBoxItemsOther, richTextBoxItemsOther, otherPrefix);
        }

        private void listBoxRoomsExits_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxRoomsExits.Clear();
            if (listBoxRooms.SelectedIndex < 0) return;
            if (listBoxRoomsExits.SelectedIndex < 0) return;
            var roomName = listBoxRooms.Items[listBoxRooms.SelectedIndex].ToString();
            var exitsPrefix = DEFAULT_PATTERN_ROOM_EXIT.Replace("{room}", roomName).Replace("{direction}", "");
            ListBoxSelected(grod, listBoxRoomsExits, richTextBoxRoomsExits, exitsPrefix);
        }

        private void listBoxRoomsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxRoomsOther.Clear();
            if (listBoxRooms.SelectedIndex < 0) return;
            if (listBoxRoomsOther.SelectedIndex < 0) return;
            var roomName = listBoxRooms.Items[listBoxRooms.SelectedIndex].ToString();
            var otherPrefix = $"{DEFAULT_PREFIX_ROOM}.{roomName}.";
            ListBoxSelected(grod, listBoxRoomsOther, richTextBoxRoomsOther, otherPrefix);
        }

        private void listBoxStartDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxStartDirections.Clear();
            if (listBoxStartDirection.SelectedIndex < 0) return;
            var directionPrefix = $"{DEFAULT_PREFIX_DIRECTION}.";
            ListBoxSelected(grod, listBoxStartDirection, richTextBoxStartDirections, directionPrefix);
        }
    }
}
