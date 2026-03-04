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
            buttonVersionToday = new Button();
            label5 = new Label();
            textBoxStartStartingRoom = new TextBox();
            label4 = new Label();
            textBoxStartVersion = new TextBox();
            textBoxStartIntroduction = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBoxStartGameTitle = new TextBox();
            label1 = new Label();
            textBoxStartGameName = new TextBox();
            groupBoxRooms = new GroupBox();
            groupBoxItems = new GroupBox();
            groupBoxMessages = new GroupBox();
            groupBoxValues = new GroupBox();
            groupBoxVocabulary = new GroupBox();
            groupBoxCommands = new GroupBox();
            groupBoxScripts = new GroupBox();
            groupBoxSystem = new GroupBox();
            panelToolbar = new Panel();
            buttonFileSave = new Button();
            buttonFileOpen = new Button();
            buttonFileNew = new Button();
            buttonFunctions = new Button();
            groupBoxFunctions = new GroupBox();
            groupBoxStart.SuspendLayout();
            panelToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(3, 48);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(96, 50);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonRooms
            // 
            buttonRooms.Location = new Point(3, 104);
            buttonRooms.Name = "buttonRooms";
            buttonRooms.Size = new Size(96, 50);
            buttonRooms.TabIndex = 1;
            buttonRooms.Text = "Rooms";
            buttonRooms.UseVisualStyleBackColor = true;
            buttonRooms.Click += buttonRooms_Click;
            // 
            // buttonItems
            // 
            buttonItems.Location = new Point(3, 160);
            buttonItems.Name = "buttonItems";
            buttonItems.Size = new Size(96, 50);
            buttonItems.TabIndex = 2;
            buttonItems.Text = "Items";
            buttonItems.UseVisualStyleBackColor = true;
            buttonItems.Click += buttonItems_Click;
            // 
            // buttonMessages
            // 
            buttonMessages.Location = new Point(3, 216);
            buttonMessages.Name = "buttonMessages";
            buttonMessages.Size = new Size(96, 50);
            buttonMessages.TabIndex = 3;
            buttonMessages.Text = "Messages";
            buttonMessages.UseVisualStyleBackColor = true;
            buttonMessages.Click += buttonMessages_Click;
            // 
            // buttonValues
            // 
            buttonValues.Location = new Point(3, 272);
            buttonValues.Name = "buttonValues";
            buttonValues.Size = new Size(96, 50);
            buttonValues.TabIndex = 4;
            buttonValues.Text = "Values";
            buttonValues.UseVisualStyleBackColor = true;
            buttonValues.Click += buttonValues_Click;
            // 
            // buttonVocabulary
            // 
            buttonVocabulary.Location = new Point(3, 328);
            buttonVocabulary.Name = "buttonVocabulary";
            buttonVocabulary.Size = new Size(96, 50);
            buttonVocabulary.TabIndex = 5;
            buttonVocabulary.Text = "Vocabulary";
            buttonVocabulary.UseVisualStyleBackColor = true;
            buttonVocabulary.Click += buttonVocabulary_Click;
            // 
            // buttonCommands
            // 
            buttonCommands.Location = new Point(3, 384);
            buttonCommands.Name = "buttonCommands";
            buttonCommands.Size = new Size(96, 50);
            buttonCommands.TabIndex = 6;
            buttonCommands.Text = "Commands";
            buttonCommands.UseVisualStyleBackColor = true;
            buttonCommands.Click += buttonCommands_Click;
            // 
            // buttonSystem
            // 
            buttonSystem.Location = new Point(3, 552);
            buttonSystem.Name = "buttonSystem";
            buttonSystem.Size = new Size(96, 50);
            buttonSystem.TabIndex = 8;
            buttonSystem.Text = "System";
            buttonSystem.UseVisualStyleBackColor = true;
            buttonSystem.Click += buttonSystem_Click;
            // 
            // buttonScripts
            // 
            buttonScripts.Location = new Point(3, 440);
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
            groupBoxStart.Controls.Add(buttonVersionToday);
            groupBoxStart.Controls.Add(label5);
            groupBoxStart.Controls.Add(textBoxStartStartingRoom);
            groupBoxStart.Controls.Add(label4);
            groupBoxStart.Controls.Add(textBoxStartVersion);
            groupBoxStart.Controls.Add(textBoxStartIntroduction);
            groupBoxStart.Controls.Add(label3);
            groupBoxStart.Controls.Add(label2);
            groupBoxStart.Controls.Add(textBoxStartGameTitle);
            groupBoxStart.Controls.Add(label1);
            groupBoxStart.Controls.Add(textBoxStartGameName);
            groupBoxStart.Location = new Point(105, 40);
            groupBoxStart.Name = "groupBoxStart";
            groupBoxStart.Size = new Size(1066, 705);
            groupBoxStart.TabIndex = 10;
            groupBoxStart.TabStop = false;
            groupBoxStart.Text = "Start";
            // 
            // buttonVersionToday
            // 
            buttonVersionToday.Location = new Point(1007, 22);
            buttonVersionToday.Name = "buttonVersionToday";
            buttonVersionToday.Size = new Size(53, 23);
            buttonVersionToday.TabIndex = 12;
            buttonVersionToday.Text = "Today";
            buttonVersionToday.UseVisualStyleBackColor = true;
            buttonVersionToday.Click += buttonVersionToday_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 258);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 11;
            label5.Text = "Starting Room";
            // 
            // textBoxStartStartingRoom
            // 
            textBoxStartStartingRoom.Location = new Point(109, 255);
            textBoxStartStartingRoom.Name = "textBoxStartStartingRoom";
            textBoxStartStartingRoom.Size = new Size(205, 23);
            textBoxStartStartingRoom.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(814, 26);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 9;
            label4.Text = "Version";
            // 
            // textBoxStartVersion
            // 
            textBoxStartVersion.Location = new Point(865, 23);
            textBoxStartVersion.Name = "textBoxStartVersion";
            textBoxStartVersion.Size = new Size(136, 23);
            textBoxStartVersion.TabIndex = 8;
            // 
            // textBoxStartIntroduction
            // 
            textBoxStartIntroduction.Location = new Point(109, 82);
            textBoxStartIntroduction.Multiline = true;
            textBoxStartIntroduction.Name = "textBoxStartIntroduction";
            textBoxStartIntroduction.ScrollBars = ScrollBars.Vertical;
            textBoxStartIntroduction.Size = new Size(951, 167);
            textBoxStartIntroduction.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 85);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Introduction";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 54);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Game Title";
            // 
            // textBoxStartGameTitle
            // 
            textBoxStartGameTitle.Location = new Point(109, 51);
            textBoxStartGameTitle.Name = "textBoxStartGameTitle";
            textBoxStartGameTitle.Size = new Size(273, 23);
            textBoxStartGameTitle.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 25);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Game Name";
            // 
            // textBoxStartGameName
            // 
            textBoxStartGameName.Location = new Point(109, 22);
            textBoxStartGameName.Name = "textBoxStartGameName";
            textBoxStartGameName.Size = new Size(195, 23);
            textBoxStartGameName.TabIndex = 2;
            // 
            // groupBoxRooms
            // 
            groupBoxRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRooms.Location = new Point(105, 40);
            groupBoxRooms.Name = "groupBoxRooms";
            groupBoxRooms.Size = new Size(1066, 705);
            groupBoxRooms.TabIndex = 11;
            groupBoxRooms.TabStop = false;
            groupBoxRooms.Text = "Rooms";
            groupBoxRooms.Visible = false;
            // 
            // groupBoxItems
            // 
            groupBoxItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxItems.Location = new Point(105, 40);
            groupBoxItems.Name = "groupBoxItems";
            groupBoxItems.Size = new Size(1066, 705);
            groupBoxItems.TabIndex = 12;
            groupBoxItems.TabStop = false;
            groupBoxItems.Text = "Items";
            groupBoxItems.Visible = false;
            // 
            // groupBoxMessages
            // 
            groupBoxMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMessages.Location = new Point(105, 40);
            groupBoxMessages.Name = "groupBoxMessages";
            groupBoxMessages.Size = new Size(1066, 705);
            groupBoxMessages.TabIndex = 13;
            groupBoxMessages.TabStop = false;
            groupBoxMessages.Text = "Messages";
            groupBoxMessages.Visible = false;
            // 
            // groupBoxValues
            // 
            groupBoxValues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxValues.Location = new Point(105, 40);
            groupBoxValues.Name = "groupBoxValues";
            groupBoxValues.Size = new Size(1066, 705);
            groupBoxValues.TabIndex = 14;
            groupBoxValues.TabStop = false;
            groupBoxValues.Text = "Values";
            groupBoxValues.Visible = false;
            // 
            // groupBoxVocabulary
            // 
            groupBoxVocabulary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxVocabulary.Location = new Point(105, 40);
            groupBoxVocabulary.Name = "groupBoxVocabulary";
            groupBoxVocabulary.Size = new Size(1066, 705);
            groupBoxVocabulary.TabIndex = 15;
            groupBoxVocabulary.TabStop = false;
            groupBoxVocabulary.Text = "Vocabulary";
            groupBoxVocabulary.Visible = false;
            // 
            // groupBoxCommands
            // 
            groupBoxCommands.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCommands.Location = new Point(105, 40);
            groupBoxCommands.Name = "groupBoxCommands";
            groupBoxCommands.Size = new Size(1066, 705);
            groupBoxCommands.TabIndex = 16;
            groupBoxCommands.TabStop = false;
            groupBoxCommands.Text = "Commands";
            groupBoxCommands.Visible = false;
            // 
            // groupBoxScripts
            // 
            groupBoxScripts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxScripts.Location = new Point(105, 40);
            groupBoxScripts.Name = "groupBoxScripts";
            groupBoxScripts.Size = new Size(1066, 705);
            groupBoxScripts.TabIndex = 17;
            groupBoxScripts.TabStop = false;
            groupBoxScripts.Text = "Scripts";
            groupBoxScripts.Visible = false;
            // 
            // groupBoxSystem
            // 
            groupBoxSystem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSystem.Location = new Point(105, 40);
            groupBoxSystem.Name = "groupBoxSystem";
            groupBoxSystem.Size = new Size(1066, 705);
            groupBoxSystem.TabIndex = 18;
            groupBoxSystem.TabStop = false;
            groupBoxSystem.Text = "System";
            groupBoxSystem.Visible = false;
            // 
            // panelToolbar
            // 
            panelToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelToolbar.Controls.Add(buttonFileSave);
            panelToolbar.Controls.Add(buttonFileOpen);
            panelToolbar.Controls.Add(buttonFileNew);
            panelToolbar.Location = new Point(0, 0);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(1184, 34);
            panelToolbar.TabIndex = 19;
            // 
            // buttonFileSave
            // 
            buttonFileSave.Location = new Point(159, 0);
            buttonFileSave.Name = "buttonFileSave";
            buttonFileSave.Size = new Size(72, 34);
            buttonFileSave.TabIndex = 2;
            buttonFileSave.Text = "Save";
            buttonFileSave.UseVisualStyleBackColor = true;
            // 
            // buttonFileOpen
            // 
            buttonFileOpen.Location = new Point(81, 0);
            buttonFileOpen.Name = "buttonFileOpen";
            buttonFileOpen.Size = new Size(72, 34);
            buttonFileOpen.TabIndex = 1;
            buttonFileOpen.Text = "Open";
            buttonFileOpen.UseVisualStyleBackColor = true;
            // 
            // buttonFileNew
            // 
            buttonFileNew.Location = new Point(3, 0);
            buttonFileNew.Name = "buttonFileNew";
            buttonFileNew.Size = new Size(72, 34);
            buttonFileNew.TabIndex = 0;
            buttonFileNew.Text = "New";
            buttonFileNew.UseVisualStyleBackColor = true;
            // 
            // buttonFunctions
            // 
            buttonFunctions.Location = new Point(3, 496);
            buttonFunctions.Name = "buttonFunctions";
            buttonFunctions.Size = new Size(96, 50);
            buttonFunctions.TabIndex = 21;
            buttonFunctions.Text = "Functions";
            buttonFunctions.UseVisualStyleBackColor = true;
            buttonFunctions.Click += buttonFunctions_Click;
            // 
            // groupBoxFunctions
            // 
            groupBoxFunctions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFunctions.Location = new Point(105, 40);
            groupBoxFunctions.Name = "groupBoxFunctions";
            groupBoxFunctions.Size = new Size(1066, 705);
            groupBoxFunctions.TabIndex = 22;
            groupBoxFunctions.TabStop = false;
            groupBoxFunctions.Text = "Functions";
            groupBoxFunctions.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 757);
            Controls.Add(groupBoxFunctions);
            Controls.Add(buttonFunctions);
            Controls.Add(panelToolbar);
            Controls.Add(buttonSystem);
            Controls.Add(buttonScripts);
            Controls.Add(buttonCommands);
            Controls.Add(buttonVocabulary);
            Controls.Add(buttonValues);
            Controls.Add(buttonMessages);
            Controls.Add(buttonItems);
            Controls.Add(buttonRooms);
            Controls.Add(buttonStart);
            Controls.Add(groupBoxSystem);
            Controls.Add(groupBoxScripts);
            Controls.Add(groupBoxCommands);
            Controls.Add(groupBoxVocabulary);
            Controls.Add(groupBoxValues);
            Controls.Add(groupBoxMessages);
            Controls.Add(groupBoxItems);
            Controls.Add(groupBoxRooms);
            Controls.Add(groupBoxStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zygote";
            groupBoxStart.ResumeLayout(false);
            groupBoxStart.PerformLayout();
            panelToolbar.ResumeLayout(false);
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
        private Panel panelToolbar;
        private Button buttonFileSave;
        private Button buttonFileOpen;
        private Button buttonFileNew;
        private TextBox textBoxStartGameName;
        private TextBox textBoxStartIntroduction;
        private Label label3;
        private Label label2;
        private TextBox textBoxStartGameTitle;
        private Label label1;
        private Label label4;
        private TextBox textBoxStartVersion;
        private Label label5;
        private TextBox textBoxStartStartingRoom;
        private Button buttonVersionToday;
        private Button buttonFunctions;
        private GroupBox groupBoxFunctions;
    }
}
