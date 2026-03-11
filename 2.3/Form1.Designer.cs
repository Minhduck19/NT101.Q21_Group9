namespace _2._3
{
    partial class Form1
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
            this.Ciphertext = new System.Windows.Forms.RichTextBox();
            this.Plaintext = new System.Windows.Forms.RichTextBox();
            this.loadfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Algorithm = new System.Windows.Forms.ComboBox();
            this.nudRestarts = new System.Windows.Forms.NumericUpDown();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.bestkey = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.close = new System.Windows.Forms.Button();
            this.Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestarts)).BeginInit();
            this.SuspendLayout();
            // 
            // Ciphertext
            // 
            this.Ciphertext.Location = new System.Drawing.Point(17, 63);
            this.Ciphertext.Name = "Ciphertext";
            this.Ciphertext.Size = new System.Drawing.Size(331, 336);
            this.Ciphertext.TabIndex = 0;
            this.Ciphertext.Text = "";
            // 
            // Plaintext
            // 
            this.Plaintext.Location = new System.Drawing.Point(590, 63);
            this.Plaintext.Name = "Plaintext";
            this.Plaintext.Size = new System.Drawing.Size(331, 336);
            this.Plaintext.TabIndex = 1;
            this.Plaintext.Text = "";
            // 
            // loadfile
            // 
            this.loadfile.Location = new System.Drawing.Point(17, 405);
            this.loadfile.Name = "loadfile";
            this.loadfile.Size = new System.Drawing.Size(137, 31);
            this.loadfile.TabIndex = 2;
            this.loadfile.Text = "Load file";
            this.loadfile.UseVisualStyleBackColor = true;
            this.loadfile.Click += new System.EventHandler(this.loadfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ciphertext";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(607, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plaintext";
            // 
            // Algorithm
            // 
            this.Algorithm.FormattingEnabled = true;
            this.Algorithm.Items.AddRange(new object[] {
            "Random Restart Hill Climbing",
            "Simulated Annealing"});
            this.Algorithm.Location = new System.Drawing.Point(160, 10);
            this.Algorithm.Margin = new System.Windows.Forms.Padding(2);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(273, 21);
            this.Algorithm.TabIndex = 6;
            // 
            // nudRestarts
            // 
            this.nudRestarts.Location = new System.Drawing.Point(460, 11);
            this.nudRestarts.Margin = new System.Windows.Forms.Padding(2);
            this.nudRestarts.Name = "nudRestarts";
            this.nudRestarts.Size = new System.Drawing.Size(154, 20);
            this.nudRestarts.TabIndex = 7;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(397, 90);
            this.start.Margin = new System.Windows.Forms.Padding(2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(137, 48);
            this.start.TabIndex = 8;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(397, 177);
            this.stop.Margin = new System.Windows.Forms.Padding(2);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(137, 48);
            this.stop.TabIndex = 9;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // bestkey
            // 
            this.bestkey.Location = new System.Drawing.Point(283, 470);
            this.bestkey.Margin = new System.Windows.Forms.Padding(2);
            this.bestkey.Multiline = true;
            this.bestkey.Name = "bestkey";
            this.bestkey.Size = new System.Drawing.Size(402, 175);
            this.bestkey.TabIndex = 10;
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(24, 470);
            this.log.Margin = new System.Windows.Forms.Padding(2);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(175, 173);
            this.log.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(371, 252);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(192, 35);
            this.progressBar1.TabIndex = 12;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.close.Location = new System.Drawing.Point(826, 13);
            this.close.Margin = new System.Windows.Forms.Padding(2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(104, 37);
            this.close.TabIndex = 13;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(283, 436);
            this.Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(65, 13);
            this.Score.TabIndex = 14;
            this.Score.Text = "Số thống kê";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 668);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.close);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.bestkey);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.nudRestarts);
            this.Controls.Add(this.Algorithm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadfile);
            this.Controls.Add(this.Plaintext);
            this.Controls.Add(this.Ciphertext);
            this.Name = "Form1";
            this.Text = "Bài 2.3";
            ((System.ComponentModel.ISupportInitialize)(this.nudRestarts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Ciphertext;
        private System.Windows.Forms.RichTextBox Plaintext;
        private System.Windows.Forms.Button loadfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Algorithm;
        private System.Windows.Forms.NumericUpDown nudRestarts;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox bestkey;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label Score;
    }
}

