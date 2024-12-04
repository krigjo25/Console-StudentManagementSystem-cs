using Console_StudentManagementSystem.lib;

namespace Console_StudentManagementSystem
{
    internal abstract class ConsoleApp
    {
        public static void Main()
        {
            // Initialize the array of strings
            var arg = new string[3];
            var program = new List<string>();
            string[] array = ["name", "Date of birth (mm/dd/yyyy)", "Admission Points", "Programs (separated by commas)"];
            Console.Clear();

            int index = 0;
            
            while (index < array.Length)
            { 
                Console.WriteLine($"Enter the {array[index]} of Student");
                var input = Console.ReadLine();
                
                if (input != null)
                {
                    if (index == array.Length - 1)
                    {
                        program.AddRange(input.Split(","));
                        break;
                    }
                    arg[index] = input;
                    index++;
                }
            }
            // Initialize an MS class
            var student = new Student(arg,program);
            ProgramIntroduction();
            
            // Initialize the Subjects

            // Print the information
            student.PrintInfo();
        }

        private static void ProgramIntroduction()
        {
            const string text = """
                                Welcome to the Student Management System !
                                This program is designed to manage students and their programs
                                The program will initialize a list of subjects and students
                                The program will then enroll the students in the subjects
                                The program will then verify the students' programs
                                The program will then print the students' information
                                """;
            ConsoleTypeEffect(text);
        }
        public static void ConsoleTypeEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(75);
            }
            Console.Write("\n");
        }
    }
}