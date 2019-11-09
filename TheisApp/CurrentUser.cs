using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheisApp
{
    public static class CurrentUser
    {
        public static User currentUser;

        public static void AddQuestionOnes(List<QuestionOne> questions)
        {
            if(currentUser != null)
                currentUser.StageOneQuestions = questions;
        }

        public static void AddQuestionTwos(List<QuestionTwo> questions)
        {
            if (currentUser != null)
                currentUser.StageTwoQuestions = questions;
        }

        public static void UpsertUser()
        {
            if (currentUser != null)
             using (var context = new SampleDBContext())
             {
                 context.Users.Update(currentUser);
                 context.SaveChanges();
             }
        }
    }
}
