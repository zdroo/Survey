using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class GridQuestion:Question
    {
        public List<SingleQuestion> gridQuestion = new List<SingleQuestion>();
       
        public GridQuestion()
        {
            this.Id = 'q' + (Globals.questionId++).ToString();
        }       

        public override void RequestAnswer() 
        {
            foreach (SingleQuestion q in gridQuestion)
            {
                q.RequestAnswer();
            }
        }
        public override void AutoResponse() 
        {
            foreach(SingleQuestion q in gridQuestion)
            {   
                q.AutoResponse();
            }
            
        }
    }
}
