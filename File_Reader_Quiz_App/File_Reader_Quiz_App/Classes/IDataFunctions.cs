using System;
using System.Collections.Generic;
using System.Text;

namespace File_Reader_Quiz_App.Classes
{
    public interface IDataFunctions
    {
        List<MultipleChoiceQuizQuestion> GenerateMultipleChoiceQuestions(string fullFilePath);
        List<ShortAnswerQuizQuestion> GenerateShortAnswerQuestions(string fullFilePath);
    }
}
