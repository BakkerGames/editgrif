namespace editgrif
{
    partial class EnterKeyForm
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
            textBoxKey = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            labelError = new Label();
            labelPrefix = new Label();
            SuspendLayout();
            // 
            // textBoxKey
            // 
            textBoxKey.Font = new Font("Consolas", 12F);
            textBoxKey.Location = new Point(12, 12);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(465, 26);
            textBoxKey.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(321, 49);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(402, 49);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(12, 53);
            labelError.Name = "labelError";
            labelError.Size = new Size(32, 15);
            labelError.TabIndex = 4;
            labelError.Text = "Error";
            labelError.Visible = false;
            // 
            // labelPrefix
            // 
            labelPrefix.AutoSize = true;
            labelPrefix.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrefix.Location = new Point(12, 15);
            labelPrefix.Name = "labelPrefix";
            labelPrefix.Size = new Size(0, 19);
            labelPrefix.TabIndex = 5;
            // 
            // EnterKeyForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(489, 84);
            Controls.Add(textBoxKey);
            Controls.Add(labelPrefix);
            Controls.Add(labelError);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EnterKeyForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter Key";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxKey;
        private Button buttonOK;
        private Button buttonCancel;
        private Label labelError;
        private Label labelPrefix;
    }
}