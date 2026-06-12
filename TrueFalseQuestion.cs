using ExaminationSystem;
using System;
using System;
using System.Reflection.PortableExecutable;

namespace ExaminationSystem
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string header, int marks, ExamLevel level, bool correctAnswer)
            : base(header, marks, level)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }

        public override bool CheckAnswer(string answer)
        {
            bool studentAnswer = answer == "1";
            return studentAnswer == CorrectAnswer;
        }
    }
}