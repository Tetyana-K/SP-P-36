namespace Stop_thread__WinForms_
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
            listBox1 = new ListBox();
            btnStart = new Button();
            btnStop = new Button();
            btnPause = new Button();
            btnResume = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(194, 50);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(385, 169);
            listBox1.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(194, 249);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(159, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Thread";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(420, 249);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(159, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop Thread";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(194, 322);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(159, 23);
            btnPause.TabIndex = 3;
            btnPause.Text = "Pause Thread";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(420, 322);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(159, 23);
            btnResume.TabIndex = 4;
            btnResume.Text = "Resume Thread";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += btnResume_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnResume);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button btnStart;
        private Button btnStop;
        private Button btnPause;
        private Button btnResume;
    }
}
