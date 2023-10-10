namespace DDSMassCompressor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            outputConsoleTextBox = new System.Windows.Forms.RichTextBox();
            inputPathTextBox = new System.Windows.Forms.TextBox();
            startButton = new System.Windows.Forms.Button();
            selectFileButton = new System.Windows.Forms.Button();
            comboBoxCompressionMode = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            comboBoxMipMaps = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            comboBoxSaveMode = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            buttonClearConsole = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // outputConsoleTextBox
            // 
            outputConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            outputConsoleTextBox.Location = new System.Drawing.Point(12, 174);
            outputConsoleTextBox.Name = "outputConsoleTextBox";
            outputConsoleTextBox.Size = new System.Drawing.Size(491, 275);
            outputConsoleTextBox.TabIndex = 1;
            outputConsoleTextBox.Text = "";
            // 
            // inputPathTextBox
            // 
            inputPathTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            inputPathTextBox.Location = new System.Drawing.Point(38, 26);
            inputPathTextBox.Name = "inputPathTextBox";
            inputPathTextBox.Size = new System.Drawing.Size(316, 23);
            inputPathTextBox.TabIndex = 0;
            // 
            // startButton
            // 
            startButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            startButton.Location = new System.Drawing.Point(360, 25);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(143, 24);
            startButton.TabIndex = 2;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += OnStartButton_Clicked;
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new System.Drawing.Point(12, 26);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new System.Drawing.Size(20, 23);
            selectFileButton.TabIndex = 3;
            selectFileButton.Text = "🔍";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += OnSelectFileButton_Clicked;
            // 
            // comboBoxCompressionMode
            // 
            comboBoxCompressionMode.FormattingEnabled = true;
            comboBoxCompressionMode.Location = new System.Drawing.Point(146, 72);
            comboBoxCompressionMode.Name = "comboBoxCompressionMode";
            comboBoxCompressionMode.Size = new System.Drawing.Size(208, 23);
            comboBoxCompressionMode.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(128, 19);
            label1.TabIndex = 5;
            label1.Text = "Compression mode";
            // 
            // comboBoxMipMaps
            // 
            comboBoxMipMaps.FormattingEnabled = true;
            comboBoxMipMaps.Location = new System.Drawing.Point(146, 101);
            comboBoxMipMaps.Name = "comboBoxMipMaps";
            comboBoxMipMaps.Size = new System.Drawing.Size(208, 23);
            comboBoxMipMaps.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 105);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 19);
            label2.TabIndex = 5;
            label2.Text = "Mipmaps";
            // 
            // comboBoxSaveMode
            // 
            comboBoxSaveMode.FormattingEnabled = true;
            comboBoxSaveMode.Location = new System.Drawing.Point(146, 130);
            comboBoxSaveMode.Name = "comboBoxSaveMode";
            comboBoxSaveMode.Size = new System.Drawing.Size(208, 23);
            comboBoxSaveMode.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(12, 134);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 19);
            label3.TabIndex = 5;
            label3.Text = "Save mode";
            // 
            // buttonClearConsole
            // 
            buttonClearConsole.Location = new System.Drawing.Point(483, 145);
            buttonClearConsole.Name = "buttonClearConsole";
            buttonClearConsole.Size = new System.Drawing.Size(20, 23);
            buttonClearConsole.TabIndex = 6;
            buttonClearConsole.Text = "⎚";
            buttonClearConsole.UseVisualStyleBackColor = true;
            buttonClearConsole.Click += buttonClearConsole_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(12, 455);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(491, 23);
            progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(515, 490);
            Controls.Add(progressBar1);
            Controls.Add(buttonClearConsole);
            Controls.Add(label3);
            Controls.Add(comboBoxSaveMode);
            Controls.Add(label2);
            Controls.Add(comboBoxMipMaps);
            Controls.Add(label1);
            Controls.Add(comboBoxCompressionMode);
            Controls.Add(selectFileButton);
            Controls.Add(startButton);
            Controls.Add(outputConsoleTextBox);
            Controls.Add(inputPathTextBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "DDS Mass Compressor";
            Load += OnFormLoaded;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.RichTextBox outputConsoleTextBox;
        private System.Windows.Forms.TextBox inputPathTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.ComboBox comboBoxCompressionMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMipMaps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSaveMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClearConsole;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
