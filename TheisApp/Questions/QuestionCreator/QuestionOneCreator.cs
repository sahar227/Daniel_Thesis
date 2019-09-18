using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.QuestionModels;
using DBModel.Trail;

namespace TheisApp.Questions.QuestionCreator
{
    public class QuestionOneCreator : IQuestionCreator<QuestionOne, TrailOne>
    {
        private class DistinctCharForWord
        {
            public DistinctCharForWord(string word)
            {
                DistinctCharInWord = word.Distinct().ToList();
                DistinctCharNotInWord = AllKnownLetters.Except(word).ToList();
            }
            public List<char> DistinctCharInWord;
            public List<char> DistinctCharNotInWord;
        }
        private static readonly Dictionary<string, DistinctCharForWord> m_distinctCharForWord = new Dictionary<string, DistinctCharForWord>();

        private readonly Random m_rng = new Random();

        // TODO: Move this to trailManager project and save list in db
        public static List<char> AllKnownLetters = new List<char>();


        public QuestionOne CreateNoQuestion(TrailOne trail)
        {
            return CreateQuestion(trail, expectedAnswer: false);
        }

        public QuestionOne CreateYesQuestion(TrailOne trail)
        {
            return CreateQuestion(trail, expectedAnswer: true);
        }

        // TODO: change to hebrew
        private string FormatQuestion(char questionSubject, string word)
        {
            return $"Does the letter {questionSubject} appear in the word {word}?";
        }

        private QuestionOne CreateQuestion(TrailOne trail, bool expectedAnswer)
        {
            BreakdownLettersAndCache(trail.Title);

            var questionSubject = SetLetterInQuestion(trail.Title, expectedAnswer);
            var question = FormatQuestion(questionSubject, trail.Title);

            return new QuestionOne(trail, question, expectedAnswer);
        }

        private char SetLetterInQuestion(string word, bool expectedAnswer)
        {

            if (expectedAnswer)
                return SetLetterFromWord(word);
            return SetLetterExcludedFromWord(word);
        }

        private static void BreakdownLettersAndCache(string word)
        {
            if (!m_distinctCharForWord.ContainsKey(word))
                m_distinctCharForWord.Add(word, new DistinctCharForWord(word));
        }

        private char SetLetterExcludedFromWord(string word)
        {
            var characters = m_distinctCharForWord[word].DistinctCharNotInWord;
            if (characters.Count != 0)
                return characters[m_rng.Next(characters.Count())];
            throw new ApplicationException($"Word {word} contains all known letters");
        }

        private char SetLetterFromWord(string word)
        {
            var characters = m_distinctCharForWord[word].DistinctCharInWord;
            return characters[m_rng.Next(characters.Count())];
        }
    }
}
