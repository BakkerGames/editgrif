using System.Xml.Linq;
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
            HideAll();
            groupBoxStart.Visible = true;
            buttonStart.BackColor = Color.LightGreen;
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

        #endregion

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

        private void ClearStartTab()
        {
            textBoxStartGameName.Text = "";
            textBoxStartGameTitle.Text = "";
            textBoxStartVersion.Text = "";
            textBoxStartIntroduction.Text = "";
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

            var roomList = grod.Get(SYSTEM_PREFIX_ROOM_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_ROOM.Split(',');
            FillRoomsItems(grod, roomList, listBoxRooms);

            var itemList = grod.Get(SYSTEM_PREFIX_ITEM_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_ITEM.Split(',');
            FillRoomsItems(grod, itemList, listBoxItems);

            var messageList = grod.Get(SYSTEM_PREFIX_MESSAGE_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_MESSAGE.Split(',');
            foreach (var prefix in messageList)
            {
                FillListBox(grod, $"{prefix}.", listBoxMessages);
            }

            var valueList = grod.Get(SYSTEM_PREFIX_VALUE_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_VALUE.Split(',');
            foreach (var prefix in valueList)
            {
                FillListBox(grod, $"{prefix}.", listBoxValues);
            }

            var vocabularyList = grod.Get(SYSTEM_PREFIX_VOCABULARY_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_VOCABULARY.Split(',');
            foreach (var prefix in vocabularyList)
            {
                FillListBox(grod, $"{prefix}.", listBoxVocabulary);
            }

            var commandList = grod.Get(SYSTEM_PREFIX_COMMAND_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_COMMAND.Split(',');
            foreach (var prefix in commandList)
            {
                FillListBox(grod, $"{prefix}.", listBoxCommands);
            }

            var scriptList = grod.Get(SYSTEM_PREFIX_SCRIPT_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_SCRIPT.Split(',');
            foreach (var prefix in scriptList)
            {
                FillListBox(grod, $"{prefix}.", listBoxScripts);
            }

            // function keys all start with '@'
            FillListBox(grod, SCRIPT_CHAR.ToString(), listBoxFunctions);

            var systemList = grod.Get(SYSTEM_PREFIX_SYSTEM_KEY, true)?.Split(',')
                ?? DEFAULT_PREFIX_SYSTEM.Split(',');
            foreach (var prefix in systemList)
            {
                FillListBox(grod, $"{prefix}.", listBoxSystem);
            }

            List<string> extraKeys = [];
            foreach (var key in grod.Keys(true, true))
            {
                if (key.StartsWith(SCRIPT_CHAR)) continue;
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
                        !vocabularyList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !commandList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !scriptList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !roomList.Contains(prefix, StringComparer.OrdinalIgnoreCase) &&
                        !itemList.Contains(prefix, StringComparer.OrdinalIgnoreCase))
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

        private void FillRoomsItems(Grod grod, string[] prefixes, ListBox listbox)
        {
            List<string> allKeys = [];
            foreach (var prefix in prefixes)
            {
                var keys = grod.Keys($"{prefix}.", true, false);
                foreach (var key in keys)
                {
                    var pos = key.IndexOf('.', prefix.Length + 1);
                    if (pos >= 0)
                    {
                        var name = key[(prefix.Length + 1)..pos];
                        if (!allKeys.Contains(name))
                        {
                            allKeys.Add(name);
                        }
                    }
                }
            }
            allKeys.Sort(Grod.CompareKeys);
            foreach (var name in allKeys)
            {
                if (!listbox.Items.Contains(name))
                {
                    listbox.Items.Add(name);
                }
            }
        }

        private void FillItems(Grod grod, string[] prefixes)
        {
            // TODO needs to check for patterns for longdesc, shortdesc, location, and all others
            //var keys = grod.Keys($"{itemPrefix}.", true, false);
            //keys.Sort(Grod.CompareKeys);
            //foreach (var key in keys)
            //{
            //    var pos = key.IndexOf('.', itemPrefix.Length + 1);
            //    if (pos >= 0)
            //    {
            //        var name = key[(itemPrefix.Length + 1)..pos];
            //        if (!listBoxItems.Items.Contains(name))
            //        {
            //            listBoxItems.Items.Add(name);
            //        }
            //    }
            //}
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
            if (listBoxRooms.SelectedIndex < 0) return;
            // TODO need to check for patterns, not prefixes
            //textBoxRoomsShortDesc.Text = grod.Get($"{roomPrefix}.{listBoxRooms.SelectedItem}.{shortDescSuffix}", true);
            //textBoxRoomsLongDesc.Text = grod.Get($"{roomPrefix}.{listBoxRooms.SelectedItem}.{longDescSuffix}", true);
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
            // TODO need to check for patterns, not prefixes
            //var keys = grod.Keys($"{itemPrefix}.{itemNum}.", true, true) ?? [];
            //var prefixLen = $"{itemPrefix}.{itemNum}.".Length;
            //foreach (var key in keys)
            //{
            //    if (key.EndsWith($".{shortDescSuffix}", StringComparison.OrdinalIgnoreCase))
            //    {
            //        textBoxItemsShortDesc.Text = grod.Get(key, true);
            //    }
            //    else if (key.EndsWith($".{longDescSuffix}", StringComparison.OrdinalIgnoreCase))
            //    {
            //        textBoxItemsLongDesc.Text = grod.Get(key, true);
            //    }
            //    else if (key.EndsWith($".{locationSuffix}", StringComparison.OrdinalIgnoreCase))
            //    {
            //        textBoxItemsLocation.Text = grod.Get(key, true);
            //    }
            //    else
            //    {
            //        listBoxItemsOther.Items.Add(key[prefixLen..]);
            //    }
            //}
        }

        private void listBoxItemsOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxItemsOther.Clear();
            if (listBoxItems.SelectedIndex < 0) return;
            var itemNum = listBoxItems.Items[listBoxItems.SelectedIndex].ToString();
            // TODO need to check for patterns, not prefixes
            //ListBoxSelected(grod, listBoxItemsOther, richTextBoxItemsOther, $"{itemPrefix}.{itemNum}.");
        }
    }
}
