using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._3
{
    public class HillClimbingSolver
    {
        private NgramScorer scorer;
        private Random random = new Random();
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public HillClimbingSolver(NgramScorer scorer)
        {
            this.scorer = scorer;
        }

        public (string bestKey, string bestPlaintext, double bestScore) Solve(
            string ciphertext,
            int restarts = 10,
            IProgress<(int step, string key, string plaintext, double score)> progress = null,
            CancellationToken cancellationToken = default)
        {
            string globalBestKey = ALPHABET;
            double globalBestScore = double.MinValue;
            string normCipher = CipherProcessor.Normalize(ciphertext);

            for (int i = 0; i < restarts; i++)
            {
                //Ktra nút stop
                cancellationToken.ThrowIfCancellationRequested();

                string currentKey = ShuffleString(ALPHABET);
                string currentPlaintext = CipherProcessor.Decrypt(normCipher, currentKey);
                double currentScore = scorer.Score(currentPlaintext);
                bool improved = true;

                while (improved)
                {
                    improved = false;
                    for (int j = 0; j < 25; j++)
                    {
                        for (int k = j + 1; k < 26; k++)
                        {
                            string testKey = SwapChars(currentKey, j, k);
                            string testPlaintext = CipherProcessor.Decrypt(normCipher, testKey);
                            double testScore = scorer.Score(testPlaintext);

                            if (testScore > currentScore)
                            {
                                currentScore = testScore;
                                currentKey = testKey;
                                improved = true;
                            }
                        }
                    }
                }

                if (currentScore > globalBestScore)
                {
                    globalBestScore = currentScore;
                    globalBestKey = currentKey;
                }

                // BÁO CÁO TIẾN ĐỘ SAU MỖI VÒNG LẶP
                if (progress != null)
                {
                    string tempPlaintext = CipherProcessor.Decrypt(ciphertext, globalBestKey);
                    progress.Report((i + 1, globalBestKey, tempPlaintext, globalBestScore));
                }
            }

            string finalPlaintext = CipherProcessor.Decrypt(ciphertext, globalBestKey);
            return (globalBestKey, finalPlaintext, globalBestScore);
        }

        // Hàm hỗ trợ xáo trộn chuỗi
        private string ShuffleString(string str)
        {
            char[] array = str.ToCharArray();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = array[i]; array[i] = array[j]; array[j] = temp;
            }
            return new string(array);
        }

        // Hàm hỗ trợ hoán đổi 2 ký tự trong chuỗi
        private string SwapChars(string str, int index1, int index2)
        {
            char[] chars = str.ToCharArray();
            char temp = chars[index1];
            chars[index1] = chars[index2];
            chars[index2] = temp;
            return new string(chars);
        }
    }
}
