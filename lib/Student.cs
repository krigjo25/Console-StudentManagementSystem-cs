using System.Text.RegularExpressions;

namespace Console_StudentManagementSystem.lib
{
    internal class Student : Ms
    {
        //  Student fields
        private static float _ap;

        // Enrolled programs
        internal readonly List<string> Enrolled = [];
        public readonly Dictionary<string, string> VerifiedPrograms = [];
        private string _age = string.Empty;
        private string _dateOfBirth = string.Empty;
        private string _name = string.Empty;


        public Student(string[] arg, List<string> prog)
        {
            Name = arg[0];
            Birthday = arg[1];
            Ap = InitializeAdmissionPoints(Convert.ToInt32(Age), float.Parse(arg[2]));

            InitializeSubject();
            EnrollProgram(prog);

            var unused = new Assessments(this);
            PushStudent(this);
        }

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
                else
                {
                    Console.WriteLine("Invalid date " + value);
                }
            }
        }

        public string Age
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

        public float Ap
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

        private void InitializeAge(string bday)
        {
            Age = bday;
            Ap += 10;
        }

        private float InitializeAdmissionPoints(int age, float points)
        {
            return 0.26f * age + points;
        }

        private void EnrollProgram(List<string> prog)
        {
            //Kake
            foreach (var element in from element in prog
                     from sub in Subjects
                     where sub.Name == element && sub.AdmissionScore <= Ap
                     select element)
            {
                Enrolled.Add(element);
            }
        }
    }
}