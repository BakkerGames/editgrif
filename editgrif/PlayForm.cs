using System.Text;

namespace editgrif;

public partial class PlayForm : Form
{
    private StringBuilder keyBuffer = new();

    public PlayForm()
    {
        InitializeComponent();
    }

    private void PlayForm_KeyPress(object sender, KeyPressEventArgs e)
    {
        char c = e.KeyChar;
        if (c < ' ')
        {
            if (c == '\r' || c == '\n')
            {
                textBoxPlay.AppendText(Environment.NewLine);
                keyBuffer.Clear();
            }
            else if (c == '\b' && keyBuffer.Length > 0)
            {
                keyBuffer.Length--;
                textBoxPlay.Text = textBoxPlay.Text[..^1];
                textBoxPlay.SelectionStart = textBoxPlay.Text.Length;
            }
        }
        else
        {
            textBoxPlay.AppendText(c.ToString());
            keyBuffer.Append(c);
        }
    }
}
