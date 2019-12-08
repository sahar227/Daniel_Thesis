using DBModel;
using DBModel.QuestionModels;
using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheisApp.QuestionFormManager.QuestionFormCreators;
using TrailRepository;

namespace TheisApp.QuestionFormManager
{
    public class QuestionFormManager
    {
        private readonly List<Form> m_forms = new List<Form>();
        private int m_currentFormIndex = 0;
        private Form m_startForm;

        public QuestionFormManager(Form startForm, UserGroup group)
        {
            m_forms = GroupFormCreatorFactory.CrateFormList(group);
            m_startForm = startForm;
        }


        public void Start()
        {
            OpenForm(m_forms[m_currentFormIndex]);
        }

        private void OpenForm(Form f)
        {
            f.Closed += (s, args) => PlayNextForm();
            f.Show();
        }

        private void PlayNextForm()
        {
            m_currentFormIndex++;
            if (m_currentFormIndex < m_forms.Count)
                OpenForm(m_forms[m_currentFormIndex]);
            else
            {
                UserRepository.UpsertUser(CurrentUser.currentUser);
                // save user results
                SaveUserResults();
                m_startForm.Show();
            }
        }

        private void SaveUserResults()
        {
            var user = CurrentUser.currentUser;
            var questionOnes = QuestionRepository.GetQuestionOnesForUser(user.Id);
            var questionTwos = QuestionRepository.GetQuestionTwosForUser(user.Id);

            var userString = new StringBuilder();
            userString.AppendLine($"{user.FullName}, group: {user.Group.ToString()}");
            userString.AppendLine();

            var titleToPhase = new Dictionary<string, bool>();
            var trailOnes = TrailRepository.TrailRepository.LoadTrailOnesFromDatabase();

            var phaseOneCorrectAnswers = questionOnes.Where(v => v.ExpectedAnswer == v.UserAnswer).Count();
            var phaseTwoCorrectAnswers = questionTwos.Where(v => v.ExpectedAnswer == v.UserAnswer).Count();

            var phaseTwoQuestionsForTrailOnes = questionTwos.Where(v => IsQuestionTrailFromPhaseOne(v, titleToPhase, trailOnes)).ToList();
            var correctPhaseTwoTrailOnes = phaseTwoQuestionsForTrailOnes.Where(v => v.ExpectedAnswer == v.UserAnswer).Count();
            var phaseTwoQuestionsForTrailTwos = questionTwos.Where(v => !IsQuestionTrailFromPhaseOne(v, titleToPhase, trailOnes)).ToList();
            var correctPhaseTwoTrailTwos = phaseTwoQuestionsForTrailTwos.Where(v => v.ExpectedAnswer == v.UserAnswer).Count();


            // phase one report
            if (user.StartTimeStageOne != null && user.EndTimeStageOne != null)
            {
                userString.AppendLine($"Phase one was between {user.StartTimeStageOne} and {user.EndTimeStageOne}");
                userString.AppendLine($"On this phase the user answered correctly {phaseOneCorrectAnswers}/{questionOnes.Count} questions");

                userString.AppendLine("Phase one questions:");
                foreach (var question in questionOnes)
                {
                    var askedQuestion = question.AskedQuestion.Split(",".ToArray());
                    userString.AppendLine($"\t Is the letter {askedQuestion[0]} in the word {askedQuestion[1]}?");
                    var userAnswer = question.UserAnswer ? "yes" : "no";
                    var userResult = question.UserAnswer == question.ExpectedAnswer ? "correct" : "wrong";
                    userString.AppendLine($"\t User answer was '{userAnswer}' and it was {userResult}");
                    userString.AppendLine();
                }
            }

            // phase two report
            if (user.StartTimeStageTwo != null && user.EndTimeStageTwo != null)
            {
                userString.AppendLine($"Phase two was between {user.StartTimeStageTwo} and {user.EndTimeStageTwo}");
                userString.AppendLine($"On this phase the user answered correctly {phaseTwoCorrectAnswers}/{questionTwos.Count} questions");
                userString.AppendLine($"{correctPhaseTwoTrailOnes}/{phaseTwoQuestionsForTrailOnes.Count} correct answers for questions with words from phase 1");
                userString.AppendLine($"{correctPhaseTwoTrailTwos}/{phaseTwoQuestionsForTrailTwos.Count} correct answers for questions with words from phase 2");

                userString.AppendLine("Phase two questions:");
                foreach (var question in questionTwos)
                {
                    var askedQuestion = question.AskedQuestion.Split(",".ToArray());
                    var phaseNumber = IsQuestionTrailFromPhaseOne(question, titleToPhase, trailOnes) ? 1 : 2;
                    userString.AppendLine($"\t Is {askedQuestion[0]} the translation of {askedQuestion[1]}? (from phase {phaseNumber})");
                    var userAnswer = question.UserAnswer ? "yes" : "no";
                    var userResult = question.UserAnswer == question.ExpectedAnswer ? "correct" : "wrong";
                    userString.AppendLine($"\t User answer was '{userAnswer}' and it was {userResult}");
                    userString.AppendLine();
                }
            }
            Directory.CreateDirectory(@"C:\ThesisUtils\userResults");
            System.IO.File.WriteAllText($@"C:\ThesisUtils\userResults\{user.Id.ToString() + " " + user.FullName}.txt", userString.ToString());
        }

        private bool IsQuestionTrailFromPhaseOne(QuestionTwo question, Dictionary<string, bool> titleToPhase, List<TrailOne> trailOnes)
        {
            var questionTitle = question.AskedQuestion.Split(",".ToArray())[1];
            if (!titleToPhase.TryGetValue(questionTitle, out var isPhaseOne))
                titleToPhase.Add(questionTitle, trailOnes.Any(v => v.Title == questionTitle));
            return titleToPhase[questionTitle];
        }

    }
}
