using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStuff
{
    class LeviAnna
    {
        
        public static void Main()
        {
            SpellChecker spellChecker = new SpellChecker(LoadWords("en_US.dic"),LevenstienGuy.LevenshteinDistance);
            HashSet<string> mWords = LoadWords("input.txt");
            //foreach (string word in mWords)
            Parallel.ForEach<string>(mWords, word =>
            {
                List<string> correctWords = spellChecker.ClosestMatch(word);
                Console.WriteLine(word);
                foreach (var correctWord in correctWords)
                {
                    Console.WriteLine("\t" + correctWord);
                }
            });
        }

        public static HashSet<string> LoadWords(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            HashSet<string> words = new HashSet<string>();
            while(!reader.EndOfStream)
            {
                words.Add(reader.ReadLine().ToLower());
            }
            return words;
        }
    }

    public class SpellChecker
    {
        HashSet<string> words;
        MeasureCloseness measureCloseness;
        public SpellChecker(HashSet<string> words,MeasureCloseness measureCloseness) {
            this.words= words;
            this.measureCloseness= measureCloseness;
        }
        /// <summary>
        /// Gives one word if the word exists in the dictionary. Gives upto 10 closest words if word not found.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<string> ClosestMatch(string word)
        {
            if(words.Contains(word))return new List<string>() { word };
            List<WordCloseness> wordClosenesses = new List<WordCloseness>();
            //foreach(var existingWord in words)
            Parallel.ForEach<string>(words, existingWord =>
            {
                double closeness = measureCloseness(word, existingWord);
                lock (wordClosenesses) {
                    wordClosenesses.Add(new WordCloseness()
                    {
                        word = existingWord,
                        closeness =closeness
                    });
                }
            });
            wordClosenesses.Sort();
            List<string> closeWords = new List<string>();
            for(int i = 0; i < 10 && i < wordClosenesses.Count; i++)
            {
                closeWords.Add(wordClosenesses[i].word);
            }
            return closeWords;
        }
    }

    public delegate double MeasureCloseness(string a,string b);

    public class WordCloseness : IComparable<WordCloseness> 
    {
        public string word;
        public double closeness;
        public int CompareTo(WordCloseness other)
        {
            return Math.Sign(closeness-other.closeness);
        }
    }
    public static class LevenstienGuy
    {
        public static double LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

    }
}
 