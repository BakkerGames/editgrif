using GrifLib;
using static GrifLib.Common;

namespace editgrif;

internal static class StaticRoutines
{
    internal static Color GetColorValue(TextColorEnum textColor)
    {
        return textColor switch
        {
            TextColorEnum.Default => Color.Black,
            TextColorEnum.PunctuationColor => Color.Gray,
            TextColorEnum.ParenthesisColor => Color.Brown,
            TextColorEnum.TokenColor => Color.Blue,
            TextColorEnum.IfColor => Color.DeepSkyBlue,
            TextColorEnum.ForColor => Color.DeepPink,
            TextColorEnum.QuoteColor => Color.ForestGreen,
            TextColorEnum.ParameterColor => Color.DeepPink,
            TextColorEnum.CommentColor => Color.LightGreen,
            TextColorEnum.SpecialCharColor => Color.Firebrick,
            _ => Color.Black,
        };
    }

    internal static string? ListBoxSelected(Grod grod, ListBox listbox, RichTextBox rtb, string prefix = "")
    {
        rtb.Clear();
        if (listbox.SelectedIndex < 0)
        {
            return null;
        }
        var key = prefix + listbox.Items[listbox.SelectedIndex].ToString();
        var script = grod.Get(key, true);
        FillRichTextBox(rtb, script);
        return key;
    }

    internal static void FillListBox(Grod grod, string prefix, ListBox listbox)
    {
        var keys = grod.Keys(prefix, true, true) ?? [];
        AddListBox(listbox, keys);
    }

    internal static bool ListContains(string[] list, string value)
    {
        foreach (var item in list)
        {
            if (item != null && item.ToString()!.Equals(value, OIC))
            {
                return true;
            }
        }
        return false;
    }

    internal static bool ListContains(List<string> list, string value)
    {
        foreach (var item in list)
        {
            if (item != null && item.ToString()!.Equals(value, OIC))
            {
                return true;
            }
        }
        return false;
    }

    internal static bool ListBoxContains(ListBox listbox, string value)
    {
        foreach (var item in listbox.Items)
        {
            if (item != null && item.ToString()!.Equals(value, OIC))
            {
                return true;
            }
        }
        return false;
    }

    internal static void AddListBox(ListBox listbox, List<string> keys)
    {
        if (keys.Count == 0) return;
        foreach (var item in listbox.Items)
        {
            if (!ListContains(keys, (string)item))
            {
                keys.Add((string)item);
            }
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

    internal static void FillListBoxFromPrefixes(Grod grod, string[] prefixes, ListBox listbox)
    {
        List<string> allKeys = [];
        foreach (var prefix in prefixes)
        {
            var keys = grod.Keys($"{prefix}.", true, false);
            foreach (var key in keys)
            {
                allKeys.Add(key);
            }
        }
        allKeys.Sort(Grod.CompareKeys);
        listbox.BeginUpdate();
        listbox.Items.Clear();
        foreach (var name in allKeys)
        {
            listbox.Items.Add(name);
        }
        listbox.EndUpdate();
    }

    internal static void FillListBoxFromPrefixUnique(Grod grod, string[] prefixes, ListBox listbox)
    {
        List<string> allKeys = [];
        foreach (var prefix in prefixes)
        {
            var keys = grod.Keys($"{prefix}.", true, false);
            foreach (var key in keys)
            {
                var name = key[(prefix.Length + 1)..];
                if (name.Contains('.'))
                {
                    name = name[..name.IndexOf('.')];
                }
                if (!ListContains(allKeys, name))
                {
                    allKeys.Add(name);
                }
            }
        }
        allKeys.Sort(Grod.CompareKeys);
        listbox.BeginUpdate();
        listbox.Items.Clear();
        foreach (var name in allKeys)
        {
            listbox.Items.Add(name);
        }
        listbox.EndUpdate();
    }

    internal static void SetValue(Grod newGrod, string key, string? value)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return;
        newGrod.Set(key, value);
    }

    internal static void SetValuesFromListBox(Grod grod, Grod newGrod, string prefix, ListBox listbox)
    {
        foreach (var item in listbox.Items)
        {
            var key = $"{prefix}.{item}";
            SetValue(newGrod, key, grod.Get(key, true));
        }
    }

    internal static void FillRichTextBox(RichTextBox rtb, string? script, bool format = true)
    {
        rtb.Clear();
        if (script != null)
        {
            if (!format)
            {
                rtb.Text = script;
            }
            else if (script.StartsWith(SCRIPT_CHAR))
            {
                var items = Dags.ColorizeScript(script);
                foreach (var item in items)
                {
                    rtb.AppendText(item.Text, GetColorValue(item.ColorValue));
                }
            }
            else
            {
                rtb.Text = FormatText(script);
            }
        }
    }

    private static string FormatText(string script)
    {
        return script.Replace("\\n", "\n").Replace("\\s", " ").Replace("\\t", "\t");
    }

    internal static string? ListBoxAddItem(ListBox listBox, string prefix, string? defaultValue = null)
    {
        var dialog = new EnterKeyForm
        {
            Prefix = prefix,
            Key = defaultValue ?? ""
        };
        dialog.ShowDialog();
        if (dialog.DialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.Key))
        {
            return null;
        }
        var newKey = dialog.Key;
        var fullKey = prefix + newKey;
        var tempNewKey = newKey;
        if (prefix == SCRIPT_CHAR.ToString()) // functions are different
        {
            tempNewKey = prefix + newKey;
        }
        if (ListBoxContains(listBox, tempNewKey))
        {
            MessageBox.Show($"Key already exists: {fullKey}");
            return null;
        }
        AddListBox(listBox, [tempNewKey]);
        listBox.SelectedItem = tempNewKey;
        return newKey; // without prefix
    }

    internal static string? ListBoxRenameItem(Grod grod, ListBox listBox, string prefix, string currentKey)
    {
        var newKey = ListBoxAddItem(listBox, prefix, currentKey[prefix.Length..]);
        if (newKey != null)
        {
            RenameItem(grod, currentKey, prefix + newKey);
            var tempNewKey = newKey;
            var tempCurrentKey = currentKey[prefix.Length..];
            if (prefix == SCRIPT_CHAR.ToString()) // functions are different
            {
                tempNewKey = prefix + tempNewKey;
                tempCurrentKey = prefix + tempCurrentKey;
            }
            listBox.SelectedIndex = -1;
            listBox.Items.Remove(tempCurrentKey);
            listBox.SelectedItem = tempNewKey;
        }
        return prefix + newKey;
    }

    internal static void RenameItem(Grod grod, string oldKey, string newKey)
    {
        var oldValue = grod.Get(oldKey, true);
        grod.Set(newKey, oldValue);
        grod.Remove(oldKey, true);
    }

    internal static bool ListBoxDeleteItem(Grod grod, ListBox listBox, string prefix, string currentKey)
    {
        if (listBox.SelectedIndex < 0)
        {
            return false;
        }
        var result = MessageBox.Show(currentKey, "Delete this key?", MessageBoxButtons.OKCancel);
        if (result != DialogResult.OK)
        {
            return false;
        }
        listBox.SelectedIndex = -1;
        grod.Remove(currentKey, true);
        var itemKey = currentKey[prefix.Length..];
        listBox.Items.Remove(itemKey);
        return true;
    }
}
