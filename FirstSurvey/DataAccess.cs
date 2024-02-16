using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class DataAccess
    {
        public List<Question> GetQuestionsBySurveyId(int survey_id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DesktopApps")))
            {
                var output = connection.Query<Question>($"select * from alexquestions.Questions where survey_id = '{survey_id}'").ToList();
                return output;
            }
        }
       
        public List<Answer> GetAnswersByQuestionId(string q_id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DesktopApps")))
            {
                var output = connection.Query<Answer>($"select * from alexquestions.Answers where q_id = '{q_id}'").ToList();
                return output;
            }
        }

        public List<Survey> GetSurveys()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DesktopApps")))
            {
                var output = connection.Query<Survey>($"select * from alexquestions.Surveys").ToList();
                return output;
            }
        }
        public void UpdateChosenValByAnsId(int id, int newChosenValue)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DesktopApps")))
            {
                connection.Execute("update alexquestions.Answers set chosen = @newChosenValue where id = @id", new { newChosenValue, id});
            }
        }
        public void InsertInResponses(string user_name, string q_id, string response)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DesktopApps")))
            {
                connection.Execute("insert into alexquestions.Responses(user_name,q_id,response) values (@user_name,@q_id,@response)", new { user_name, q_id, response });
            }
        }
       
    }
}
