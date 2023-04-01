using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace File_Reader_Quiz_App.Classes
{
    public class QuizLogger
    {
        public static void LogMultipleChoiceScore(string scoreReport)
        {
            string filePath = setUpFilePath();
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"Multiple choice score report: {DateTime.UtcNow} {scoreReport}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something bad happened while recording the multiple choice score...");
            }
        }

        public static void LogShortAnswerResponse(string questionAndResponse)
        {
            string filePath = setUpFilePath();

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"Short Answer Response: {questionAndResponse}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something bad happened while recording the multiple choice score...");
            }
        }

        public static string setUpFilePath()
        {
            string path = Environment.CurrentDirectory;
            string fileName = "quizlog.txt";
            string fullPath = Path.Combine(path, fileName);
            return fullPath;
        }
    }
}
