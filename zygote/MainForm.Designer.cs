namespace zygote
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStart = new Button();
            buttonRooms = new Button();
            buttonItems = new Button();
            buttonMessages = new Button();
            buttonValues = new Button();
            buttonVocabulary = new Button();
            buttonCommands = new Button();
            buttonSystem = new Button();
            buttonScripts = new Button();
            groupBoxStart = new GroupBox();
            groupBoxRooms = new GroupBox();
            groupBoxItems = new GroupBox();
            groupBoxMessages = new GroupBox();
            groupBoxValues = new GroupBox();
            groupBoxVocabulary = new GroupBox();
            groupBoxCommands = new GroupBox();
            groupBoxScripts = new GroupBox();
            groupBoxSystem = new GroupBox();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(3, 40);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(96, 50);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonRooms
            // 
            buttonRooms.Location = new Point(3, 96);
            buttonRooms.Name = "buttonRooms";
            buttonRooms.Size = new Size(96, 50);
            buttonRooms.TabIndex = 1;
            buttonRooms.Text = "Rooms";
            buttonRooms.UseVisualStyleBackColor = true;
            buttonRooms.Click += buttonRooms_Click;
            // 
            // buttonItems
            // 
            buttonItems.Location = new Point(3, 152);
            buttonItems.Name = "buttonItems";
            buttonItems.Size = new Size(96, 50);
            buttonItems.TabIndex = 2;
            buttonItems.Text = "Items";
            buttonItems.UseVisualStyleBackColor = true;
            buttonItems.Click += buttonItems_Click;
            // 
            // buttonMessages
            // 
            buttonMessages.Location = new Point(3, 208);
            buttonMessages.Name = "buttonMessages";
            buttonMessages.Size = new Size(96, 50);
            buttonMessages.TabIndex = 3;
            buttonMessages.Text = "Messages";
            buttonMessages.UseVisualStyleBackColor = true;
            buttonMessages.Click += buttonMessages_Click;
            // 
            // buttonValues
            // 
            buttonValues.Location = new Point(3, 264);
            buttonValues.Name = "buttonValues";
            buttonValues.Size = new Size(96, 50);
            buttonValues.TabIndex = 4;
            buttonValues.Text = "Values";
            buttonValues.UseVisualStyleBackColor = true;
            buttonValues.Click += buttonValues_Click;
            // 
            // buttonVocabulary
            // 
            buttonVocabulary.Location = new Point(3, 320);
            buttonVocabulary.Name = "buttonVocabulary";
            buttonVocabulary.Size = new Size(96, 50);
            buttonVocabulary.TabIndex = 5;
            buttonVocabulary.Text = "Vocabulary";
            buttonVocabulary.UseVisualStyleBackColor = true;
            buttonVocabulary.Click += buttonVocabulary_Click;
            // 
            // buttonCommands
            // 
            buttonCommands.Location = new Point(3, 376);
            buttonCommands.Name = "buttonCommands";
            buttonCommands.Size = new Size(96, 50);
            buttonCommands.TabIndex = 6;
            buttonCommands.Text = "Commands";
            buttonCommands.UseVisualStyleBackColor = true;
            buttonCommands.Click += buttonCommands_Click;
            // 
            // buttonSystem
            // 
            buttonSystem.Location = new Point(3, 488);
            buttonSystem.Name = "buttonSystem";
            buttonSystem.Size = new Size(96, 50);
            buttonSystem.TabIndex = 8;
            buttonSystem.Text = "System";
            buttonSystem.UseVisualStyleBackColor = true;
            buttonSystem.Click += buttonSystem_Click;
            // 
            // buttonScripts
            // 
            buttonScripts.Location = new Point(3, 432);
            buttonScripts.Name = "buttonScripts";
            buttonScripts.Size = new Size(96, 50);
            buttonScripts.TabIndex = 7;
            buttonScripts.Text = "Scripts";
            buttonScripts.UseVisualStyleBackColor = true;
            buttonScripts.Click += buttonScripts_Click;
            // 
            // groupBoxStart
            // 
            groupBoxStart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxStart.Location = new Point(105, 31);
            groupBoxStart.Name = "groupBoxStart";
            groupBoxStart.Size = new Size(1066, 714);
            groupBoxStart.TabIndex = 10;
            groupBoxStart.TabStop = false;
            groupBoxStart.Text = "Start";
            // 
            // groupBoxRooms
            // 
            groupBoxRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRooms.Location = new Point(105, 31);
            groupBoxRooms.Name = "groupBoxRooms";
            groupBoxRooms.Size = new Size(1066, 714);
            groupBoxRooms.TabIndex = 11;
            groupBoxRooms.TabStop = false;
            groupBoxRooms.Text = "Rooms";
            groupBoxRooms.Visible = false;
            // 
            // groupBoxItems
            // 
            groupBoxItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxItems.Location = new Point(105, 31);
            groupBoxItems.Name = "groupBoxItems";
            groupBoxItems.Size = new Size(1066, 714);
            groupBoxItems.TabIndex = 12;
            groupBoxItems.TabStop = false;
            groupBoxItems.Text = "Items";
            groupBoxItems.Visible = false;
            // 
            // groupBoxMessages
            // 
            groupBoxMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMessages.Location = new Point(105, 31);
            groupBoxMessages.Name = "groupBoxMessages";
            groupBoxMessages.Size = new Size(1066, 714);
            groupBoxMessages.TabIndex = 13;
            groupBoxMessages.TabStop = false;
            groupBoxMessages.Text = "Messages";
            groupBoxMessages.Visible = false;
            // 
            // groupBoxValues
            // 
            groupBoxValues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxValues.Location = new Point(105, 31);
            groupBoxValues.Name = "groupBoxValues";
            groupBoxValues.Size = new Size(1066, 714);
            groupBoxValues.TabIndex = 14;
            groupBoxValues.TabStop = false;
            groupBoxValues.Text = "Values";
            groupBoxValues.Visible = false;
            // 
            // groupBoxVocabulary
            // 
            groupBoxVocabulary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxVocabulary.Location = new Point(105, 31);
            groupBoxVocabulary.Name = "groupBoxVocabulary";
            groupBoxVocabulary.Size = new Size(1066, 714);
            groupBoxVocabulary.TabIndex = 15;
            groupBoxVocabulary.TabStop = false;
            groupBoxVocabulary.Text = "Vocabulary";
            groupBoxVocabulary.Visible = false;
            // 
            // groupBoxCommands
            // 
            groupBoxCommands.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCommands.Location = new Point(105, 31);
            groupBoxCommands.Name = "groupBoxCommands";
            groupBoxCommands.Size = new Size(1066, 714);
            groupBoxCommands.TabIndex = 16;
            groupBoxCommands.TabStop = false;
            groupBoxCommands.Text = "Commands";
            groupBoxCommands.Visible = false;
            // 
            // groupBoxScripts
            // 
            groupBoxScripts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxScripts.Location = new Point(105, 31);
            groupBoxScripts.Name = "groupBoxScripts";
            groupBoxScripts.Size = new Size(1066, 714);
            groupBoxScripts.TabIndex = 17;
            groupBoxScripts.TabStop = false;
            groupBoxScripts.Text = "Scripts";
            groupBoxScripts.Visible = false;
            // 
            // groupBoxSystem
            // 
            groupBoxSystem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSystem.Location = new Point(105, 31);
            groupBoxSystem.Name = "groupBoxSystem";
            groupBoxSystem.Size = new Size(1066, 714);
            groupBoxSystem.TabIndex = 18;
            groupBoxSystem.TabStop = false;
            groupBoxSystem.Text = "System";
            groupBoxSystem.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 757);
            Controls.Add(groupBoxSystem);
            Controls.Add(groupBoxScripts);
            Controls.Add(groupBoxCommands);
            Controls.Add(groupBoxVocabulary);
            Controls.Add(groupBoxValues);
            Controls.Add(groupBoxMessages);
            Controls.Add(groupBoxItems);
            Controls.Add(groupBoxRooms);
            Controls.Add(groupBoxStart);
            Controls.Add(buttonSystem);
            Controls.Add(buttonScripts);
            Controls.Add(buttonCommands);
            Controls.Add(buttonVocabulary);
            Controls.Add(buttonValues);
            Controls.Add(buttonMessages);
            Controls.Add(buttonItems);
            Controls.Add(buttonRooms);
            Controls.Add(buttonStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zygote";
            ResumeLayout(false);
        }

        #endregion
        private Button buttonStart;
        private Button buttonRooms;
        private Button buttonItems;
        private Button buttonMessages;
        private Button buttonValues;
        private Button buttonVocabulary;
        private Button buttonCommands;
        private Button buttonSystem;
        private Button buttonScripts;
        private GroupBox groupBoxStart;
        private GroupBox groupBoxRooms;
        private GroupBox groupBoxItems;
        private GroupBox groupBoxMessages;
        private GroupBox groupBoxValues;
        private GroupBox groupBoxVocabulary;
        private GroupBox groupBoxCommands;
        private GroupBox groupBoxScripts;
        private GroupBox groupBoxSystem;
    }
}
