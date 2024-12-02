namespace Console_StudentManagementSystem.lib
{
    internal class Ms
    {
        
        // Initializing a List of objects
        public List<Student> Students = [];
        public List<Subject> Subjects = [];
        private List<Assesments> Assesments =[];

       public void PushStudent(Student student)
       {
           Students.Add(student);
       }
       public void PushSubject(Subject subject)
       {
           Subjects.Add(subject);
       }
       public void PushAssessments(Assesments assesments)
       {
           Assesments.Add(assesments);
       }
        protected int calculate_date(string arg)
        {
            // Initializing constant devider
            const int n = 365;

            //  Fetch todays date
            DateTime today = DateTime.Today;
            DateTime date = DateTime.Parse(arg);

            //  Calculate the difference between the two dates
            TimeSpan diff = today.Date - date.Date ;

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
