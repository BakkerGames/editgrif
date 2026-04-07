using GrifLib;

namespace editgrif;

internal static class StaticRoutines
{
    internal static Color GetColorValue(TextColorEnum textColor)
    {
        return textColor switch
        {
            TextColorEnum.Default => Color.Black,
            TextColorEnum.PunctuationColor => Color.LightGray,
            TextColorEnum.ParenthesisColor => Color.Brown,
            TextColorEnum.TokenColor => Color.Blue,
            TextColorEnum.IfColor => Color.DeepSkyBlue,
            TextColorEnum.ForColor => Color.DeepPink,
            TextColorEnum.QuoteColor => Color.ForestGreen,
            TextColorEnum.ParameterColor => Color.DeepPink,
            TextColorEnum.CommentColor => Color.LightGreen,
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
        if (script != null)
        {
            var items = Dags.ColorizeScript(script);
            foreach (var item in items)
            {
                rtb.AppendText(item.Text, GetColorValue(item.ColorValue));
            }
        }
        return key;
    }

    internal static void FillListBox(Grod grod, string prefix, ListBox listbox)
    {
        var keys = grod.Keys(prefix, true, true) ?? [];
        AddListBox(keys, listbox);
    }

    internal static void AddListBox(List<string> keys, ListBox listbox)
    {
        if (keys.Count == 0) return;
        foreach (var item in listbox.Items)
        {
            if (!keys.Contains((string)item, StringComparer.OrdinalIgnoreCase))
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
                var name = key[(prefix.Length + 1)..].ToLower();
                if (name.Contains('.'))
                {
                    name = name[..name.IndexOf('.')];
                }
                if (!allKeys.Contains(name, StringComparer.OrdinalIgnoreCase))
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

    internal static void FillRichTextBox(RichTextBox rtb, string? script)
    {
        rtb.Clear();
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
