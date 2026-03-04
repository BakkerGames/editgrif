using System.ComponentModel;

namespace zygote;

public partial class EnterKeyForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Key
    {
        get
        {
            return textBoxKey.Text;
        }
        set
        {
            textBoxKey.Text = value;
        }
    }

    public EnterKeyForm()
    {
        InitializeComponent();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
