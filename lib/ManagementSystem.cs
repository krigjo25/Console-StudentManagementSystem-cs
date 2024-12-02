namespace Console_StudentManagementSystem.lib
{
    internal class Ms
    {
        
        // Initializing a List of objects
        public readonly List<Student> Students = [];
        public readonly List<Subject> Subjects = [];
        private readonly List<Assessments> _assessmentList = [];

       public void PushStudent(Student student)
       {
           Students.Add(student);
       }
       public void PushSubject(Subject subject)
       {
           Subjects.Add(subject);
       }

       protected void PushAssessments(Assessments assessments)
       {
           _assessmentList.Add(assessments);
       }
       protected static int calculate_date(string arg)
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
    }
}
