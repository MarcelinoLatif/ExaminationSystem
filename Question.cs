using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public abstract class Question
    {
        public string Header { get; set; }
        public int Marks { get; set; }
        public ExamLevel Level { get; set; }

        public Question(string header, int marks, ExamLevel level)
        {
            Header = header;
            Marks = marks;
            Level = level;
        }

        public abstract void Display();
        public abstract bool CheckAnswer(string answer);
    }
}