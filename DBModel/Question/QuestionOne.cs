using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Question
{
    public class QuestionOne
    {
        public TrailOne TrailDetails { get; private set; }
        public char LetterInQuestion { get; private set; }
        public bool ExpectedAnswer { get; private set; }
        public TimeSpan AnswerTime { get; set; }
        public bool UserAnswer { get; set; }

        private Random rng = new Random();

        public static List<char> AllKnownLetters = new List<char>();
        private static Dictionary<string, List<char>> DistinctCharPerWord = new Dictionary<string, List<char>>();
        private static Dictionary<string, List<char>> DistinctCharNotInWord = new Dictionary<string, List<char>>();


        public QuestionOne(TrailOne trailOne, bool expectedAnswer)
        {
            TrailDetails = trailOne;
            ExpectedAnswer = expectedAnswer;
            
            LetterInQuestion = SetLetterInQuestion(trailOne.Title, ExpectedAnswer);

        }

        private char SetLetterInQuestion(string word, bool expectedAnswer)
        {
            BreakdownLettersAndCache(word);

            if (expectedAnswer)
                return SetLetterFromWord(word);
            return SetLetterExcludedFromWord(word);
        }

        private static void BreakdownLettersAndCache(string word)
        {
            if (!DistinctCharPerWord.TryGetValue(word, out var distinctChars))
                DistinctCharPerWord.Add(word, word.Distinct().ToList());

            if (!DistinctCharNotInWord.TryGetValue(word, out var distinctCharsNotinWord))
                DistinctCharNotInWord.Add(word, AllKnownLetters.Except(word).ToList());
        }

        private char SetLetterExcludedFromWord(string word)
        {
            List<char> characters = DistinctCharNotInWord[word];
            return characters[rng.Next(characters.Count())];
        }

        private char SetLetterFromWord(string word)
        {
            var characters = DistinctCharPerWord[word];
            return characters[rng.Next(characters.Count())];
        }
    }
}
