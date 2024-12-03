namespace Console_StudentManagementSystem.lib
{
    internal class Ms
    {
        
        // Initializing a List of objects
        public readonly List<Student> Students = [];
        public readonly List<Subject> Subjects = [];
        private readonly List<Assessments> AssessmentList = [];
        
        internal void InitializeSubject(string arg, int arg1, int arg2)
        {
            Subjects.Add(new Subject(arg, arg1, arg2));
        }
       public void InitializeStudent(string[] arg, List<string> program)
       {
           Students.Add(new Student(arg[0], arg[1], program, Convert.ToDecimal(arg[2]), this));
       }


       protected void PushAssessments(Assessments assessments)
       {
           AssessmentList.Add(assessments);
       }
       
       protected int calculate_date(string arg)
       { 
           // Initializing constant devider
           const int n = 365;

            //  Fetch todays date
            var today = DateTime.Today;
            var date = DateTime.Parse(arg);

            //  Calculate the difference between the two dates
            var diff = today.Date - date.Date ;

            //  Ensure that the user's day is less than todays day.
            if ( today.Month < date.Month || (today.Month == date.Month && today.Day < date.Day) )
            {
                return (int)(diff.TotalDays / n) - 1;

            }

            //  Return age
            
            return (int)diff.TotalDays / n;

        }
       public void ProgramIntroduction()
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

       public void ConsoleTypeEffect(string text)
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
