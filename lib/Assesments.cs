namespace Console_StudentManagementSystem.lib
{
    internal class Assesments : MS
    {
        private Student student;
        private Subject subject;
        private string credits;

        public Assesments(Student student, Subject subject, string credits)
        {
            this.student = student;
            this.subject = subject;
            this.credits = credits;
            
        }
        

    }
}
