using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2._3
{
    public class NgramScorer
    {
        private Dictionary<string, double> ngrams = new Dictionary<string, double>();
        private double floorValue = 0;
        private int ngramLength = 4; // Mặc định dùng Quadgram

        // Đọc file n-gram và tính toán log xác suất
        public void LoadNgrams(string filePath)
        {
            long totalNgrams = 0;
            var tempDict = new Dictionary<string, long>();

            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(' ');
                if (parts.Length == 2)
                {
                    string ngram = parts[0];
                    long count = long.Parse(parts[1]);
                    tempDict[ngram] = count;
                    totalNgrams += count;
                }
            }

            // Tính log xác suất để tránh underflow khi nhân các xác suất nhỏ
            foreach (var kvp in tempDict)
            {
                ngrams[kvp.Key] = Math.Log10((double)kvp.Value / totalNgrams);
            }

            // Giá trị phạt nếu n-gram không tồn tại trong từ điển
            floorValue = Math.Log10(0.01 / totalNgrams);
        }

        // Tính điểm của một đoạn văn bản
        public double Score(string text)
        {
            double score = 0;
            for (int i = 0; i <= text.Length - ngramLength; i++)
            {
                string ngram = text.Substring(i, ngramLength);
                if (ngrams.ContainsKey(ngram))
                    score += ngrams[ngram];
                else
                    score += floorValue;
            }
            return score;
        }
    }
}
