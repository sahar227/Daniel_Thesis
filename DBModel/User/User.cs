using DBModel.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.User
{
    public enum UserGroup
    {
        Unknown, // should not be set to this on proper functionality
        One,
        Two,
        Three,
        Four
    }

    public class User : DBModel
    {
        public string FullName { get; private set; }
        public UserGroup Group { get; private set; }

        public DateTime? StartTimeStageOne { get; set; }
        public DateTime? EndTimeStageOne { get; set; }

        public DateTime? StartTimeStageTwo { get; set; }
        public DateTime? EndTimeStageTwo { get; set; }

        public List<QuestionOne> StageOneQuestions = new List<QuestionOne>();
        public List<QuestionTwo> StageTwoQuestions = new List<QuestionTwo>();

        public User(string name, UserGroup group)
        {
            FullName = name;
            Group = group;
        }

    }
}
