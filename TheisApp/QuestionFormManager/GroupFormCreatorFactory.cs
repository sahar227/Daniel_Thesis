using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheisApp.QuestionFormManager.QuestionFormCreators;

namespace TheisApp.QuestionFormManager
{
    public static class GroupFormCreatorFactory
    {
        private static TrailRepository.TrailRepository m_trailRepository = new TrailRepository.TrailRepository();
        public static List<Form> CrateFormList(UserGroup group)
        {
            var formList = new List<Form>();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("במטלה זו תוצג בפניכם אות ולאחר מכן מילה בשפה זרה.");
            stringBuilder.AppendLine("עליכם לקבוע האם האות מופיעה במילה ולהשיב בהתאם.");
            var PhaseOneInstructions = new List<string>()
            {
                stringBuilder.ToString(),
                "למשל - האות _: במילה _- מופיעה. לעומת זאת האות__ במילה - לא מופיעה"
            };
            stringBuilder.Clear();
            stringBuilder.AppendLine("כעת יוצגו בפניכם מילים לא מוכרות בשפה זרה. עבור כל מילה יופיע במסך תרגום מסוים.");
            stringBuilder.AppendLine("עליכם לקבוע האם התרגום תואם למילה או לחלופין שגוי.");

            var stringBuilder2 = new StringBuilder();
            stringBuilder2.AppendLine("שימו לב!");
            stringBuilder2.AppendLine("במהלך המשימה כל מילה תופיע מספר פעמים וכן ינתן לכם פידבק אשר יעיד האם עניתם תשובה נכונה או שגויה. ");
            stringBuilder2.AppendLine("המטרה: להצליח ללמוד כמה שיותר מילים בעזרת הפידבקים שתקבלו. ");
            stringBuilder2.AppendLine("בהצלחה!");

            var PhaseTwoInstructions = new List<string>()
            {
                "תודה לכם על שיתוף הפעולה!",
                stringBuilder.ToString(),
                stringBuilder2.ToString()
            };
            switch (group)
            {
                case UserGroup.One:
                    formList.Add(new InstructionForm(PhaseOneInstructions));
                    formList.Add(QuestionFormsCreator.CreatePhase1(m_trailRepository));
                    formList.Add(new InstructionForm(PhaseTwoInstructions));
                    formList.Add(QuestionFormsCreator.CreatePhase2(m_trailRepository));
                    break;

                case UserGroup.Two:
                    formList.Add(new InstructionForm(PhaseTwoInstructions));
                    formList.Add(QuestionFormsCreator.CreatePhase2(m_trailRepository));
                    break;

                case UserGroup.Three:
                    formList.Add(QuestionFormsCreator.CreatePhase1(m_trailRepository));
                    formList.Add(QuestionFormsCreator.CreatePhase1WithFalseImages(m_trailRepository));
                    formList.Add(new InstructionForm(PhaseTwoInstructions));
                    formList.Add(QuestionFormsCreator.CreatePhase2(m_trailRepository));
                    break;

                case UserGroup.Four:
                    formList.Add(QuestionFormsCreator.CreatePhase1(m_trailRepository));
                    formList.Add(QuestionFormsCreator.CreatePhase1(m_trailRepository));
                    break;

                case UserGroup.FourContinued:
                    formList.Add(new InstructionForm(PhaseTwoInstructions));
                    formList.Add(QuestionFormsCreator.CreatePhase2(m_trailRepository));
                    break;

                default: throw new NotImplementedException();
            }
            return formList;

        }
    }
}
