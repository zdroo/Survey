using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class Survey
    {
        private int survey_id;
        public List<Question> questions = new List<Question>();
        public List<GridQuestion> gridQuestions = new List<GridQuestion>();
        public List<OpenTextListQuestion> openTextListQuestions = new List<OpenTextListQuestion>();
        public Survey()
        {      
            
        }      
        
        public int SurveyId
        {
            get { return this.survey_id; }
            set { this.survey_id = value; }
        }

        public void DbRun()
        {
            DataAccess db = new DataAccess();

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            User user = new User(name, age);
            foreach (Question question in questions)
            {
                var result = question.AnswerRet();
                db.InsertInResponses(user.Name, result.Q_id, result.ResponseText);
            }
        }
        public void run()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            User user = new User(name, age);

            foreach (Question question in questions)
            {
                question.RequestAnswer();
            }
            foreach (GridQuestion question in gridQuestions)
            {
                question.RequestAnswer();
            }
            foreach (OpenTextListQuestion question in openTextListQuestions)
            {
                question.RequestAnswer();
            }
        }

        public void responseGenerator()
        {
            foreach(Question question in questions)
            {                
                question.AutoResponse();                
            }      
            foreach(GridQuestion question in gridQuestions)
            {
                question.AutoResponse();
            }
            foreach(OpenTextListQuestion question in openTextListQuestions)
            {
                question.AutoResponse();
            }
        }
        
    }
}
