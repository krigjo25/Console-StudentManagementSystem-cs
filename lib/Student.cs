using System.Text.RegularExpressions;
namespace Console_StudentManagementSystem.lib
{
    internal class Student : Ms
    {
        //  Student fields
        private float _ap;
        private string _age = string.Empty;
        private string _name = string.Empty;
        private string _dateOfBirth = string.Empty;

        // Properties 
        private Ms Base { get;}
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
        internal string Age
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
        internal float Ap
        {
            get => _ap;
            set => _ap += value;
        }
        internal string Name
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
        public readonly Dictionary<string, string> VerifiedPrograms = [];


        public Student(string name, string dateofbirth, List<string> prog, decimal points, Ms obj)
        {
            Base = obj;
            Name = name;
            Birthday = dateofbirth;
            _ap = (float) points;
            InitializeAdmissionPoints(Convert.ToInt32(Age), 10);
            
            EnrollProgram(prog);
            VerifyProgram();
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
            foreach (var element in from element in prog from sub in Base.Subjects where sub.Name == element select element)
            {
                Enrolled.Add(element);
            }
        }
        private void VerifyProgram()
        {
            if (Enrolled.Count > 0)
            {
                var unused = new Assessments(this, Base);
            }
        }
        
    }
}