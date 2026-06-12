using System;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace ExaminationSystem
{
    public class MultipleChoiceQuestion : Question
    {
        public string[] Choices { get; set; }
        public int[] CorrectAnswers { get; set; }

        public MultipleChoiceQuestion(
            string header,
            int marks,
            ExamLevel level,
            string[] choices,
            int[] correctAnswers)
            : base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswers = correctAnswers;
        }

        public override void Display()
        {
            Console.WriteLine(Header);

            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }

            Console.WriteLine("Enter answers separated by comma:");
        }

        public override bool CheckAnswer(string answer)
        {
            int[] studentAnswers = answer
                .Split(',')
                .Select(x => int.Parse(x.Trim()))
                .OrderBy(x => x)
                .ToArray();

            int[] correct = CorrectAnswers
                .OrderBy(x => x)
                .ToArray();

            return studentAnswers.SequenceEqual(correct);
        }
    }
}