using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem

{
    internal class Program
    {
        static List<Question> questionBank = new List<Question>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Examination System =====");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DoctorMode();
                        break;

                    case "2":
                        StudentMode();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        static void DoctorMode()
        {
            Console.Write("Number of Questions: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}");

                Console.WriteLine("Type:");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. Choose One");
                Console.WriteLine("3. Multiple Choice");

                int type = int.Parse(Console.ReadLine());

                Console.WriteLine("Level:");
                Console.WriteLine("0. Easy");
                Console.WriteLine("1. Medium");
                Console.WriteLine("2. Hard");

                ExamLevel level =
                    (ExamLevel)int.Parse(Console.ReadLine());

                Console.Write("Header: ");
                string header = Console.ReadLine();

                Console.Write("Marks: ");
                int marks = int.Parse(Console.ReadLine());

                switch (type)
                {
                    case 1:
                        Console.Write("Correct Answer (true/false): ");
                        bool tfAnswer =
                            bool.Parse(Console.ReadLine());

                        questionBank.Add(
                            new TrueFalseQuestion(
                                header,
                                marks,
                                level,
                                tfAnswer));

                        break;

                    case 2:

                        string[] choices1 = new string[4];

                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Choice {j + 1}: ");
                            choices1[j] = Console.ReadLine();
                        }

                        Console.Write("Correct Choice Number: ");
                        int correctChoice =
                            int.Parse(Console.ReadLine());

                        questionBank.Add(
                            new ChooseOneQuestion(
                                header,
                                marks,
                                level,
                                choices1,
                                correctChoice));

                        break;

                    case 3:

                        string[] choices2 = new string[4];

                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Choice {j + 1}: ");
                            choices2[j] = Console.ReadLine();
                        }

                        Console.Write("Correct Answers (1,3): ");

                        int[] correctAnswers =
                            Console.ReadLine()
                            .Split(',')
                            .Select(int.Parse)
                            .ToArray();

                        questionBank.Add(
                            new MultipleChoiceQuestion(
                                header,
                                marks,
                                level,
                                choices2,
                                correctAnswers));

                        break;
                }
            }

            Console.WriteLine("Questions Added Successfully.");
        }

        static void StudentMode()
        {
            if (questionBank.Count == 0)
            {
                Console.WriteLine("Question Bank Is Empty.");
                return;
            }

            Console.WriteLine("Exam Type:");
            Console.WriteLine("1. Practical");
            Console.WriteLine("2. Final");

            int examType = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Level:");
            Console.WriteLine("0. Easy");
            Console.WriteLine("1. Medium");
            Console.WriteLine("2. Hard");

            ExamLevel level =
                (ExamLevel)int.Parse(Console.ReadLine());

            List<Question> questions =
                questionBank
                .Where(q => q.Level == level)
                .ToList();

            if (questions.Count == 0)
            {
                Console.WriteLine("No Questions Found.");
                return;
            }

            if (examType == 1)
            {
                questions =
                    questions
                    .Take(Math.Max(1, questions.Count / 2))
                    .ToList();
            }

            int totalMarks = 0;
            int studentMarks = 0;

            foreach (Question q in questions)
            {
                Console.WriteLine();
                q.Display();

                Console.Write("Your Answer: ");
                string answer = Console.ReadLine();

                totalMarks += q.Marks;

                if (q.CheckAnswer(answer))
                {
                    studentMarks += q.Marks;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Your Result: {studentMarks} / {totalMarks}");
        }
    }
}