namespace WinFormsApp3
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
            components = new System.ComponentModel.Container();
            gamePanel = new Panel();
            scoreLable = new Label();
            trapsLable = new Label();
            startButton = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.Gainsboro;
            gamePanel.Location = new Point(353, 38);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(400, 400);
            gamePanel.TabIndex = 0;
            gamePanel.Paint += gamePanel_Paint;
            // 
            // scoreLable
            // 
            scoreLable.AutoSize = true;
            scoreLable.Location = new Point(125, 38);
            scoreLable.Name = "scoreLable";
            scoreLable.Size = new Size(38, 15);
            scoreLable.TabIndex = 1;
            scoreLable.Text = "label1";
            // 
            // trapsLable
            // 
            trapsLable.AutoSize = true;
            trapsLable.Location = new Point(125, 94);
            trapsLable.Name = "trapsLable";
            trapsLable.Size = new Size(38, 15);
            trapsLable.TabIndex = 2;
            trapsLable.Text = "label2";
            // 
            // startButton
            // 
            startButton.Location = new Point(112, 295);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 3;
            startButton.Text = "button1";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 60;
            gameTimer.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startButton);
            Controls.Add(trapsLable);
            Controls.Add(scoreLable);
            Controls.Add(gamePanel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel gamePanel;
        private Label scoreLable;
        private Label trapsLable;
        private Button startButton;
        private System.Windows.Forms.Timer gameTimer;
    }
}
