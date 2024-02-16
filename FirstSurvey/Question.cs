using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class Question
    {
        private string q_id = null;
        private string qtext;
        private string instructionText;
        private string qtype;
        private int survey_id;
        public List<Answer> options = new List<Answer>();

        public string Id
        {
            get { return q_id; }
            set { q_id = value; }
        }
        public string Text 
        { 
            get { return qtext; } 
            set { qtext = value; } 
        }

        public string InstructionText
        {
            get { return instructionText; }
            set { instructionText = value; }
        }
        public int SurveyId
        {
            get { return survey_id; }
            set { survey_id = value; }
        }

        public string Type
        {
            get { return qtype; }
            set { qtype = value; }
        }
        public Question()
        {
        }
        public virtual Response AnswerRet() { return null; }
        public virtual void RequestAnswer() { }
        public virtual void AutoResponse() { }      

    }
}
