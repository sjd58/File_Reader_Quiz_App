using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace File_Reader_Quiz_App.Classes
{
    public class UI
    {
        private string InputFile;
        private List<MultipleChoiceQuizQuestion> multipleChoiceQuestions;
        private List<ShortAnswerQuizQuestion> shortAnswerQuestions;
        public int UserQuizDecision;
        public void Run()
        {
            Console.WriteLine("Welcome to Quizzle, the quiz application that will help you prepare for coding technical interview questions.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Take Multiple Choice Quiz");
            Console.WriteLine("2) Take Short Answer Quiz");
            Console.WriteLine("3) Quit Quiz Application");
            string quizTypeInput = Console.ReadLine();
            string[] validActionInputs = new string[3] { "1", "2", "3" };
            while (!(validActionInputs.Contains(quizTypeInput)))
            {
                Console.WriteLine("Invalid input; please try again.");
                Console.WriteLine("What type of quiz would you like to take?");
                Console.WriteLine("1) Multiple Choice");
                Console.WriteLine("2) Short Answer");
                Console.WriteLine("3) Quit Quiz Application");
                quizTypeInput = Console.ReadLine();
            }

            UserQuizDecision = int.Parse(quizTypeInput);
            // if the user selected 3, quit the application.
            if (UserQuizDecision == 3)
            {
                Environment.Exit(0);
            }

            Console.WriteLine("Please enter the fully qualified filepath for the file you want to use for your quiz:");
            InputFile = Console.ReadLine();
            // repeat prompts so long as the user does not give us a valid filepath to use
            while (!File.Exists(InputFile))
            {
                Console.WriteLine("That file doesn't exist; please try again.");
                Console.WriteLine("Please enter the fully qualified filepath for the file you want to use for your quiz:");
                InputFile = Console.ReadLine();
            }
            // use the IDataFunctions interface to interact with the FileData object to get our list of quiz questions
            IDataFunctions dataFunctions = new FileData();
            if (UserQuizDecision == 1)
            {
                multipleChoiceQuestions = dataFunctions.GenerateMultipleChoiceQuestions(InputFile);
                TakeMultipleChoiceQuiz();
            }
            else
            {
                shortAnswerQuestions = dataFunctions.GenerateShortAnswerQuestions(InputFile);
                TakeShortAnswerQuiz();
            }
        }

        private void TakeMultipleChoiceQuiz()
        {
            // Create counters for number of questions and correct answers; we will use these later to return the score for the quiz.
            int questionsCounter = 0;
            int correctAnswersCounter = 0;

            foreach (MultipleChoiceQuizQuestion item in multipleChoiceQuestions)
            {
                questionsCounter++; // add one to the question count
                Console.WriteLine(item.DisplayQuizQuestion()); // access the DisplayQuizQuestion method on the item to get the info we need
                Console.WriteLine("Please enter your answer: ");
                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    if (item.IsCorrectAnswer(answer)) // pass the user's answer into our IsCorrectAnswer method to check if it's correct. Remember we're getting back a bool from this method.
                    {
                        // if we get true, add one to the correctAnswersCounter
                        correctAnswersCounter++;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Answer in bad format; moving on...");
                }
            }
            string scoreReport = $"You got {correctAnswersCounter} out of {questionsCounter} questions correct";
            Console.WriteLine(scoreReport);
            QuizLogger.LogMultipleChoiceScore(scoreReport);
            Run();
        }

        private void TakeShortAnswerQuiz()
        {
            int questionsCounter = 0;
            foreach (ShortAnswerQuizQuestion item in shortAnswerQuestions)
            {
                questionsCounter++;
                Console.WriteLine(item.DisplayQuizQuestion());
                Console.WriteLine("Please type your answer below:");
                string shortAnswerResponse = Console.ReadLine();
                QuizLogger.LogShortAnswerResponse($"Question {questionsCounter}: {item.DisplayQuizQuestion()} Answer: {shortAnswerResponse}");
            }
            Console.WriteLine("That's the end of your quiz! Your responses have been recorded to the quiz result logger.");
            Run();
        }
    }
}
