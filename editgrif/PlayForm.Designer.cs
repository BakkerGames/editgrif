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
            SuspendLayout();
            // 
            // textBoxPlay
            // 
            textBoxPlay.BackColor = SystemColors.Control;
            textBoxPlay.Dock = DockStyle.Fill;
            textBoxPlay.Font = new Font("Consolas", 12F);
            textBoxPlay.Location = new Point(0, 0);
            textBoxPlay.MinimumSize = new Size(800, 450);
            textBoxPlay.Multiline = true;
            textBoxPlay.Name = "textBoxPlay";
            textBoxPlay.ReadOnly = true;
            textBoxPlay.ScrollBars = ScrollBars.Vertical;
            textBoxPlay.Size = new Size(800, 650);
            textBoxPlay.TabIndex = 0;
            // 
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 650);
            Controls.Add(textBoxPlay);
            KeyPreview = true;
            Name = "PlayForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PlayForm";
            KeyPress += PlayForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPlay;
    }
}