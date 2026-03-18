namespace _2._6
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
            this.analyze = new System.Windows.Forms.Button();
            this.cipher = new System.Windows.Forms.RichTextBox();
            this.plain = new System.Windows.Forms.RichTextBox();
            this.Key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // analyze
            // 
            this.analyze.Location = new System.Drawing.Point(15, 358);
            this.analyze.Name = "analyze";
            this.analyze.Size = new System.Drawing.Size(136, 48);
            this.analyze.TabIndex = 0;
            this.analyze.Text = "Mã hóa";
            this.analyze.UseVisualStyleBackColor = true;
            this.analyze.Click += new System.EventHandler(this.analyze_Click);
            // 
            // cipher
            // 
            this.cipher.Location = new System.Drawing.Point(15, 38);
            this.cipher.Name = "cipher";
            this.cipher.Size = new System.Drawing.Size(299, 286);
            this.cipher.TabIndex = 1;
            this.cipher.Text = "";
            // 
            // plain
            // 
            this.plain.Location = new System.Drawing.Point(489, 38);
            this.plain.Name = "plain";
            this.plain.Size = new System.Drawing.Size(299, 286);
            this.plain.TabIndex = 2;
            this.plain.Text = "";
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(490, 358);
            this.Key.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Key.Multiline = true;
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(298, 46);
            this.Key.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ciphertext";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plaintext";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 358);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key tìm được";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(180, 358);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(133, 45);
            this.clear.TabIndex = 7;
            this.clear.Text = "Xóa";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.plain);
            this.Controls.Add(this.cipher);
            this.Controls.Add(this.analyze);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button analyze;
        private System.Windows.Forms.RichTextBox cipher;
        private System.Windows.Forms.RichTextBox plain;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clear;
    }
}

