namespace Console_StudentManagementSystem.lib
{
    internal class Subject : MS
    {
        private int _creds;
        private string _subjectname;
        
        protected int Creds
        {
            get => _creds;
            set
            {
                _creds = value;
            }
        }

        protected string SubjectName { 
            get => _subjectname;
            set
            {
                _subjectname = value;
            }
        }
        
        public Subject(string name, MS obj, int d, int w = 7)
        {
            IncreseId();
            SubjectName = name;
            Creds = obj.calculate_credits(d, w);
            
        }
        

    }
}
