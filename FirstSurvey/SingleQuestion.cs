using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class SingleQuestion : Question
    {        
        public SingleQuestion(string q_id, string text, string qtype, int survey_id)
        {
            this.Id = q_id;
            this.Text = text;
            this.Type = qtype;
            this.InstructionText = "Choose only one option: ";
            this.SurveyId = survey_id;
        }
        
        public override void AutoResponse()     //used for initial version
        {
            Console.WriteLine(Id+". "+Text);
            int showOptionNumber = 1;
            foreach (Answer option in options)
            {
                Console.WriteLine(showOptionNumber++ + ". " + option.Text);
            }

            Console.WriteLine(InstructionText);
            Random random = new Random();
            int chosen = random.Next(1, options.Count+1);
            Console.WriteLine("Your chosen answer is: {0}", chosen);

            Console.ReadLine();
        }

        public override void RequestAnswer()     //used for initial version
        {
            DataAccess db = new DataAccess();

            Console.WriteLine(Id + ". " + Text);
            foreach (Answer option in options)
            {
                Console.WriteLine(option.OptionNumber + ". " + option.Text);
            }

            Console.WriteLine(InstructionText);
            int chosenResponse = Convert.ToInt32(Console.ReadLine());
            foreach(Answer option in options)
            {
                if (chosenResponse == option.OptionNumber)
                    option.Chosen++;
                db.UpdateChosenValByAnsId(option.Id, option.Chosen);

            }
            Console.WriteLine("Your choice is: {0}", chosenResponse);
            Console.WriteLine();
            
        }
        public override Response AnswerRet()
        {
            Response response = new Response();
            DataAccess db = new DataAccess();

            Console.WriteLine(Id + ". " + Text);
            foreach (Answer option in options)
            {
                Console.WriteLine(option.OptionNumber + ". " + option.Text);
            }

            Console.WriteLine(InstructionText);
            int chosenResponse = Convert.ToInt32(Console.ReadLine());
            foreach (Answer option in options)
            {
                if (chosenResponse == option.OptionNumber)
                    option.Chosen++;
                db.UpdateChosenValByAnsId(option.Id, option.Chosen);

            }
            Console.WriteLine("Your choice is: {0}", chosenResponse);
            Console.WriteLine();
            response.Q_id = Id;
            response.ResponseText = chosenResponse.ToString();
            return response;
        }

    }
}
