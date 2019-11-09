using DBModel.QuestionModels;
using System;
using System.Collections.Generic;

namespace DBModel
{
    public enum UserGroup
    {
        Unknown, // should not be set to this on proper functionality
        One,
        Two,
        Three,
        Four,
        FourContinued
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

        public User(string fullName, UserGroup group)
        {
            FullName = fullName;
            Group = group;
        }

    }
}
