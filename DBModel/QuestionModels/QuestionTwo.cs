using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.QuestionModels
{
    public class QuestionTwo : Question
    {
        public QuestionTwo(int userId, string askedQuestion, bool expectedAnswer) : base(userId, askedQuestion, expectedAnswer)
        {

        }
    }
}
