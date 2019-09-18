using DBModel.Trail;
using System;

namespace DBModel.QuestionModels
{
    public abstract class Question
    {
        public string AskedQuestion { get; }
        public bool ExpectedAnswer { get; }
        public bool UserAnswer { get; set; }
        public TimeSpan AnswerTime { get; set; }

        public Question(string subject, bool expectedAnswer)
        {
            AskedQuestion = subject;
            ExpectedAnswer = expectedAnswer;
        }


        
    }
}
