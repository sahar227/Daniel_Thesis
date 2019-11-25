using DBModel.Trail;
using System;

namespace DBModel.QuestionModels
{
    public abstract class Question : DBModel
    {
        public int UserId { get; set; }
        public string AskedQuestion { get; set; }
        public string SoundPath { get; set; }
        public bool ExpectedAnswer { get; set; }
        public bool UserAnswer { get; set; }
        public TimeSpan AnswerTime { get; set; }

        protected Question(int userId, string askedQuestion, string sound, bool expectedAnswer)
        {
            AskedQuestion = askedQuestion;
            ExpectedAnswer = expectedAnswer;
            UserId = userId;
            SoundPath = sound;
        }


        
    }
}
