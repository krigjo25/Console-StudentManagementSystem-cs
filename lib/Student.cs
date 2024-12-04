using System.Text.RegularExpressions;

namespace Console_StudentManagementSystem.lib
{
    internal class Student : Ms
    {
        //  Student fields
        private static float _ap;
        private string _age = string.Empty;
        private string _name = string.Empty;
        private string _dateOfBirth = string.Empty;

        // Properties 

        private string Birthday
        {
            get => _dateOfBirth;
            set
            {
                //  Ensure that the Value is correctly formatted
                if (DateTime.Now > DateTime.Parse(value))
                {
                    _dateOfBirth = value;
                    InitializeAge(Birthday);
                }
                else { Console.WriteLine("Invalid date " + value); }
            }
            
        }

        private string Age
        {
            get => _age;
            set
            {
                
                if (calculate_date(value) > 0)
                {
                    
                    _age = calculate_date(value).ToString();
                }
            }
        }
        protected internal float Ap
        {
            get => _ap;
            set => _ap += value;
        }

        public string Name
        {
            get => _name;
            set
            {
                string pattern = "^[a-zA-Z$]";
                
                //  Ensure that the name is valid
                if (Regex.IsMatch(value, pattern))
                {
                    _name = value;
                }
            }
        }
        
        // Enrolled programs
        public readonly List <string> Enrolled = []; 
        protected internal readonly Dictionary<string, string> VerifiedPrograms = [];


        public Student(string[] arg,  List<string> prog)
        {
            //Base = obj;
            Name = arg[0];
            Birthday = arg[1];
            _ap = float.Parse(arg[2]);
            InitializeAdmissionPoints(Convert.ToInt32(Age), 10);
            
            InitializeSubject();
            EnrollProgram(prog);
            PushStudent(this);
            VerifyProgram(Students);
            
        }
        
        private void InitializeAge(string bday)
        {
            Age = bday;
            Ap += 10;

        }
        private void InitializeAdmissionPoints(int age, int points)
        {
            Ap += (0.26f * age) + points;
        }
        private void EnrollProgram(List<string> prog)
        {
            // Kake 
            foreach (var element in from element in prog from sub in Subjects where sub.Name == element select element)
            {
                Enrolled.Add(element);
            }
        }
        private void VerifyProgram(List <Student> students)
        {
            if (Enrolled.Count > 0)
            {
                var unused = new Assessments(students);
            }
        }

        public void PrintInfo()
        {
            int j = 0; 
            const int k = 20; 
            
            foreach (var student in Students)
            {
                //  Initialize the string variables
                string program = FetchEnrolledPrograms();;
                string verified = FetchVerifiedPrograms();
                    
                
                // Print the verified programs
                
                Console.WriteLine(new string('*', k));
                string text =
                    $"Student CardStudent ID : {Students.Count-1}\nThe Student's name is {student.Name}.\n{student.Name} is {student.Age} years old.\nProgram enrolled : {program}\nCurrent Admission Points: {student.Ap}\n{student.Name}  has earned an assessment in: {verified}";
                ConsoleApp.ConsoleTypeEffect(text);
                Console.WriteLine(new string('*', k));    
            }

        }
        
        private string FetchEnrolledPrograms()
        {
            string program = "";
            foreach (var element in Enrolled)
            {
                program += element + ", ";
            }

            return program;
        }
        private string FetchVerifiedPrograms()
        {
            int i = 0;
            string verified = "";
            
            while(i < VerifiedPrograms.Count)
            {
                foreach (var (key, value) in VerifiedPrograms)
                {
                    verified += i < VerifiedPrograms.Count - 1
                        ? $"{key} with the Assessment, {value},\n"
                        : $"{key} with the Assessment, {value}.";
                    i++;
                }
            }


            return verified;
        }
    }
}