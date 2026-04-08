using GrifLib;
using static editgrif.ConfigValues;
using static editgrif.CurrentValues;
using static editgrif.StaticRoutines;
using static GrifLib.Common;

namespace editgrif
{
    public partial class MainForm : Form
    {
        Grod grod = new();
        Grod overlay = new();
        string basePath = "";
        bool loading = false;

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
            if (result != DialogResult.OK) return;
            var filename = dialog.FileName;
            basePath = Path.GetDirectoryName(filename) ?? "";
            filename = Path.GetFileName(filename);
            ClearData();
            comboBoxFileNames.SelectedIndex = -1;
            comboBoxFileNames.Items.Clear();
            if (Path.GetExtension(filename).Equals(STACK_EXTENSION, StringComparison.OrdinalIgnoreCase))
            {
                var lines = File.ReadAllLines(Path.Combine(basePath, filename));
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        comboBoxFileNames.Items.Add(line);
                    }
                }
            }
            else
            {
                comboBoxFileNames.Items.Add(filename);
                comboBoxFileNames.SelectedIndex = 0;
            }
        }

        private void buttonFileSave_Click(object sender, EventArgs e)
        {
            // TODO ### temp file for now
            IO.WriteGrif("C:\\Temp\\testgrod.grif", grod.Parent!.Items(true, true), false);
            IO.WriteGrif("C:\\Temp\\testgrod.grifwip", overlay.Items(false, true), false);
            IO.WriteGrif("C:\\Temp\\testgrod.json", overlay.Items(false, true), true);
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
            richTextBoxStartIntroduction.Clear();
            textBoxStartStartingRoom.Text = "";
            listBoxStartDirection.Items.Clear();
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

        private void ClearData()
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
        }

        private void LoadData(Grod grod)
        {
            var saveLoading = loading;

            ClearData();

            playerLocationKey = grod.Get(SYSTEM_PLAYER_LOCATION, true) ?? DEFAULT_PLAYER_LOCATION_KEY;
            directionPrefix = grod.Get(SYSTEM_PREFIX_DIRECTION_KEY, true) ?? DEFAULT_PREFIX_DIRECTION;

            roomsPrefix = grod.Get(SYSTEM_PREFIX_ROOM_KEY, true) ?? DEFAULT_PREFIX_ROOM;
            roomsShortDescPattern = grod.Get(SYSTEM_PREFIX_ROOM_SHORTDESC_KEY, true) ?? DEFAULT_PATTERN_ROOM_SHORTDESC;
            roomsLongDescPattern = grod.Get(SYSTEM_PREFIX_ROOM_LONGDESC_KEY, true) ?? DEFAULT_PATTERN_ROOM_LONGDESC;
            roomsExitsPattern = grod.Get(SYSTEM_PREFIX_ROOM_EXIT_KEY, true) ?? DEFAULT_PATTERN_ROOM_EXIT;

            itemsPrefix = grod.Get(SYSTEM_PREFIX_ITEM_KEY, true) ?? DEFAULT_PREFIX_ITEM;
            itemsShortDescPattern = grod.Get(SYSTEM_PREFIX_ITEM_SHORTDESC_KEY, true) ?? DEFAULT_PATTERN_ITEM_SHORTDESC;
            itemsLongDescPattern = grod.Get(SYSTEM_PREFIX_ITEM_LONGDESC_KEY, true) ?? DEFAULT_PATTERN_ITEM_LONGDESC;
            itemsLocationPattern = grod.Get(SYSTEM_PREFIX_ITEM_LOCATION_KEY, true) ?? DEFAULT_PATTERN_ITEM_LOCATION;

            messagePrefixes = grod.Get(SYSTEM_PREFIX_MESSAGE_KEY, true) ?? DEFAULT_PREFIX_MESSAGE;
            valuesPrefixes = grod.Get(SYSTEM_PREFIX_VALUE_KEY, true) ?? DEFAULT_PREFIX_VALUE;
            vocabularyPrefixes = grod.Get(SYSTEM_PREFIX_VOCABULARY_KEY, true) ?? DEFAULT_PREFIX_VOCABULARY;
            commandsPrefix = grod.Get(SYSTEM_PREFIX_COMMAND_KEY, true) ?? DEFAULT_PREFIX_COMMAND;
            scriptsPrefixes = grod.Get(SYSTEM_PREFIX_SCRIPT_KEY, true) ?? DEFAULT_PREFIX_SCRIPT;
            systemPrefixes = grod.Get(SYSTEM_PREFIX_SYSTEM_KEY, true) ?? DEFAULT_PREFIX_SYSTEM;

            if (roomsPrefix.Split(',').Length > 1)
            {
                throw new SystemException("Room can only have one prefix");
            }
            if (itemsPrefix.Split(',').Length > 1)
            {
                throw new SystemException("Item can only have one prefix");
            }
            if (directionPrefix.Split(',').Length > 1)
            {
                throw new SystemException("Direction can only have one prefix");
            }
            if (commandsPrefix.Split(',').Length > 1)
            {
                throw new SystemException("Command can only have one prefix");
            }

            textBoxStartGameName.Text = grod.Get(SYSTEM_GAMENAME, true) ?? "";
            textBoxStartGameTitle.Text = grod.Get(SYSTEM_GAMETITLE, true) ?? "";
            textBoxStartVersion.Text = grod.Get(SYSTEM_VERSION, true) ?? "";
            var script = grod.Get(SYSTEM_INTRO, true);
            FillRichTextBox(richTextBoxStartIntroduction, script);
            textBoxStartStartingRoom.Text = grod.Get(playerLocationKey, true) ?? "";
            FillListBoxFromPrefixUnique(grod, [directionPrefix], listBoxStartDirection);

            FillListBoxFromPrefixUnique(grod, [roomsPrefix], listBoxRooms);

            FillListBoxFromPrefixUnique(grod, [itemsPrefix], listBoxItems);

            var messageList = messagePrefixes.Split(',');
            FillListBoxFromPrefixes(grod, messageList, listBoxMessages);

            var valueList = valuesPrefixes.Split(',');
            FillListBoxFromPrefixes(grod, valueList, listBoxValues);

            var vocabularyList = vocabularyPrefixes.Split(',');
            FillListBoxFromPrefixes(grod, vocabularyList, listBoxVocabulary);

            FillListBoxFromPrefixes(grod, [commandsPrefix], listBoxCommands);

            var scriptList = scriptsPrefixes.Split(',');
            FillListBoxFromPrefixes(grod, scriptList, listBoxScripts);

            // function keys all start with '@'
            FillListBox(grod, SCRIPT_CHAR.ToString(), listBoxFunctions);

            var systemList = systemPrefixes.Split(',');
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
                    !commandsPrefix.Equals(prefix, StringComparison.OrdinalIgnoreCase) &&
                    !scriptList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                    !directionPrefix.Equals(prefix, StringComparison.OrdinalIgnoreCase) &&
                    !roomsPrefix.Equals(prefix, StringComparison.OrdinalIgnoreCase) &&
                    !itemsPrefix.Equals(prefix, StringComparison.OrdinalIgnoreCase) &&
                    !key.Equals(playerLocationKey, StringComparison.OrdinalIgnoreCase))
                {
                    extraKeys.Add(key);
                }
            }
            AddListBox(extraKeys, listBoxValues);

            loading = saveLoading;
        }

        private void listBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentFunctionsValue = ListBoxSelected(grod, listBoxFunctions, richTextBoxFunctions);
            loading = saveLoading;
        }

        private void listBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentSystemKey = ListBoxSelected(grod, listBoxSystem, richTextBoxSystem);
            loading = saveLoading;
        }

        private void listBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentScriptsKey = ListBoxSelected(grod, listBoxScripts, richTextBoxScripts);
            loading = saveLoading;
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentCommandsKey = ListBoxSelected(grod, listBoxCommands, richTextBoxCommands);
            loading = saveLoading;
        }

        private void listBoxVocabulary_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentVocabularyKey = ListBoxSelected(grod, listBoxVocabulary, richTextBoxVocabulary);
            loading = saveLoading;
        }

        private void listBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentValuesKey = ListBoxSelected(grod, listBoxValues, richTextBoxValues);
            loading = saveLoading;
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            currentMessagesKey = ListBoxSelected(grod, listBoxMessages, richTextBoxMessages);
            loading = saveLoading;
        }

        private void listBoxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;

            currentRoomName = null;
            textBoxRoomsShortDesc.Text = "";
            textBoxRoomsLongDesc.Text = "";
            listBoxRoomsExits.Items.Clear();
            richTextBoxRoomsExits.Clear();
            listBoxRoomsOther.Items.Clear();
            richTextBoxRoomsOther.Clear();
            if (listBoxRooms.SelectedIndex < 0) return;

            currentRoomName = listBoxRooms.Items[listBoxRooms.SelectedIndex].ToString();
            currentRoomShortDescKey = roomsShortDescPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName);
            currentRoomLongDescKey = roomsLongDescPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName);

            textBoxRoomsShortDesc.Text = grod.Get(currentRoomShortDescKey, true) ?? "";
            textBoxRoomsLongDesc.Text = grod.Get(currentRoomLongDescKey, true) ?? "";

            var exitsPrefix = roomsExitsPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName)
                .Replace("{direction}", "");
            var exitsKeys = grod.Keys(exitsPrefix, true, true);
            foreach (var key in exitsKeys)
            {
                var exitKey = key[exitsPrefix.Length..];
                listBoxRoomsExits.Items.Add(exitKey);
            }

            var otherPrefix = $"{roomsPrefix}.{currentRoomName}.";
            var otherKeys = grod.Keys(otherPrefix, true, true);
            foreach (var key in otherKeys)
            {
                if (key.Equals(currentRoomShortDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.Equals(currentRoomLongDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.StartsWith(exitsPrefix, StringComparison.OrdinalIgnoreCase)) continue;
                var otherKey = key[otherPrefix.Length..];
                listBoxRoomsOther.Items.Add(otherKey);
            }

            loading = saveLoading;
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;

            currentItemName = null;
            textBoxItemsShortDesc.Text = "";
            textBoxItemsLongDesc.Text = "";
            textBoxItemsLocation.Text = "";
            listBoxItemsOther.Items.Clear();
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0) return;

            currentItemName = listBoxItems.Items[listBoxItems.SelectedIndex].ToString();
            currentItemShortDescKey = itemsShortDescPattern!
                .Replace("{itemprefix}", itemsPrefix)
                .Replace("{item}", currentItemName);
            currentItemLongDescKey = itemsLongDescPattern!
                .Replace("{itemprefix}", itemsPrefix)
                .Replace("{item}", currentItemName);
            currentItemLocationKey = itemsLocationPattern!
                .Replace("{itemprefix}", itemsPrefix)
                .Replace("{item}", currentItemName);

            textBoxItemsShortDesc.Text = grod.Get(currentItemShortDescKey, true) ?? "";
            textBoxItemsLongDesc.Text = grod.Get(currentItemLongDescKey, true) ?? "";
            textBoxItemsLocation.Text = grod.Get(currentItemLocationKey, true) ?? "";

            var otherPrefix = $"{itemsPrefix}.{currentItemName}.";
            var otherKeys = grod.Keys(otherPrefix, true, true);
            foreach (var key in otherKeys)
            {
                if (key.Equals(currentItemShortDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.Equals(currentItemLongDescKey, StringComparison.OrdinalIgnoreCase)) continue;
                if (key.Equals(currentItemLocationKey, StringComparison.OrdinalIgnoreCase)) continue;
                var otherKey = key[otherPrefix.Length..];
                listBoxItemsOther.Items.Add(otherKey);
            }

            loading = saveLoading;
        }

        private void listBoxItemsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var otherPrefix = $"{itemsPrefix}.{currentItemName}.";
            currentItemsOtherKey = ListBoxSelected(grod, listBoxItemsOther, richTextBoxItemsOther, otherPrefix);
            loading = saveLoading;
        }

        private void listBoxRoomsExits_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var exitsPrefix = roomsExitsPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName)
                .Replace("{direction}", "");
            currentRoomsExitsKey = ListBoxSelected(grod, listBoxRoomsExits, richTextBoxRoomsExits, exitsPrefix);
            loading = saveLoading;
        }

        private void listBoxRoomsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var roomsOtherPrefix = $"{roomsPrefix}.{currentRoomName}.";
            currentRoomsOtherKey = ListBoxSelected(grod, listBoxRoomsOther, richTextBoxRoomsOther, roomsOtherPrefix);
            loading = saveLoading;
        }

        private void listBoxStartDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var directionsPrefix = $"{directionPrefix}.";
            currentDirectionKey = ListBoxSelected(grod, listBoxStartDirection, richTextBoxStartDirections, directionsPrefix);
            loading = saveLoading;
        }

        private void comboBoxFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (comboBoxFileNames.SelectedIndex < 0) return;
            var filename = comboBoxFileNames.SelectedItem?.ToString() ?? "";
            grod = IO.OpenFile(Path.Combine(basePath, filename)) ?? new();
            if (grod == null) return;
            LoadData(grod);
            overlay = new()
            {
                Parent = grod
            };
            grod = overlay;
            loading = saveLoading;
        }


        private void textBoxStartGameName_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_GAMENAME, textBoxStartGameName.Text);
        }

        private void textBoxStartGameTitle_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_GAMETITLE, textBoxStartGameTitle.Text);
        }

        private void textBoxStartVersion_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_VERSION, textBoxStartVersion.Text);
        }

        private void richTextBoxStartIntroduction_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_INTRO, richTextBoxStartIntroduction.Text);
        }

        private void textBoxStartStartingRoom_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (playerLocationKey == null) return;
            overlay.Set(playerLocationKey, textBoxStartStartingRoom.Text);
        }

        private void richTextBoxStartDirections_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentDirectionKey == null) return;
            overlay.Set(currentDirectionKey, richTextBoxStartDirections.Text);
        }

        private void textBoxRoomsShortDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentRoomShortDescKey == null) return;
            overlay.Set(currentRoomShortDescKey, textBoxRoomsShortDesc.Text);
        }

        private void textBoxRoomsLongDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentRoomLongDescKey == null) return;
            overlay.Set(currentRoomLongDescKey, textBoxRoomsLongDesc.Text);
        }

        private void richTextBoxRoomsExits_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentRoomsExitsKey == null) return;
            overlay.Set(currentRoomsExitsKey, richTextBoxRoomsExits.Text);
        }

        private void richTextBoxRoomsOther_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentRoomsOtherKey == null) return;
            overlay.Set(currentRoomsOtherKey, richTextBoxRoomsOther.Text);
        }

        private void richTextBoxFunctions_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentFunctionsValue == null) return;
            overlay.Set(currentFunctionsValue, richTextBoxFunctions.Text);
        }

        private void richTextBoxSystem_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentSystemKey == null) return;
            overlay.Set(currentSystemKey, richTextBoxSystem.Text);
        }

        private void richTextBoxScripts_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentScriptsKey == null) return;
            overlay.Set(currentScriptsKey, richTextBoxScripts.Text);
        }

        private void richTextBoxCommands_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentCommandsKey == null) return;
            overlay.Set(currentCommandsKey, richTextBoxCommands.Text);
        }

        private void richTextBoxVocabulary_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentVocabularyKey == null) return;
            overlay.Set(currentVocabularyKey, richTextBoxVocabulary.Text);
        }

        private void richTextBoxValues_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentValuesKey == null) return;
            overlay.Set(currentValuesKey, richTextBoxValues.Text);
        }

        private void richTextBoxMessages_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentMessagesKey == null) return;
            overlay.Set(currentMessagesKey, richTextBoxMessages.Text);
        }

        private void textBoxItemsShortDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemShortDescKey == null) return;
            overlay.Set(currentItemShortDescKey, textBoxItemsShortDesc.Text);
        }

        private void textBoxItemsLongDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemLongDescKey == null) return;
            overlay.Set(currentItemLongDescKey, textBoxItemsLongDesc.Text);
        }

        private void textBoxItemsLocation_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemLocationKey == null) return;
            overlay.Set(currentItemLocationKey, textBoxItemsLocation.Text);
        }

        private void richTextBoxItemsOther_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemsOtherKey == null) return;
            overlay.Set(currentItemsOtherKey, richTextBoxItemsOther.Text);
        }
    }
}
