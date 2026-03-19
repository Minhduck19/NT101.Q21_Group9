using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6
{
    public class Vigenere
    {
        //tần suất xuất hiện
        // Tần suất xuất hiện chữ cái tiếng Anh chuẩn (A-Z)
        private static readonly double[] EnglishFreq = {
        0.0817, 0.0150, 0.0278, 0.0425, 0.1270, 0.0223, 0.0202, 0.0609, 0.0697,
        0.0015, 0.0077, 0.0403, 0.0241, 0.0675, 0.0751, 0.0193, 0.0010, 0.0599,
        0.0633, 0.0906, 0.0276, 0.0098, 0.0236, 0.0015, 0.0197, 0.0007
    };

        public string BreakVigenere(string ciphertext)
        {
            string cleaned = new string(ciphertext.Where(char.IsLetter).ToArray()).ToUpper();
            if (cleaned.Length == 0) return "";

            int bestKeyLength = 1;
            double minDiff = double.MaxValue;

            //Giới hạn độ dài khóa để tránh sai số (không quá 1/10, tối đa là 20)
            int maxKeyToTest = Math.Min(20, cleaned.Length / 10);
            if (maxKeyToTest < 1) maxKeyToTest = 1;

            // Tìm độ dài khóa tối ưu
            for (int m = 1; m <= maxKeyToTest; m++)
            {
                double currentIC = CalculateAverageIC(cleaned, m);

                //Nếu IC vượt ngưỡng tiếng Anh chuẩn khoảng 0,058 thì lấy nó
                if (currentIC >= 0.058)
                {
                    bestKeyLength = m;
                    break;
                }

                //Nếu không có cái nào qua ngưỡng thì lấy cái 0,0667 gần nhất
                if (Math.Abs(currentIC - 0.0667) < minDiff)
                {
                    minDiff = Math.Abs(currentIC - 0.0667);
                    bestKeyLength = m;
                }
            }

            //Tìm từng ký tự của khóa bằng Frequency Analysis
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < bestKeyLength; i++)
            {
                string subseq = GetSubsequence(cleaned, i, bestKeyLength);
                key.Append(FindBestShift(subseq));
            }

            return key.ToString();
        }

        private double CalculateAverageIC(string text, int m)
        {
            double sumIC = 0;
            for (int i = 0; i < m; i++)
            {
                string sub = GetSubsequence(text, i, m);
                sumIC += GetIC(sub);
            }
            return sumIC / m;
        }

        private double GetIC(string s)
        {
            if (s.Length <= 1) return 0;
            int[] counts = new int[26];
            foreach (char c in s) counts[c - 'A']++;

            double ic = 0;
            foreach (int count in counts)
                ic += (double)count * (count - 1);

            return ic / (s.Length * (s.Length - 1));
        }

        private string GetSubsequence(string text, int start, int step)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < text.Length; i += step)
                sb.Append(text[i]);
            return sb.ToString();
        }

        private char FindBestShift(string subseq)
        {
            double minChiSq = double.MaxValue;
            int bestShift = 0;

            for (int shift = 0; shift < 26; shift++)
            {
                double chiSq = CalculateChiSquare(subseq, shift);
                if (chiSq < minChiSq)
                {
                    minChiSq = chiSq;
                    bestShift = shift;
                }
            }
            return (char)('A' + bestShift);
        }

        private double CalculateChiSquare(string s, int shift)
        {
            int[] counts = new int[26];
            foreach (char c in s)
            {
                int index = (c - 'A' - shift + 26) % 26;
                counts[index]++;
            }

            double chiSq = 0;
            for (int i = 0; i < 26; i++)
            {
                double expected = s.Length * EnglishFreq[i];
                chiSq += Math.Pow(counts[i] - expected, 2) / expected;
            }
            return chiSq;
        }
        public string Decrypt(string ciphertext, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;
            key = key.ToUpper();

            foreach (char c in ciphertext)
            {
                if (char.IsLetter(c))
                {
                    bool isUpper = char.IsUpper(c);
                    int cIndex = char.ToUpper(c) - 'A';
                    int kIndex = key[keyIndex % key.Length] - 'A';

                    //Công thức: P = (C - K + 26) mod 26
                    int pIndex = (cIndex - kIndex + 26) % 26;
                    char pChar = (char)(pIndex + 'A');

                    result.Append(isUpper ? pChar : char.ToLower(pChar));
                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
