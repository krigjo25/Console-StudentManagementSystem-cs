namespace Console_StudentManagementSystem.lib
{
    internal abstract class Ms
    {

        // Initializing a List of objects
        protected readonly List<Student> Students = [];
        internal readonly List<Subject> Subjects = [];
        
        
        private readonly List<Assessments> AssessmentsList = [];

        internal void InitializeSubject()
        {
            Subjects.Add(new Subject("Math R1", 140, Convert.ToInt32(48)));
            Subjects.Add(new Subject("Introduction to Python Development", 135, 24));
        }
        protected void PushAssessments(Assessments assessments)
        {
            AssessmentsList.Add(assessments);
        }
        protected void PushStudent(Student student)
        {
            Students.Add(student);
        }

        protected int calculate_date(string arg)
        {
            // Initializing constant devider
            const int n = 365;

            //  Fetch todays date
            var today = DateTime.Today;
            var date = DateTime.Parse(arg);

            //  Calculate the difference between the two dates
            var diff = today.Date - date.Date;

            //  Ensure that the user's day is less than todays day.
            if (today.Month < date.Month || (today.Month == date.Month && today.Day < date.Day))
            {
                return (int)(diff.TotalDays / n) - 1;

            }

            //  Return age

            return (int)diff.TotalDays / n;

        }
    }
}