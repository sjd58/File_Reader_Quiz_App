using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace File_Reader_Quiz_App.Classes
{
    public class MultipleChoiceQuizQuestion
    {
        public string Question { get; }
        private List<string> answers { get; set; } = new List<string>();
        private int CorrectAnswer { get; }

        public MultipleChoiceQuizQuestion(string rawData)
        {
            if (!string.IsNullOrEmpty(rawData))
            {
                string[] parts = rawData.Split("|", StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    Question = parts[0];
                }
                else
                {
                    Console.WriteLine("A line in the quiz file does not contain enough information; invalid quiz question");
                }

                // This loop will set all the answers. It begins after index zero, which contians the quesiton.
                // It ends before the last index, which contains the correct answer.

                for (int i = 1; i < parts.Length-1; i++)
                {
                    string answer = parts[i].Trim(); // remove the extra spaces
                    answers.Add(answer);
                }

                // parse the string to an int at the last position in the parts array and set the correct answer to it. 
                CorrectAnswer = int.Parse(parts[parts.Length - 1]);
            }
        }

        public bool IsCorrectAnswer(int selectedAnswer)
        {
            return CorrectAnswer == selectedAnswer;
        }

        public string DisplayQuizQuestion()
        {
            string questionAndAnswersDisplay = "";
            for (int i = 0; i < answers.Count; i ++)
            {
                questionAndAnswersDisplay += $"{i + 1}: {answers[i]} \n";
            }
            return $"{Question} \n{questionAndAnswersDisplay}";
        }
    }
}
