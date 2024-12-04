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

            // Initialize a MS class
            var ms = new Ms();
            ms.ProgramIntroduction();
            
            // Initialize the Subjects
            ms.InitializeSubject("Math R1", 140, 48);
            ms.InitializeSubject("Introduction to Python Development", 135, 24);
            
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
            // Initialize the Student
            ms.InitializeStudent(arg, program);

            // Print the information
            PrintInfoStudent(ms);
        }

        
        private static void PrintInfoStudent(Ms @base)
        {
            int j = 0; 
            const int k = 20; 
            
            foreach (var student in @base.Students)
            {
                //  Initialize the string variables
                string program = FetchEnrolledPrograms(student);;
                string verified = FetchVerifiedPrograms(student);
                    
                
                // Print the verified programs
                
                Console.WriteLine(new string('*', k));
                string text =
                    $"Student CardStudent ID : {@base.Students.Count}\nThe Student's name is {student.Name}.\n{student.Name} is {student.Age} years old.\nProgram enrolled : {program}\nCurrent Admission Points: {student.Ap}\n{student.Name}  has earned an assessment in: {verified}";
                @base.ConsoleTypeEffect(text);
                Console.WriteLine(new string('*', k));    
            }

        }
        
        private static string FetchEnrolledPrograms(Student student)
        {
            string program = "";
            foreach (var element in student.Enrolled)
            {
                program += element + ", ";
            }

            return program;
        }
        private static string FetchVerifiedPrograms(Student student)
        {
            int i = 0;
            string verified = "";
            
            while(i < student.VerifiedPrograms.Count)
            {
                foreach (var (key, value) in student.VerifiedPrograms)
                {
                    verified += i < student.VerifiedPrograms.Count - 1
                        ? $"{key} with the Assessment, {value},\n"
                        : $"{key} with the Assessment, {value}.";
                    i++;
                }
            }


            return verified;
        }
    }
}