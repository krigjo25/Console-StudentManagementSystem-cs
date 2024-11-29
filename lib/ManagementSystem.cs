using System.Text.RegularExpressions;

namespace Console_StudentManagementSystem.lib
{
    internal class MS
    {
        // Universal Class members
        private int _id;
        
        // Initializing a List of objects
        public List<Student> Students = new List<Student>();
        public List<Subject> Subjects = new List<Subject>();
        //public List<Assesments> Assesments = new List<Assesments>();
        
        
       protected int ID
       {
           get => _id;
           private set
           {
               _id = value;
           }
           
       }

       public void PushStudent(Student student)
       {
           Students.Add(student);
       }
       public void PushSubject(Subject subject)
       {
           Subjects.Add(subject);
       }
       internal void IncreseId()
        {
            ID++;
        }
        internal int calculate_credits(int d, int m)
        {
            /*
             * Clarification of  this algorthm is based on google Gemini's calculations
             * Where original Algorithm was introduced as Credits Value = Difficulty (Total Workload) * Weeks
             *  CV = TW * Multiplier (0.1),  TW = Duration * weeks // 
             
             */
            //  Constant multiplier

            float n = 0.1f;
            int TW = d * m;
            return (int)Math.Round(TW * n);
        }

        protected static int calculate_date(string arg)
        {
            // Initializing constant devider
            const int n = 365;

            //  Fetch todays date
            DateTime today = DateTime.Today;

            //  Initializing the date to compare
            DateTime date = new DateTime();
            date = DateTime.Parse(arg);

            // Calculates the difference between todays date and argument
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
