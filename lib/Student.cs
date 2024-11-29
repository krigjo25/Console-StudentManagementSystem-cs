using System.Text.RegularExpressions;
namespace Console_StudentManagementSystem.lib
{
    internal class Student : MS
    {
        //  Student fields
        private string _age;
        private string _name;
        private string _program = "";
        private string _dateOfBirth;

        // Properties 
        private string Birthday
        {
            get => _dateOfBirth;
            set
            {
                Console.WriteLine(value);
                //  Ensure that the Value is correctly formatted
                if (DateTime.Now > DateTime.Parse(value)) { _dateOfBirth = value;}
                else { Console.WriteLine("Invalid date " + value); }
            }
        } 
        public int Age
        {
            get => _age;
            set
            {
                if ( (int) MS.calculate_date(value) > 0)
                {
                    _age = Convert.ToString(MS.calculate_date(value));
                }
            }
        }
        
        public string Name
        {
            get => _name;
            set
            {
                string pattern = "[^a-zA-Z$]";
                if (Regex.IsMatch(value, pattern))
                {
                    _name = value;
                }
            }
        }
        protected string Program
        {
            get => _program;
            set
            {
                _program = value;

            }
        }
        
        public Student(string name, string bday, MS obj)
        {
            
            Name = name;  //    Krigjo25    
            Birthday = bday; // 02/25/1994
            obj.IncreseId();
        }


    }
}