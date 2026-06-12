using ExaminationSystem;
using System;
using System.Reflection.PortableExecutable;

namespace ExaminationSystem
{
    public class ChooseOneQuestion : Question
    {
        public string[] Choices { get; set; }

        public int CorrectChoice { get; set; }

        public ChooseOneQuestion(
            string header,
            int marks,
            ExamLevel level,
            string[] choices,
            int correctChoice)
            : base(header, marks, level)
        {
            Choices = choices;
            CorrectChoice = correctChoice;
        }

        public override void Display()
        {
            Console.WriteLine(Header);

            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            return answer == CorrectChoice.ToString();
        }
    }
}