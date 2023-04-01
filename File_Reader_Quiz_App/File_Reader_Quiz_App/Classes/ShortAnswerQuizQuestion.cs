using System;
using System.Collections.Generic;
using System.Text;

namespace File_Reader_Quiz_App.Classes
{
    public class ShortAnswerQuizQuestion
    {
        public string Question { get; }

        public ShortAnswerQuizQuestion(string rawData)
        {
            if (!string.IsNullOrEmpty(rawData))
            {
                Question = rawData;
            }
        }

        public string DisplayQuizQuestion()
        {
            return Question;
        }
    }
}
