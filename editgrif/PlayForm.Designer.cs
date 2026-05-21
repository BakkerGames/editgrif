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
            textBoxPlay = new TextBox();
            textBoxInput = new TextBox();
            labelEntry = new Label();
            SuspendLayout();
            // 
            // textBoxPlay
            // 
            textBoxPlay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPlay.BackColor = Color.LightCyan;
            textBoxPlay.Font = new Font("Consolas", 12F);
            textBoxPlay.Location = new Point(0, 0);
            textBoxPlay.MinimumSize = new Size(800, 450);
            textBoxPlay.Multiline = true;
            textBoxPlay.Name = "textBoxPlay";
            textBoxPlay.ReadOnly = true;
            textBoxPlay.ScrollBars = ScrollBars.Vertical;
            textBoxPlay.Size = new Size(984, 729);
            textBoxPlay.TabIndex = 1;
            textBoxPlay.TabStop = false;
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
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(984, 761);
            Controls.Add(labelEntry);
            Controls.Add(textBoxInput);
            Controls.Add(textBoxPlay);
            KeyPreview = true;
            Name = "PlayForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PlayForm";
            Shown += PlayForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPlay;
        private TextBox textBoxInput;
        private Label labelEntry;
    }
}