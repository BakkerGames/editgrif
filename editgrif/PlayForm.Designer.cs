namespace editgrif
{
    partial class PlayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxInput = new TextBox();
            labelEntry = new Label();
            richTextBoxPlay = new RichTextBox();
            SuspendLayout();
            // 
            // textBoxInput
            // 
            textBoxInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInput.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInput.Location = new Point(27, 732);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(954, 26);
            textBoxInput.TabIndex = 0;
            textBoxInput.KeyPress += textBoxInput_KeyPress;
            // 
            // labelEntry
            // 
            labelEntry.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEntry.AutoSize = true;
            labelEntry.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEntry.Location = new Point(3, 735);
            labelEntry.Name = "labelEntry";
            labelEntry.Size = new Size(18, 19);
            labelEntry.TabIndex = 2;
            labelEntry.Text = ">";
            // 
            // richTextBoxPlay
            // 
            richTextBoxPlay.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxPlay.Location = new Point(0, 0);
            richTextBoxPlay.Name = "richTextBoxPlay";
            richTextBoxPlay.ReadOnly = true;
            richTextBoxPlay.Size = new Size(981, 726);
            richTextBoxPlay.TabIndex = 3;
            richTextBoxPlay.Text = "";
            // 
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(984, 761);
            Controls.Add(richTextBoxPlay);
            Controls.Add(labelEntry);
            Controls.Add(textBoxInput);
            KeyPreview = true;
            Name = "PlayForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PlayForm";
            Shown += PlayForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxInput;
        private Label labelEntry;
        private RichTextBox richTextBoxPlay;
    }
}