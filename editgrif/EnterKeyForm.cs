using System.ComponentModel;
using GrifLib;
using static GrifLib.Common;

namespace editgrif;

public partial class EnterKeyForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Key
    {
        get
        {
            if (!ValidKey(labelPrefix.Text + textBoxKey.Text, IsFunctionKey)) return "";
            return textBoxKey.Text;
        }
        set
        {
            textBoxKey.Text = value;
            textBoxKey.SelectionLength = 0;
            textBoxKey.SelectionStart = value.Length;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Prefix
    {
        get
        {
            return labelPrefix.Text;
        }
        set
        {
            labelPrefix.Text = value;
            var width = textBoxKey.Width;
            textBoxKey.Location = new Point(labelPrefix.Left + labelPrefix.Width, textBoxKey.Top);
            textBoxKey.Width = width - labelPrefix.Width;
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
        if (!ValidKey(labelPrefix.Text + textBoxKey.Text, IsFunctionKey))
        {
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

    private bool ValidKey(string key, bool functionKey)
    {
        try
        {
            Grod.ValidateKey(key);
            if (key.StartsWith(LOCAL_CHAR)) // allowed in Grod but not in saved files
            {
                throw new ArgumentException($"Keys cannot start with {LOCAL_CHAR}: {key}", nameof(key));
            }
            if (functionKey && !key.StartsWith(SCRIPT_CHAR))
            {
                throw new ArgumentException($"Function keys must start with {SCRIPT_CHAR}: {key}", nameof(key));
            }
            return true;

        }
        catch (Exception ex)
        {
            labelError.Text = ex.Message;
            return false;
        }
    }
}
