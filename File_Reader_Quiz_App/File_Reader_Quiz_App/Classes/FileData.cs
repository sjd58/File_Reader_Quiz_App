using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace File_Reader_Quiz_App.Classes
{
    public class FileData : IDataFunctions
    {
        public List<MultipleChoiceQuizQuestion> GenerateMultipleChoiceQuestions(string fullFilePath)
        {
            List<MultipleChoiceQuizQuestion> result = new List<MultipleChoiceQuizQuestion>();

            try
            {
                using (StreamReader sr = new StreamReader(fullFilePath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        try
                        {
                            result.Add(new MultipleChoiceQuizQuestion(line));
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Something bad happened while adding questions to your quiz question list...");
                        }
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something bad happened while generating your quiz...");
            }

            return result;
        }

        public List<ShortAnswerQuizQuestion> GenerateShortAnswerQuestions(string fullFilePath)
        {
            List<ShortAnswerQuizQuestion> result = new List<ShortAnswerQuizQuestion>();
            try
            {
                using (StreamReader sr = new StreamReader(fullFilePath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        try
                        {
                            result.Add(new ShortAnswerQuizQuestion(line));
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Something bad happened while adding questions to your list of short answer questions...");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Something bad happened while generating your quiz...");
            }
            return result;
        }
    }
}
