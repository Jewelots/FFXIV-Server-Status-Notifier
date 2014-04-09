namespace FFXIVServerStatusNotifier
{
    partial class SettingsForm
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
            this.serverSelectBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkDelayBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverSelectBox
            // 
            this.serverSelectBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serverSelectBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.serverSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverSelectBox.FormattingEnabled = true;
            this.serverSelectBox.Location = new System.Drawing.Point(87, 6);
            this.serverSelectBox.Name = "serverSelectBox";
            this.serverSelectBox.Size = new System.Drawing.Size(133, 21);
            this.serverSelectBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 60);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(205, 59);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Name:";
            // 
            // checkDelayBox
            // 
            this.checkDelayBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.checkDelayBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.checkDelayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkDelayBox.FormattingEnabled = true;
            this.checkDelayBox.Location = new System.Drawing.Point(87, 33);
            this.checkDelayBox.Name = "checkDelayBox";
            this.checkDelayBox.Size = new System.Drawing.Size(133, 21);
            this.checkDelayBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check Delay:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 127);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkDelayBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.serverSelectBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_Closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox serverSelectBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox checkDelayBox;
        private System.Windows.Forms.Label label2;

    }
}