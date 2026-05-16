using System.Text;
using GrifLib;
using static GrifLib.Common;

namespace editgrif;

public partial class PlayForm : Form
{
    private readonly StringBuilder keyBuffer = new();
    private readonly List<string> inputLines = [];
    private int outputCount = 0;
    private int maxOutputWidth = 0;
    private bool uppercaseInput = false;
    private string tabChars = "    ";
    private int readyForInput = 0;
    private bool waitingForInput = false;
    private IFGame game = new();

    public PlayForm()
    {
        InitializeComponent();
    }

    private readonly Grod baseGrod = new();

    public bool Init(Grod grod)
    {
        baseGrod.Clear(true);
        baseGrod.AddItems(grod.Items(true, true));
        game = new();
        var gameName = baseGrod.Get(GAMENAME, true);
        if (string.IsNullOrWhiteSpace(gameName))
        {
            MessageBox.Show("GameName not set for this game");
            Close();
            return false;
        }
        game.Initialize(baseGrod, gameName, null);
        // get settings
        maxOutputWidth = (int)(baseGrod.GetNumber(OUTPUT_WIDTH, true) ?? 0);
        if ((baseGrod.GetNumber(OUTPUT_TAB_LENGTH, true) ?? 0) > 0)
        {
            tabChars = new string(' ', (int)(baseGrod.GetNumber(OUTPUT_TAB_LENGTH, true) ?? 4));
        }
        uppercaseInput = baseGrod.GetBool(UPPERCASE, true) ?? false;
        // connect the event handlers
        game.InputEvent += Input;
        game.OutputEvent += Output;
        return true;
    }

    /// <summary>
    /// Handle input event.
    /// </summary>
    private void Input(object sender)
    {
        readyForInput++;
        CheckInput();
    }

    private void CheckInput()
    {
        if (!waitingForInput && readyForInput > 0)
        {
            OutputText(game.Prompt() ?? "");
            waitingForInput = true;
            readyForInput--;
        }
        if (!waitingForInput || inputLines.Count == 0)
        {
            return;
        }
        var input = inputLines[0];
        inputLines.RemoveAt(0);
        if (uppercaseInput)
        {
            input = input.ToUpper();
        }
        textBoxPlay.AppendText(input);
        textBoxPlay.AppendText(Environment.NewLine);
        var message = new GrifMessage(MessageType.Text, input);
        OutputText(game.AfterPrompt() ?? "");
        waitingForInput = false;
        game.InputMessages.Enqueue(message);
        game.GameStep();
    }

    /// <summary>
    /// Handle output event.
    /// </summary>
    private void Output(object sender, GrifMessage e)
    {
        if (e.Type == MessageType.Text)
        {
            OutputText(e.Value);
            return;
        }
        if (e.Type == MessageType.Error)
        {
            OutputText(NL_CHAR);
            OutputText("### ERROR: ");
            OutputText(e.Value);
            return;
        }
    }

    /// <summary>
    /// Output text with word wrapping and special character handling.
    /// </summary>
    private void OutputText(string text)
    {
        if (text.Contains(SPACE_CHAR))
        {
            text = text.Replace(SPACE_CHAR, " ");
        }
        if (text.Contains('\r') || text.Contains('\n'))
        {
            text = text.Replace("\r", "").Replace("\n", NL_CHAR);
        }
        if (text.Contains(TAB_CHAR) || text.Contains('\t'))
        {
            text = text.Replace(TAB_CHAR, tabChars).Replace("\t", tabChars);
        }
        while (text.Contains(NL_CHAR))
        {
            var index = text.IndexOf(NL_CHAR);
            var before = text[..index];
            text = text[(index + 2)..];
            var lines = IO.Wordwrap(before, outputCount, maxOutputWidth);
            foreach (var line in lines)
            {
                textBoxPlay.AppendText(line);
                textBoxPlay.AppendText(Environment.NewLine);
                outputCount = 0;
            }
        }
        if (!string.IsNullOrEmpty(text))
        {
            var lines = IO.Wordwrap(text, outputCount, maxOutputWidth);
            // WriteLine all but last line
            for (int i = 0; i < lines.Count - 1; i++)
            {
                var line = lines[i];
                textBoxPlay.AppendText(line);
                textBoxPlay.AppendText(Environment.NewLine);
                outputCount = 0;
            }
            // Write last line with no NL
            if (lines.Count > 0)
            {
                var line = lines[^1];
                textBoxPlay.AppendText(line);
                outputCount = line.Length;
            }
        }
    }

    private void PlayForm_Shown(object sender, EventArgs e)
    {
        game.Intro();
    }

    private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
    {
        char c = e.KeyChar;
        e.Handled = true;
        switch (c)
        {
            case '\b':
                if (textBoxInput.Text.Length > 0)
                {
                    textBoxInput.Text = textBoxInput.Text[..^1];
                    textBoxInput.SelectionStart = textBoxInput.Text.Length;
                }
                break;
            case '\n':
            case '\r':
                if (!string.IsNullOrWhiteSpace(textBoxInput.Text))
                {
                    inputLines.Add(textBoxInput.Text);
                    textBoxInput.Text = "";
                    CheckInput();
                }
                break;
            default:
                if (c >= ' ')
                {
                    textBoxInput.Text += c;
                    textBoxInput.SelectionStart = textBoxInput.Text.Length;
                }
                break;
        }
    }
}
