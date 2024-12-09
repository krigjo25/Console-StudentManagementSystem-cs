namespace Console_StudentManagementSystem.lib
{
    internal class Ms // School
    {
        // Initializing a List of objects
        private readonly List<Student> Students = [];
        internal readonly List<Subject> Subjects = [];

        public void InitializeSubject()
        {
            Subjects.Add(new Subject("JavaScript", 135, 48, 500));
            Subjects.Add(new Subject("Python", 140, 48, 100));
            Subjects.Add(new Subject("C#", 140, 48, 30));
        }

        internal void PushStudent(Student obj)
        {
            Students.Add(obj);
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

        public void PrintInfo()
        {
            var j = 0;
            const int k = 20;

            foreach (var student in Students)
            {
                //  Initialize the string variables
                var program = FetchEnrolledPrograms(student.Enrolled);
                var verified = FetchVerifiedPrograms(student.VerifiedPrograms);


                // Print the verified programs

                Console.WriteLine(new string('*', k));
                var text =
                    $"Student CardStudent ID : {Students.Count - 1}\nThe Student's name is {student.Name}.\n{student.Name} is {student.Age} years old.\nProgram enrolled : {program}\nCurrent Admission Points: {student.Ap}\n{student.Name} has earned an assessment in: {verified}";
                ConsoleApp.ConsoleTypeEffect(text);
                Console.WriteLine(new string('*', k));
            }
        }

        private string FetchEnrolledPrograms(List<string> enrolled)
        {
            var program = "";
            foreach (var element in enrolled) program += element + ", ";

            return program;
        }

        private string FetchVerifiedPrograms(Dictionary<string, string> verifiedPrograms)
        {
            var i = 0;
            var verified = "";

            while (i < verifiedPrograms.Count)
                foreach (var (key, value) in verifiedPrograms)
                {
                    verified += i < verifiedPrograms.Count - 1
                        ? $"{key} with the Assessment, {value},\n"
                        : $"{key} with the Assessment, {value}.";
                    i++;
                }

            return verified;
        }
    }
}