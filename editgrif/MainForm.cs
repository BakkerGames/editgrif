using GrifLib;
using System.Globalization;
using static editgrif.ConfigValues;
using static editgrif.CurrentValues;
using static editgrif.StaticRoutines;
using static GrifLib.Common;

namespace editgrif
{
    public partial class MainForm : Form
    {
        Grod baseGrod = new();
        Grod overlay = new();
        Grod helpGrod = new();
        string basePath = "";
        string? grodFilename = null;
        string? overlayFilename = null;
        bool loading = false;

        public MainForm()
        {
            InitializeComponent();
            FillHelpTab();
            SelectTab(buttonStart, groupBoxStart);
        }

        private void FillHelpTab()
        {
            helpGrod = Dags.Help() ?? new();
            var helpKeysList = helpGrod.Keys(true, true);
            AddListBox(listBoxHelp, helpKeysList);
        }

        #region Menu Buttons

        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = $"Grif files|*{DATA_EXTENSION}|Grif Stack|*{STACK_EXTENSION}"
            };
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            var filename = dialog.FileName;
            basePath = Path.GetDirectoryName(filename) ?? "";
            filename = Path.GetFileName(filename);
            ClearData();
            buttonFileSave.Enabled = true;
            comboBoxFileNames.SelectedIndex = -1;
            comboBoxFileNames.Items.Clear();
            if (Path.GetExtension(filename).Equals(STACK_EXTENSION, OIC))
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
            if (comboBoxFileNames.SelectedIndex < 0) return;
            string? filename = comboBoxFileNames.Items[comboBoxFileNames.SelectedIndex]!.ToString();
            if (filename == null) return;
            if (overlay.Count(false) > 0)
            {
                baseGrod.AddItems(overlay.Items(false, false));
                overlay.Clear(false);
            }
            IO.WriteGrif(Path.Combine(basePath, filename), baseGrod.Items(true, true), false);
            if (!string.IsNullOrEmpty(overlayFilename))
            {
                File.Delete(overlayFilename);
                overlayFilename = null;
            }
            MessageBox.Show($"File saved: {filename}");
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
            buttonHelp.BackColor = SystemColors.Control;
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
            groupBoxHelp.Visible = false;
        }

        #endregion

        private void buttonVersionToday_Click(object sender, EventArgs e)
        {
            richTextBoxStartVersion.Text = DateTime.Now.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
        }

        private void buttonFunctionsAdd_Click(object sender, EventArgs e)
        {
            var dialog = new EnterKeyForm
            {
                IsFunctionKey = true,
                Prefix = SCRIPT_CHAR.ToString()
            };
            dialog.ShowDialog();
            var newKey = dialog.Key;
            if (dialog.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(newKey))
            {
                // check for same function with different parameters
                if (newKey.Contains('('))
                {
                    var keyStart = SCRIPT_CHAR + newKey[..(newKey.IndexOf('(') + 1)];
                    foreach (var key in listBoxFunctions.Items)
                    {
                        if (key != null && key.ToString()!.StartsWith(keyStart, OIC))
                        {
                            MessageBox.Show($"Key already exists with different parameters: {key}");
                            return;
                        }
                    }
                }
                AddListBox(listBoxFunctions, [SCRIPT_CHAR + newKey]);
                listBoxFunctions.SelectedItem = SCRIPT_CHAR + newKey;
                richTextBoxFunctions.Focus();
            }
        }

        private void ClearStartTab()
        {
            richTextBoxStartGameName.Clear();
            richTextBoxStartGameTitle.Clear();
            richTextBoxStartVersion.Clear();
            richTextBoxStartIntroduction.Clear();
            richTextBoxStartStartingRoom.Clear();
            listBoxStartDirection.Items.Clear();
        }

        private void ClearRoomsTab()
        {
            listBoxRooms.Items.Clear();
            richTextBoxRoomsShortDesc.Clear();
            richTextBoxRoomsLongDesc.Clear();
            listBoxRoomsExits.Items.Clear();
            richTextBoxRoomsExits.Clear();
            listBoxRoomsOther.Items.Clear();
            richTextBoxRoomsOther.Clear();
            buttonRoomsExitsAdd.Enabled = false;
            buttonRoomsOtherAdd.Enabled = false;
        }

        private void ClearItemsTab()
        {
            listBoxItems.Items.Clear();
            richTextBoxItemsShortDesc.Clear();
            richTextBoxItemsLongDesc.Clear();
            richTextBoxItemsLocation.Clear();
            listBoxItemsOther.Items.Clear();
            richTextBoxItemsOther.Clear();
            buttonItemsOtherAdd.Enabled = false;
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

            FillRichTextBox(richTextBoxStartGameName, grod.Get(SYSTEM_GAMENAME, true));
            FillRichTextBox(richTextBoxStartGameTitle, grod.Get(SYSTEM_GAMETITLE, true));
            FillRichTextBox(richTextBoxStartVersion, grod.Get(SYSTEM_VERSION, true));
            FillRichTextBox(richTextBoxStartIntroduction, grod.Get(SYSTEM_INTRO, true));
            FillRichTextBox(richTextBoxStartStartingRoom, grod.Get(playerLocationKey, true));
            FillListBoxFromPrefixUnique(overlay, [directionPrefix], listBoxStartDirection);

            FillListBoxFromPrefixUnique(overlay, [roomsPrefix], listBoxRooms);

            FillListBoxFromPrefixUnique(overlay, [itemsPrefix], listBoxItems);

            var messageList = messagePrefixes.Split(',');
            FillListBoxFromPrefixes(overlay, messageList, listBoxMessages);

            var valueList = valuesPrefixes.Split(',');
            FillListBoxFromPrefixes(overlay, valueList, listBoxValues);

            var vocabularyList = vocabularyPrefixes.Split(',');
            FillListBoxFromPrefixes(overlay, vocabularyList, listBoxVocabulary);

            FillListBoxFromPrefixes(overlay, [commandsPrefix], listBoxCommands);

            var scriptList = scriptsPrefixes.Split(',');
            FillListBoxFromPrefixes(overlay, scriptList, listBoxScripts);

            // function keys all start with '@'
            FillListBox(overlay, SCRIPT_CHAR.ToString(), listBoxFunctions);

            var systemList = systemPrefixes.Split(',');
            var systemKeyList = new List<string>();
            foreach (var prefix in systemList)
            {
                var keys = grod.Keys($"{prefix}.", true, false);
                foreach (var key in keys)
                {
                    if (key.Equals(SYSTEM_GAMENAME, OIC)
                        || key.Equals(SYSTEM_GAMETITLE, OIC)
                        || key.Equals(SYSTEM_VERSION, OIC)
                        || key.Equals(SYSTEM_INTRO, OIC))
                    {
                        continue;
                    }
                    systemKeyList.Add(key);
                }
            }
            AddListBox(listBoxSystem, systemKeyList);

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
                if (!ListContains(systemList, prefix) &&
                    !ListContains(messageList, prefix) &&
                    !ListContains(valueList, prefix) &&
                    !ListContains(vocabularyList, prefix) &&
                    !commandsPrefix.Equals(prefix, OIC) &&
                    !ListContains(scriptList, prefix) &&
                    !directionPrefix.Equals(prefix, OIC) &&
                    !roomsPrefix.Equals(prefix, OIC) &&
                    !itemsPrefix.Equals(prefix, OIC) &&
                    !key.Equals(playerLocationKey, OIC))
                {
                    extraKeys.Add(key);
                }
            }
            AddListBox(listBoxValues, extraKeys);

            loading = saveLoading;
        }

        private void listBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxFunctions.SelectedIndex < 0)
            {
                currentFunctionsKey = null;
                richTextBoxFunctions.Clear();
                buttonFunctionsRename.Enabled = false;
                buttonFunctionsDelete.Enabled = false;
            }
            else
            {
                currentFunctionsKey = ListBoxSelected(overlay, listBoxFunctions, richTextBoxFunctions);
                buttonFunctionsRename.Enabled = true;
                buttonFunctionsDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxSystem.SelectedIndex < 0)
            {
                currentSystemKey = null;
                richTextBoxSystem.Clear();
                buttonSystemRename.Enabled = false;
                buttonSystemDelete.Enabled = false;
            }
            else
            {
                currentSystemKey = ListBoxSelected(overlay, listBoxSystem, richTextBoxSystem);
                buttonSystemRename.Enabled = true;
                buttonSystemDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxScripts.SelectedIndex < 0)
            {
                currentScriptsKey = null;
                richTextBoxScripts.Clear();
                buttonScriptsRename.Enabled = false;
                buttonScriptsDelete.Enabled = false;
            }
            else
            {
                currentScriptsKey = ListBoxSelected(overlay, listBoxScripts, richTextBoxScripts);
                buttonScriptsRename.Enabled = true;
                buttonScriptsDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxCommands.SelectedIndex < 0)
            {
                currentCommandsKey = null;
                richTextBoxCommands.Clear();
                buttonCommandsRename.Enabled = false;
                buttonCommandsDelete.Enabled = false;
            }
            else
            {
                currentCommandsKey = ListBoxSelected(overlay, listBoxCommands, richTextBoxCommands);
                buttonCommandsRename.Enabled = true;
                buttonCommandsDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxVocabulary_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxVocabulary.SelectedIndex < 0)
            {
                currentVocabularyKey = null;
                richTextBoxVocabulary.Clear();
                buttonVocabularyRename.Enabled = false;
                buttonVocabularyDelete.Enabled = false;
            }
            else
            {
                currentVocabularyKey = ListBoxSelected(overlay, listBoxVocabulary, richTextBoxVocabulary);
                buttonVocabularyRename.Enabled = true;
                buttonVocabularyDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxValues.SelectedIndex < 0)
            {
                currentValuesKey = null;
                richTextBoxValues.Clear();
                buttonValuesRename.Enabled = false;
                buttonValuesDelete.Enabled = false;
            }
            else
            {
                currentValuesKey = ListBoxSelected(overlay, listBoxValues, richTextBoxValues);
                buttonValuesRename.Enabled = true;
                buttonValuesDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxMessages.SelectedIndex < 0)
            {
                currentMessagesKey = null;
                richTextBoxMessages.Clear();
                buttonMessagesRename.Enabled = false;
                buttonMessagesDelete.Enabled = false;
            }
            else
            {
                currentMessagesKey = ListBoxSelected(overlay, listBoxMessages, richTextBoxMessages);
                buttonMessagesRename.Enabled = true;
                buttonMessagesDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;

            currentRoomName = null;
            richTextBoxRoomsShortDesc.Clear();
            richTextBoxRoomsLongDesc.Clear();
            listBoxRoomsExits.Items.Clear();
            richTextBoxRoomsExits.Clear();
            listBoxRoomsOther.Items.Clear();
            richTextBoxRoomsOther.Clear();
            if (listBoxRooms.SelectedIndex < 0)
            {
                buttonRoomsRename.Enabled = false;
                buttonRoomsDelete.Enabled = false;
                buttonRoomsExitsAdd.Enabled = false;
                buttonRoomsOtherAdd.Enabled = false;
                return;
            }

            currentRoomName = listBoxRooms.Items[listBoxRooms.SelectedIndex].ToString();
            currentRoomShortDescKey = roomsShortDescPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName);
            currentRoomLongDescKey = roomsLongDescPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName);

            FillRichTextBox(richTextBoxRoomsShortDesc, overlay.Get(currentRoomShortDescKey, true));
            FillRichTextBox(richTextBoxRoomsLongDesc, overlay.Get(currentRoomLongDescKey, true));

            var exitsPrefix = roomsExitsPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName)
                .Replace("{direction}", "");
            var exitsKeys = overlay.Keys(exitsPrefix, true, true);
            foreach (var key in exitsKeys)
            {
                var exitKey = key[exitsPrefix.Length..];
                listBoxRoomsExits.Items.Add(exitKey);
            }

            var otherPrefix = $"{roomsPrefix}.{currentRoomName}.";
            var otherKeys = overlay.Keys(otherPrefix, true, true);
            foreach (var key in otherKeys)
            {
                if (key.Equals(currentRoomShortDescKey, OIC)) continue;
                if (key.Equals(currentRoomLongDescKey, OIC)) continue;
                if (key.StartsWith(exitsPrefix, OIC)) continue;
                var otherKey = key[otherPrefix.Length..];
                listBoxRoomsOther.Items.Add(otherKey);
            }

            buttonRoomsRename.Enabled = true;
            buttonRoomsDelete.Enabled = true;
            buttonRoomsExitsAdd.Enabled = true;
            buttonRoomsOtherAdd.Enabled = true;

            loading = saveLoading;
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;

            currentItemName = null;
            richTextBoxItemsShortDesc.Clear();
            richTextBoxItemsLongDesc.Clear();
            richTextBoxItemsLocation.Clear();
            listBoxItemsOther.Items.Clear();
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0)
            {
                buttonItemsRename.Enabled = false;
                buttonItemsDelete.Enabled = false;
                buttonItemsOtherAdd.Enabled = false;
                return;
            }

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

            FillRichTextBox(richTextBoxItemsShortDesc, overlay.Get(currentItemShortDescKey, true));
            FillRichTextBox(richTextBoxItemsLongDesc, overlay.Get(currentItemLongDescKey, true));
            FillRichTextBox(richTextBoxItemsLocation, overlay.Get(currentItemLocationKey, true));

            var otherPrefix = $"{itemsPrefix}.{currentItemName}.";
            var otherKeys = overlay.Keys(otherPrefix, true, true);
            foreach (var key in otherKeys)
            {
                if (key.Equals(currentItemShortDescKey, OIC)) continue;
                if (key.Equals(currentItemLongDescKey, OIC)) continue;
                if (key.Equals(currentItemLocationKey, OIC)) continue;
                var otherKey = key[otherPrefix.Length..];
                listBoxItemsOther.Items.Add(otherKey);
            }

            buttonItemsRename.Enabled = true;
            buttonItemsDelete.Enabled = true;
            buttonItemsOtherAdd.Enabled = true;

            loading = saveLoading;
        }

        private void listBoxItemsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var otherPrefix = $"{itemsPrefix}.{currentItemName}.";
            if (listBoxItemsOther.SelectedIndex < 0)
            {
                currentItemsOtherKey = null;
                richTextBoxItemsOther.Clear();
                buttonItemsOtherRename.Enabled = false;
                buttonItemsOtherDelete.Enabled = false;
            }
            else
            {
                currentItemsOtherKey = ListBoxSelected(overlay, listBoxItemsOther, richTextBoxItemsOther, otherPrefix);
                buttonItemsOtherRename.Enabled = true;
                buttonItemsOtherDelete.Enabled = true;
            }
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
            if (listBoxRoomsExits.SelectedIndex < 0)
            {
                currentRoomsExitsKey = null;
                richTextBoxRoomsExits.Clear();
                buttonRoomsExitsRename.Enabled = false;
                buttonRoomsExitsDelete.Enabled = false;
            }
            else
            {
                currentRoomsExitsKey = ListBoxSelected(overlay, listBoxRoomsExits, richTextBoxRoomsExits, exitsPrefix);
                buttonRoomsExitsRename.Enabled = true;
                buttonRoomsExitsDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxRoomsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var roomsOtherPrefix = $"{roomsPrefix}.{currentRoomName}.";
            if (listBoxRoomsOther.SelectedIndex < 0)
            {
                currentRoomsOtherKey = null;
                richTextBoxRoomsOther.Clear();
                buttonRoomsOtherRename.Enabled = false;
                buttonRoomsOtherDelete.Enabled = false;
            }
            else
            {
                currentRoomsOtherKey = ListBoxSelected(overlay, listBoxRoomsOther, richTextBoxRoomsOther, roomsOtherPrefix);
                buttonRoomsOtherRename.Enabled = true;
                buttonRoomsOtherDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void listBoxStartDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            var directionsPrefix = $"{directionPrefix}.";
            if (listBoxStartDirection.SelectedIndex < 0)
            {
                currentStartDirectionsKey = null;
                richTextBoxStartDirections.Clear();
                buttonStartDirectionsRename.Enabled = false;
                buttonStartDirectionsDelete.Enabled = false;
            }
            else
            {
                currentStartDirectionsKey = ListBoxSelected(overlay, listBoxStartDirection, richTextBoxStartDirections, directionsPrefix);
                buttonStartDirectionsRename.Enabled = true;
                buttonStartDirectionsDelete.Enabled = true;
            }
            loading = saveLoading;
        }

        private void comboBoxFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFileNames.SelectedIndex < 0) return;
            var saveLoading = loading;
            loading = true;
            // save existing overlay
            SaveOverlay();
            // load baseGrod
            var filename = comboBoxFileNames.SelectedItem?.ToString() ?? "";
            grodFilename = Path.Combine(basePath, filename);
            try
            {
                baseGrod = IO.OpenFile(grodFilename) ?? new();
            }
            catch (FileNotFoundException)
            {
                baseGrod = new();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file:\n{ex.Message}");
                loading = saveLoading;
                return;
            }
            if (baseGrod == null) return;
            // check for existing overlay file
            overlayFilename = Path.Combine(basePath, Path.GetFileNameWithoutExtension(filename) + OVERLAY_EXTENSION);
            try
            {
                overlay = IO.OpenFile(overlayFilename) ?? new();
            }
            catch (Exception)
            {
                overlay = new();
            }
            overlay.Parent = baseGrod;
            LoadData(overlay);
            loading = saveLoading;
        }

        private void richTextBoxStartGameName_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_GAMENAME, richTextBoxStartGameName.Text);
        }

        private void richTextBoxStartGameTitle_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_GAMETITLE, richTextBoxStartGameTitle.Text);
        }

        private void richTextBoxStartVersion_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_VERSION, richTextBoxStartVersion.Text);
        }

        private void richTextBoxStartIntroduction_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            overlay.Set(SYSTEM_INTRO, richTextBoxStartIntroduction.Text);
        }

        private void richTextBoxStartStartingRoom_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (playerLocationKey == null) return;
            overlay.Set(playerLocationKey, richTextBoxStartStartingRoom.Text);
        }

        private void richTextBoxStartDirections_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentStartDirectionsKey == null) return;
            overlay.Set(currentStartDirectionsKey, richTextBoxStartDirections.Text);
        }

        private void richTextBoxRoomsShortDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentRoomShortDescKey == null) return;
            overlay.Set(currentRoomShortDescKey, richTextBoxRoomsShortDesc.Text);
        }

        private void richTextBoxRoomsLongDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentRoomLongDescKey == null) return;
            overlay.Set(currentRoomLongDescKey, richTextBoxRoomsLongDesc.Text);
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
            if (currentFunctionsKey == null) return;
            overlay.Set(currentFunctionsKey, richTextBoxFunctions.Text);
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

        private void richTextBoxItemsShortDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemShortDescKey == null) return;
            overlay.Set(currentItemShortDescKey, richTextBoxItemsShortDesc.Text);
        }

        private void richTextBoxItemsLongDesc_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemLongDescKey == null) return;
            overlay.Set(currentItemLongDescKey, richTextBoxItemsLongDesc.Text);
        }

        private void richTextBoxItemsLocation_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemLocationKey == null) return;
            overlay.Set(currentItemLocationKey, richTextBoxItemsLocation.Text);
        }

        private void richTextBoxItemsOther_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (currentItemsOtherKey == null) return;
            overlay.Set(currentItemsOtherKey, richTextBoxItemsOther.Text);
        }

        private void buttonStartDirectionsAdd_Click(object sender, EventArgs e)
        {
            var prefix = directionPrefix + '.' ?? "";
            var newKey = ListBoxAddItem(listBoxStartDirection, prefix);
            if (newKey != null)
            {
                overlay.Set(prefix + newKey, "");
                richTextBoxStartDirections.Focus();
            }
        }

        private void buttonFileNew_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                Filter = "Grif files|*.grif",
                AddExtension = true,
            };
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            var filename = dialog.FileName;
            basePath = Path.GetDirectoryName(filename) ?? "";
            filename = Path.GetFileName(filename);
            ClearData();
            buttonFileSave.Enabled = true;
            comboBoxFileNames.SelectedIndex = -1;
            comboBoxFileNames.Items.Clear();
            comboBoxFileNames.Items.Add(filename);
            comboBoxFileNames.SelectedIndex = 0;
        }

        private void buttonRoomsAdd_Click(object sender, EventArgs e)
        {
            var prefix = $"{roomsPrefix}.";
            var newKey = ListBoxAddItem(listBoxRooms, prefix);
            if (newKey != null)
            {
                overlay.Set(prefix + newKey, "");
            }
        }

        private void buttonRoomsExitsAdd_Click(object sender, EventArgs e)
        {
            var prefix = roomsExitsPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName)
                .Replace("{direction}", "");
            var newKey = ListBoxAddItem(listBoxRoomsExits, prefix);
            if (newKey != null)
            {
                overlay.Set(prefix + newKey, "");
                richTextBoxRoomsExits.Focus();
            }
        }

        private void buttonRoomsOtherAdd_Click(object sender, EventArgs e)
        {
            var prefix = $"{roomsPrefix}.{currentRoomName}.";
            var newKey = ListBoxAddItem(listBoxRoomsOther, prefix);
            if (newKey != null)
            {
                overlay.Set(prefix + newKey, "");
                richTextBoxRoomsOther.Focus();
            }
        }

        private void buttonItemsAdd_Click(object sender, EventArgs e)
        {
            var prefix = $"{itemsPrefix}.";
            var newKey = ListBoxAddItem(listBoxItems, prefix);
            if (newKey != null)
            {
                overlay.Set(prefix + newKey, "");
            }
        }

        private void buttonItemsOtherAdd_Click(object sender, EventArgs e)
        {
            var prefix = $"{itemsPrefix}.{currentItemName}.";
            var newKey = ListBoxAddItem(listBoxItemsOther, prefix);
            if (newKey != null)
            {
                overlay.Set(prefix + newKey, "");
                richTextBoxItemsOther.Focus();
            }
        }

        private void buttonSystemAdd_Click(object sender, EventArgs e)
        {
            var newKey = ListBoxAddItem(listBoxSystem, "");
            if (newKey != null)
            {
                overlay.Set(newKey, "");
                richTextBoxSystem.Focus();
            }
        }

        private void buttonScriptsAdd_Click(object sender, EventArgs e)
        {
            var newKey = ListBoxAddItem(listBoxScripts, "");
            if (newKey != null)
            {
                overlay.Set(newKey, "");
                richTextBoxScripts.Focus();
            }
        }

        private void buttonCommandsAdd_Click(object sender, EventArgs e)
        {
            var newKey = ListBoxAddItem(listBoxCommands, "");
            if (newKey != null)
            {
                overlay.Set(newKey, "");
                richTextBoxCommands.Focus();
            }
        }

        private void buttonVocabularyAdd_Click(object sender, EventArgs e)
        {
            var newKey = ListBoxAddItem(listBoxVocabulary, "");
            if (newKey != null)
            {
                overlay.Set(newKey, "");
                richTextBoxVocabulary.Focus();
            }
        }

        private void buttonValuesAdd_Click(object sender, EventArgs e)
        {
            var newKey = ListBoxAddItem(listBoxValues, "");
            if (newKey != null)
            {
                overlay.Set(newKey, "");
                richTextBoxValues.Focus();
            }
        }

        private void buttonMessagesAdd_Click(object sender, EventArgs e)
        {
            var newKey = ListBoxAddItem(listBoxMessages, "");
            if (newKey != null)
            {
                overlay.Set(newKey, "");
                richTextBoxMessages.Focus();
            }
        }

        private void buttonValuesRename_Click(object sender, EventArgs e)
        {
            if (listBoxValues.SelectedIndex < 0 || currentValuesKey == null) return;
            ListBoxRenameItem(overlay, listBoxValues, "", currentValuesKey);
        }

        private void buttonValuesDelete_Click(object sender, EventArgs e)
        {
            if (listBoxValues.SelectedIndex < 0 || currentValuesKey == null) return;
            ListBoxDeleteItem(overlay, listBoxValues, currentValuesKey);
        }

        private void buttonMessagesRename_Click(object sender, EventArgs e)
        {
            if (listBoxMessages.SelectedIndex < 0 || currentMessagesKey == null) return;
            ListBoxRenameItem(overlay, listBoxMessages, "", currentMessagesKey);
        }

        private void buttonMessagesDelete_Click(object sender, EventArgs e)
        {
            if (listBoxMessages.SelectedIndex < 0 || currentMessagesKey == null) return;
            ListBoxDeleteItem(overlay, listBoxMessages, currentMessagesKey);
        }

        private void buttonItemsOtherRename_Click(object sender, EventArgs e)
        {
            if (listBoxItemsOther.SelectedIndex < 0 || currentItemsOtherKey == null) return;
            var prefix = $"{itemsPrefix}.{currentItemName}.";
            ListBoxRenameItem(overlay, listBoxItemsOther, prefix, currentItemsOtherKey);
        }

        private void buttonItemsOtherDelete_Click(object sender, EventArgs e)
        {
            if (listBoxItemsOther.SelectedIndex < 0 || currentItemsOtherKey == null) return;
            ListBoxDeleteItem(overlay, listBoxItemsOther, currentItemsOtherKey);
        }

        private void buttonItemsRename_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0 || currentItemName == null) return;
            var prefix = $"{itemsPrefix}.";
            ListBoxRenameItem(overlay, listBoxItems, prefix, currentItemName);
        }

        private void buttonItemsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0 || currentItemName == null) return;
            ListBoxDeleteItem(overlay, listBoxItems, currentItemName);
        }

        private void buttonRoomsRename_Click(object sender, EventArgs e)
        {
            if (listBoxRooms.SelectedIndex < 0 || currentRoomName == null) return;
            var prefix = $"{roomsPrefix}.";
            ListBoxRenameItem(overlay, listBoxRooms, prefix, currentRoomName);
        }

        private void buttonRoomsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxRooms.SelectedIndex < 0 || currentRoomName == null) return;
            ListBoxDeleteItem(overlay, listBoxRooms, currentRoomName);
        }

        private void buttonRoomsExitsRename_Click(object sender, EventArgs e)
        {
            if (listBoxRoomsExits.SelectedIndex < 0 || currentRoomsExitsKey == null) return;
            var prefix = roomsExitsPattern!
                .Replace("{roomprefix}", roomsPrefix)
                .Replace("{room}", currentRoomName)
                .Replace("{direction}", "");
            ListBoxRenameItem(overlay, listBoxRoomsExits, prefix, currentRoomsExitsKey);
        }

        private void buttonRoomsExitsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxRoomsExits.SelectedIndex < 0 || currentRoomsExitsKey == null) return;
            ListBoxDeleteItem(overlay, listBoxRoomsExits, currentRoomsExitsKey);
        }

        private void buttonRoomsOtherRename_Click(object sender, EventArgs e)
        {
            if (listBoxRoomsOther.SelectedIndex < 0 || currentRoomsOtherKey == null) return;
            var prefix = $"{roomsPrefix}.{currentRoomName}.";
            ListBoxRenameItem(overlay, listBoxRoomsOther, prefix, currentRoomsOtherKey);
        }

        private void buttonRoomsOtherDelete_Click(object sender, EventArgs e)
        {
            if (listBoxRoomsOther.SelectedIndex < 0 || currentRoomsOtherKey == null) return;
            ListBoxDeleteItem(overlay, listBoxRoomsOther, currentRoomsOtherKey);
        }

        private void buttonStartDirectionsRename_Click(object sender, EventArgs e)
        {
            if (listBoxStartDirection.SelectedIndex < 0 || currentStartDirectionsKey == null) return;
            var prefix = directionPrefix + '.' ?? "";
            ListBoxRenameItem(overlay, listBoxStartDirection, prefix, currentStartDirectionsKey);
        }

        private void buttonStartDirectionsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxStartDirection.SelectedIndex < 0 || currentStartDirectionsKey == null) return;
            ListBoxDeleteItem(overlay, listBoxStartDirection, currentStartDirectionsKey);
        }

        private void buttonFunctionsRename_Click(object sender, EventArgs e)
        {
            if (listBoxFunctions.SelectedIndex < 0 || currentFunctionsKey == null) return;
            var prefix = "@";
            ListBoxRenameItem(overlay, listBoxFunctions, prefix, currentFunctionsKey);
        }

        private void buttonFunctionsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxFunctions.SelectedIndex < 0 || currentFunctionsKey == null) return;
            ListBoxDeleteItem(overlay, listBoxFunctions, currentFunctionsKey);
        }

        private void buttonSystemRename_Click(object sender, EventArgs e)
        {
            if (listBoxSystem.SelectedIndex < 0 || currentSystemKey == null) return;
            ListBoxRenameItem(overlay, listBoxSystem, "", currentSystemKey);
        }

        private void buttonSystemDelete_Click(object sender, EventArgs e)
        {
            if (listBoxSystem.SelectedIndex < 0 || currentSystemKey == null) return;
            ListBoxDeleteItem(overlay, listBoxSystem, currentSystemKey);
        }

        private void buttonScriptsRename_Click(object sender, EventArgs e)
        {
            if (listBoxScripts.SelectedIndex < 0 || currentScriptsKey == null) return;
            ListBoxRenameItem(overlay, listBoxScripts, "", currentScriptsKey);
        }

        private void buttonScriptsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxScripts.SelectedIndex < 0 || currentScriptsKey == null) return;
            ListBoxDeleteItem(overlay, listBoxScripts, currentScriptsKey);
        }

        private void buttonCommandsRename_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedIndex < 0 || currentCommandsKey == null) return;
            ListBoxRenameItem(overlay, listBoxCommands, "", currentCommandsKey);
        }

        private void buttonCommandsDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedIndex < 0 || currentCommandsKey == null) return;
            ListBoxDeleteItem(overlay, listBoxCommands, currentCommandsKey);
        }

        private void buttonVocabularyRename_Click(object sender, EventArgs e)
        {
            if (listBoxVocabulary.SelectedIndex < 0 || currentVocabularyKey == null) return;
            ListBoxRenameItem(overlay, listBoxVocabulary, "", currentVocabularyKey);
        }

        private void buttonVocabularyDelete_Click(object sender, EventArgs e)
        {
            if (listBoxVocabulary.SelectedIndex < 0 || currentVocabularyKey == null) return;
            ListBoxDeleteItem(overlay, listBoxVocabulary, currentVocabularyKey);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveOverlay();
        }

        private void SaveOverlay()
        {
            // save existing overlay
            if (!string.IsNullOrEmpty(overlayFilename))
            {
                if (overlay.Count(false) > 0)
                {
                    IO.WriteGrif(overlayFilename, overlay.Items(false, true), false);
                }
                else
                {
                    File.Delete(overlayFilename);
                }
                overlayFilename = null;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            SelectTab(buttonHelp, groupBoxHelp);
        }

        private void listBoxHelp_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saveLoading = loading;
            loading = true;
            if (listBoxHelp.SelectedIndex < 0)
            {
                currentHelpKey = null;
                richTextBoxHelp.Clear();
            }
            else
            {
                currentHelpKey = ListBoxSelected(helpGrod, listBoxHelp, richTextBoxHelp);
            }
            loading = saveLoading;
        }
    }
}
