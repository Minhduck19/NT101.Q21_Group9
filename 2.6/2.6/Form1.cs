using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void analyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cipher.Text))
            {
                MessageBox.Show("Vui lòng nhập văn bản mã hóa vào ô Cipher Text.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Vigenere breaker = new Vigenere();

            // 1. Phá mã để tìm khóa
            string foundKey = breaker.BreakVigenere(cipher.Text);
            Key.Text = foundKey;

            // 2. Dùng khóa vừa tìm được để giải mã toàn bộ văn bản (giữ nguyên định dạng)
            string decodedText = breaker.Decrypt(cipher.Text, foundKey);
            plain.Text = decodedText;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cipher.Clear();
            Key.Clear();
            plain.Clear();
        }
    }
}
