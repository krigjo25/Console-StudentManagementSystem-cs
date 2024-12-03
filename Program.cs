using Console_StudentManagementSystem.lib;

namespace Console_StudentManagementSystem
{
    class ConsoleApp
    {
        public static void Main()
        {
            // Initialize a List of students, List of Subjects and List of Assessments
            // Initalize a MS class
            Ms ms = new Ms();
            //var array = ProgramIntroduction();

            
            // Initialize the Subjects
            Console.WriteLine("Initializing Subjects..");
            Subject.InitializeSubject("Introduction to Python Development", 135, 24, ms);
            Subject.InitializeSubject("Math R1", 140, 48, ms);

            // user Admission points
            int ap = 100;//(int)Math.Round(3.25);
            // Initialize the Students
            Console.WriteLine("Initializing Student..");
            Student student = new Student("Kriss", "02/25/1994", ["Math R1","Introduction to Python Development" ], ap, ms);
            
            // Print the information
            PrintInfo();
            return;

            void PrintInfo()
            {
                int j = 0;
                const int k = 20;
                foreach (var student in ms.Students)
                {
                    //  Initialize the string variables
                    string program = "";
                    string verified = "";
                    
                    // Print the enrolled programs
                    for (int i = 0; i < student.Enrolled.Count; i++)
                    {
                        program += i < student.Enrolled.Count-1 
                            ? $" \"{student.Enrolled[i]}\", " 
                            : $"\"{student.Enrolled[i]}\".";
                    }

                    
                    // Print the verified programs
                    while(j < student.VerifiedPrograms.Count)
                    {
                        foreach (var (key, value) in student.VerifiedPrograms)
                        {
                            verified += j < student.VerifiedPrograms.Count - 1
                                ? $"{key} with the Assessment, {value},\n"
                                : $"{key} with the Assessment, {value}.";
                            j++;
                        }
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