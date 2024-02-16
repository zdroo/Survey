using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class OpenTextQuestion : Question
    {
        public OpenTextQuestion(string q_id, string text, string qtype, int survey_id)
        {
            this.Id = q_id;
            this.Text = text;
            this.Type = qtype;
            this.InstructionText = "Write your answer below:";
            this.SurveyId = survey_id;
        }       
        public override void RequestAnswer()        //used for initial version
        {
            Console.WriteLine(Id + ". " + Text);
            Console.WriteLine(InstructionText);
            Text = (Console.ReadLine());            
            Console.WriteLine("Your answer is: {0}", Text);
        }

        public override void AutoResponse()         //used for initial version
        {
            Console.WriteLine(Id + ". " + Text);
            Random random = new Random();

            string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                    
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            Console.WriteLine(InstructionText);
            Text = RandomString(10);
            Console.WriteLine("Your answer is: "+Text);
            Console.ReadLine();
        }
        public override Response AnswerRet()
        {
            Response response = new Response();
            Console.WriteLine(Id + ". " + Text);
            Console.WriteLine(InstructionText);
            response.ResponseText = (Console.ReadLine());
            Console.WriteLine("Your answer is: {0}", response.ResponseText);
            response.Q_id = Id;
            return response;
        }

    }
}
