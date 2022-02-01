namespace CheckersSolver
{
    partial class MainClass
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainClass));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.SizeSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.firstTurnCheckBox = new System.Windows.Forms.CheckBox();
            this.visualizeCheckBox = new System.Windows.Forms.CheckBox();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(320, 320);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(257, 363);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 42);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "SOLVE!";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // SizeSelectionComboBox
            // 
            this.SizeSelectionComboBox.FormattingEnabled = true;
            this.SizeSelectionComboBox.Items.AddRange(new object[] {
            "4 x 4",
            "6 x 6",
            "8 x 8"});
            this.SizeSelectionComboBox.Location = new System.Drawing.Point(12, 363);
            this.SizeSelectionComboBox.Name = "SizeSelectionComboBox";
            this.SizeSelectionComboBox.Size = new System.Drawing.Size(121, 24);
            this.SizeSelectionComboBox.TabIndex = 2;
            this.SizeSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.SizeSelectionComboBox_SelectedIndexChanged);
            // 
            // firstTurnCheckBox
            // 
            this.firstTurnCheckBox.AutoSize = true;
            this.firstTurnCheckBox.Checked = true;
            this.firstTurnCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.firstTurnCheckBox.Location = new System.Drawing.Point(12, 396);
            this.firstTurnCheckBox.Name = "firstTurnCheckBox";
            this.firstTurnCheckBox.Size = new System.Drawing.Size(89, 21);
            this.firstTurnCheckBox.TabIndex = 4;
            this.firstTurnCheckBox.Text = "white first";
            this.firstTurnCheckBox.UseVisualStyleBackColor = true;
            // 
            // visualizeCheckBox
            // 
            this.visualizeCheckBox.AutoSize = true;
            this.visualizeCheckBox.Checked = true;
            this.visualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visualizeCheckBox.Location = new System.Drawing.Point(12, 417);
            this.visualizeCheckBox.Name = "visualizeCheckBox";
            this.visualizeCheckBox.Size = new System.Drawing.Size(84, 21);
            this.visualizeCheckBox.TabIndex = 4;
            this.visualizeCheckBox.Text = "visualize";
            this.visualizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(155, 417);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(47, 17);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "result:";
            // 
            // MainClass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(356, 453);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.visualizeCheckBox);
            this.Controls.Add(this.firstTurnCheckBox);
            this.Controls.Add(this.SizeSelectionComboBox);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainClass";
            this.Text = "XtremeCheckerSolver";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.ComboBox SizeSelectionComboBox;
        private System.Windows.Forms.CheckBox firstTurnCheckBox;
        private System.Windows.Forms.CheckBox visualizeCheckBox;
        private System.Windows.Forms.Label resultLabel;
    }
}

