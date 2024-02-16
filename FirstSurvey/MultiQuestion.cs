using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSurvey
{
    class MultiQuestion : Question
    {

        public override void RequestAnswer()        //used for initial version
        {
            DataAccess db = new DataAccess();

            Console.WriteLine(Id + ". " + Text);
            foreach (Answer option in options)
            {
                Console.WriteLine(option.OptionNumber + ". " + option.Text);
            }

            Console.WriteLine(InstructionText);
            int numberOfChoices = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You are going to chose {0} different options: ", numberOfChoices);

            List<int> chosenValues = new List<int>();


            while (chosenValues.Count < numberOfChoices)
            {
                int chosenResponse = Convert.ToInt32(Console.ReadLine());
                if (!chosenValues.Contains(chosenResponse))
                {
                    chosenValues.Add(chosenResponse);
                    foreach(Answer option in options)
                    {
                        if(option.OptionNumber == chosenResponse)                        
                            option.Chosen++;
                        db.UpdateChosenValByAnsId(option.Id, option.Chosen);

                    }
                }
            }
            Console.WriteLine("Your chosen answers are: ");
            chosenValues.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public override void AutoResponse()     //used for initial version
        {
            Console.WriteLine(Id + ". " + Text);
            int showOptionNumber = 1;
            foreach (Answer option in options)
            {
                Console.WriteLine(showOptionNumber++ + ". " + option.Text);
            }

            Console.WriteLine(InstructionText);

            Random random = new Random();
            int numberOfChoices = random.Next(1, options.Count +1);
            Console.WriteLine("You are going to chose {0} different options: ", numberOfChoices);

            List<int> chosenValues = new List<int>();

            
            while(chosenValues.Count < numberOfChoices)
            {                                                         
                    int myNumber = random.Next(1, options.Count+1);
                    if (!chosenValues.Contains(myNumber))
                        chosenValues.Add(myNumber);
                    
            }
            
            Console.WriteLine("Your chosen answers are: ");
            chosenValues.ForEach(Console.WriteLine);
            Console.ReadLine();
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
            int numberOfChoices = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You are going to chose {0} different options: ", numberOfChoices);

            List<int> chosenValues = new List<int>();


            while (chosenValues.Count < numberOfChoices)
            {
                int chosenResponse = Convert.ToInt32(Console.ReadLine());
                if (!chosenValues.Contains(chosenResponse))
                {
                    chosenValues.Add(chosenResponse);
                    response.ResponseText = response.ResponseText+ chosenResponse.ToString()+ " ";
                    foreach (Answer option in options)
                    {
                        if (option.OptionNumber == chosenResponse)
                            option.Chosen++;
                        db.UpdateChosenValByAnsId(option.Id, option.Chosen);

                    }
                }
            }
            Console.WriteLine("Your chosen answers are: ");
            chosenValues.ForEach(Console.WriteLine);
            Console.WriteLine();
            response.Q_id = Id;
            return response;
        }

        public MultiQuestion(string q_id, string text, string qtype, int survey_id)
        {
            this.Id = q_id;
            this.Text = text;
            this.Type = qtype;
            this.InstructionText = "Enter number of answers and then select them: ";
            this.SurveyId = survey_id;
        }       
    }
}
