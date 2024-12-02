using Console_StudentManagementSystem.lib;

namespace Console_StudentManagementSystem
{
    class ConsoleApp
    {
        public static void Main()
        {
            // Initialize a List of students, List of Subjects and List of Assesments
            // Initalize a MS class
            Ms ms = new Ms();


            // Initialize the Subjects
            Subject.InitializeSubject("Introduction to Python Development", 135, 24, ms);
            Subject.InitializeSubject("Math R1", 140, 48, ms);

            // user Admission points
            int ap = 100;//(int)Math.Round(3.25);
            // Initialize the Students
            Student student = new Student("Kriss", "02/25/1994", ["Math R1","Introduction to Python Development" ], ap, ms);
            //Student.InitializeStudent("Terje", "02/25/1994", "Introduction to Python development",ap, ms);
            // Print the information
            PrintInfo();

            void PrintInfo()
            {
                int k = 20;
                foreach (var student in ms.Students)
                {
                    string program = "";
                    string verified = "";
                    for (int i = 0; i < student.Enrolled.Count; i++)
                    {
                        program += i < student.Enrolled.Count-1 ? $" \"{student.Enrolled[i]}\", " : $"\"{student.Enrolled[i]}\".";
                    }

                    int j = 0;
                    foreach (KeyValuePair<string, string> entry in student.VerifiedPrograms) {
                        verified += j < student.VerifiedPrograms.Count -1
                            ? $"{entry.Key} with the Assessment, {entry.Value},\n"
                            : $"{entry.Key} with the Assessment, {entry.Value}.";
                        j++;
                    }
                    Console.WriteLine(new string('*', k));
                    Console.WriteLine("Student Card");
                    Console.WriteLine($"Student ID : {ms.Students.Count}\nThe Student's name is {student.Name}.\n{student.Name} is {student.Age} years old.\nProgram enrolled : {program}\nCurrent Admission Points: {student.Ap}\n{student.Name}  has earned an assesment in:\n{verified}\n");
                    Console.WriteLine(new string('*', k));    
                }
                
            }
        }
    }
}