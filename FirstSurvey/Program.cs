using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            List<Question> surveyQuestions = new List<Question>();
            List<Survey> surveys = new List<Survey>();

            DataAccess db = new DataAccess();
            surveys = db.GetSurveys();
            

            foreach(Survey survey in surveys)
            {
                surveyQuestions = db.GetQuestionsBySurveyId(survey.SurveyId);
                foreach (Question question in surveyQuestions)
                {
                    if (question.Type == "single")
                        survey.questions.Add(new SingleQuestion(question.Id, question.Text, question.Type, question.SurveyId));
                    else if (question.Type == "multi")
                        survey.questions.Add(new MultiQuestion(question.Id, question.Text, question.Type, question.SurveyId));
                    else
                        survey.questions.Add(new OpenTextQuestion(question.Id, question.Text, question.Type, question.SurveyId));
                }
                foreach(Question question in survey.questions)
                {
                    int number = 1;
                    question.options = db.GetAnswersByQuestionId(question.Id);
                    foreach(Answer option in question.options)
                    {
                        option.OptionNumber = number++;
                    }
                }
                //survey.DbRun();
                survey.responseGenerator();
            }

            Console.ReadLine();
            /*string JSONresult = JsonConvert.SerializeObject(football);
            Console.Write(JSONresult);
            using (var sw = new StreamWriter(@"C:\Users\alexandru.zdru\Desktop\info\football.json", true))
            {
                sw.WriteLine(JSONresult.ToString());
                sw.Close();
            }
            */
        }
    }
}
