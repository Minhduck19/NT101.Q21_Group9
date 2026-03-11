using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2._3
{
    public partial class Form1 : Form
    {
        private NgramScorer scorer;
        private CancellationTokenSource cts;
        public Form1()
        {
            InitializeComponent();
            scorer = new NgramScorer();
            
            try
            {
                scorer.LoadNgrams("english-quadgrams.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải từ điển: " + ex.Message);
            }
            if (Algorithm.Items.Count > 0) Algorithm.SelectedIndex = 0;
            nudRestarts.Value = 10;
            stop.Enabled = false; // ch chạy thì ko cho bấm stop
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void  start_Click(object sender, EventArgs e)
        {
            string ciphertext = Ciphertext.Text;
            if (string.IsNullOrWhiteSpace(ciphertext))
            {
                MessageBox.Show("Vui lòng nhập văn bản mã hóa!");
                return;
            }

            int restarts = (int)nudRestarts.Value;

            start.Enabled = false;
            stop.Enabled = true;
            progressBar1.Maximum = restarts;
            progressBar1.Value = 0;
            log.Items.Clear();
            log.Items.Add("Bắt đầu giải mã...");

            cts = new CancellationTokenSource();

            //Khởi tạo bộ thu thập báo cáo tiến độ từ Thuật toán
            var progress = new Progress<(int step, string key, string plaintext, double score)>(report =>
            {
                progressBar1.Value = report.step;
                bestkey.Text = report.key;
                Plaintext.Text = report.plaintext;
                Score.Text = $"Score: {report.score:F2}";

                
                log.Items.Add($"Lần lặp {report.step}/{restarts}: Điểm tốt nhất {report.score:F2}");
                log.TopIndex = log.Items.Count - 1;
            });

            try
            {
                var solver = new HillClimbingSolver(scorer);

                // 4. BẮT ĐẦU CHẠY THUẬT TOÁN Ở LUỒNG NGẦM (BACKGROUND THREAD)
                var result = await Task.Run(() =>
                    solver.Solve(ciphertext, restarts, progress, cts.Token)
                );

                log.Items.Add("HOÀN TẤT GIẢI MÃ!");
            }
            catch (OperationCanceledException)
            {
                // Bắt lỗi nếu người dùng bấm nút Stop
                log.Items.Add("--- ĐÃ DỪNG BỞI NGƯỜI DÙNG ---");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // 5. Khôi phục lại trạng thái các nút bấm sau khi chạy xong hoặc bị dừng
                start.Enabled = true;
                stop.Enabled = false;
                cts.Dispose();
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel(); //phát tín hiệu dừng 
                stop.Enabled = false;
                stop.Text = "Đang dừng...";
            }
        }

        private void loadfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Ciphertext.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
