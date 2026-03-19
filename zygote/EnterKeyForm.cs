using System.ComponentModel;
using static GrifLib.Common;

namespace zygote;

public partial class EnterKeyForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Key
    {
        get
        {
            if (!ValidKey(textBoxKey.Text, IsFunctionKey)) return "";
            return textBoxKey.Text;
        }
        set
        {
            textBoxKey.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsFunctionKey { get; set; } = false;

    public EnterKeyForm()
    {
        InitializeComponent();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        if (!ValidKey(textBoxKey.Text, IsFunctionKey))
        {
            if (IsFunctionKey)
            {
                labelError.Text = "Invalid Function key";
            }
            else
            {
                labelError.Text = "Invalid key";
            }
            labelError.Visible = true;
            return;
        }
        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private static bool ValidKey(string key, bool functionKey)
    {
        if (string.IsNullOrEmpty(key)) return false;
        bool inParen = false;
        bool lastComma = false;
        for (int index = 0; index < key.Length; index++)
        {
            char c = key[index];
            if (index == 0 && functionKey && c != SCRIPT_CHAR)
            {
                return false;
            }
            if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
            {
                lastComma = false;
                continue;
            }
            if (!functionKey)
            {
                if (c == '.')
                {
                    lastComma = false;
                    continue;
                }
                return false;
            }
            else
            {
                if (c == SCRIPT_CHAR)
                {
                    if (index > 0) return false;
                    lastComma = false;
                    continue;
                }
                if (c == '(')
                {
                    if (inParen) return false;
                    inParen = true;
                    lastComma = true; // so no initial comma
                    continue;
                }
                if (inParen)
                {
                    if (c == ',')
                    {
                        if (lastComma) return false;
                        lastComma = true;
                        continue;
                    }
                    if (c == ')')
                    {
                        if (lastComma) return false; // so no trailing comma, no empty parens
                        if (index < key.Length - 1) return false;
                        inParen = false;
                        continue;
                    }
                }
                return false;
            }
        }
        if (inParen) return false;
        return true;
    }
}
