namespace Console_StudentManagementSystem.lib
{
    internal class Assessments : Ms
    {
        private Student student { set; get; }
        private Ms Base { get; set; }
        private readonly Dictionary<string, string> _programs = [];

        public Assessments(Student student, Ms obj)
        {
            var r = new Random();

            this.student = student;
            Base = obj;

            foreach (var element in student.Enrolled)
            {
                InitializeGrade(element, r.Next(0, 100));
            }

            TransferAdmissionPoints();
            PushAssessments(this);
        }

        void InitializeGrade(string element, int score)
        {
            string[] ch =
            [
                "A", "A-", "B+",
                "B", "B-", "C+",
                "C", "C-", "D+",
                "D", "D-", "F"
            ];

            //  Assign the grade based on the score
            if (score >= 90)
            {
                _programs.Add(element, ch[0]);
            }
            else if (score > 86)
            {
                _programs.Add(element, ch[1]);

            }
            else if (score > 82)
            {
                _programs.Add(element, ch[2]);
            }
            else if (score > 78)
            {
                _programs.Add(element, ch[3]);
            }
            else if (score > 74)
            {
                _programs.Add(element, ch[4]);
            }
            else if (score > 70)
            {
                _programs.Add(element, ch[5]);
            }
            else if (score > 66)
            {
                _programs.Add(element, ch[6]);
            }
            else if (score > 62)
            {
                _programs.Add(element, ch[7]);
            }
            else if (score > 58)
            {
                _programs.Add(element, ch[8]);
            }
            else if (score > 56)
            {
                _programs.Add(element, ch[9]);
            }
            else if (score > 54)
            {
                _programs.Add(element, ch[10]);
            }
            else
            {
                _programs.Add(element, ch[11]);
            }
        }

        private void TransferAdmissionPoints()
        {
            foreach (var sub in Base.Subjects)
            {
                //  Transfer the credits to the student
                foreach (var (key, value) in _programs)
                {
                    if (sub.Name == key && value != "F")
                    {
                        student.Ap += sub.Creds;
                        student.VerifiedPrograms.Add(key, value);
                    }
                }
            }
        }
    }
}
