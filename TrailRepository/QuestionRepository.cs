using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRepository
{
    public static class QuestionRepository
    {
        public static void SaveQuestionOnes(List<QuestionOne> questions)
        {
            using (var context = new SampleDBContext())
            {
                context.QuestionOnes.AddRange(questions);
                context.SaveChanges();
            }
        }

        public static void SaveQuestionTwos(List<QuestionTwo> questions)
        {
            using (var context = new SampleDBContext())
            {
                context.QuestionTwos.AddRange(questions);
                context.SaveChanges();
            }
        }

        public static List<QuestionOne> GetQuestionOnesForUser(int userId)
        {
            using (var context = new SampleDBContext())
            {
               var questions = context.QuestionOnes.Where(v => v.UserId == userId).ToList();
                return questions;
            }
        }

        public static List<QuestionTwo> GetQuestionTwosForUser(int userId)
        {
            using (var context = new SampleDBContext())
            {
                var questions = context.QuestionTwos.Where(v => v.UserId == userId).ToList();
                return questions;
            }
        }
    }
}
