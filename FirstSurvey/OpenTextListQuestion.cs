using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class OpenTextListQuestion:Question
    {
        public List<OpenTextQuestion> openTextListQuestion = new List<OpenTextQuestion>();

        public OpenTextListQuestion()
        {
            this.Id = 'q' + (Globals.questionId++).ToString();
        }
        public override void AutoResponse()
        {
            
            foreach(OpenTextQuestion q in openTextListQuestion)
            {
                q.AutoResponse();
                
            }            
        }
        public override void RequestAnswer()
        {
            foreach (OpenTextQuestion q in openTextListQuestion)
            {
                q.RequestAnswer();               
            }
        }
    }
}
