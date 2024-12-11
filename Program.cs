using Console_StudentManagementSystem.lib;

namespace Console_StudentManagementSystem
{
    internal abstract class ConsoleApp
    {
        public static void Main()
        {
            // Initialize the array of strings
            // Initialize an MS class
            var ms = new Ms();

            string[] array =
                ["name", "Date of birth (mm/dd/yyyy)", "Admission Points", "Programs (separated by commas)"];


            ms.InitializeSubject();
            Console.Clear();
            ProgramIntroduction();
            InitializeStudent(0, 2, array, ms);
            ms.PrintInfo();
        }

        private static void ProgramIntroduction()
        {
            const string text = """
                                Welcome to krigjo25's Vocational college...

                                Throught the initialization the program will Ainitialize a list of subjects for the School, and students,
                                Then enroll the students in the chosen subject, The program will do a check on student's
                                final assessment, if the student has passed the Student will receive the  ap ( Admission Points)
                                The program will then print the students' information
                                """;
            ConsoleTypeEffect(text);
        }

        public static void ConsoleTypeEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(3);
            }

            Console.Write("\n");
        }

        private static void InitializeStudent(int counter, int n, string[] array, Ms obj)
        {
            var arg = new string[3];
            var program = new List<string>();

            while (counter < n)
            {
                foreach (var element in array)
                {
                    Console.WriteLine($"Enter the {element} of Student");
                    if (element.ToLower().Contains("programs"))
                        foreach (var sub in obj.Subjects)
                            ConsoleTypeEffect(
                                $"Subject: {sub.Name} Student require least {sub.AdmissionScore}AP. If the student has a passing grade in this program, the student will recieve {sub.Creds} Creds");

                    var input = Console.ReadLine();

                    if (input != null)
                    {
                        if (element.ToLower().Contains("programs"))
                        {
                            ConsoleTypeEffect(input);
                            program.AddRange(input.Split(","));
                            break;
                        }

                        arg[counter] = input;
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                obj.PushStudent(new Student(arg, program));
            }
        }
    }
}