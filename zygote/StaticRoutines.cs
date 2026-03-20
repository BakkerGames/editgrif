using GrifLib;

namespace zygote;

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

    internal static void ListBoxSelected(Grod grod, ListBox listbox, RichTextBox rtb, string prefix = "")
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
}
