namespace Console_StudentManagementSystem.lib
{
    internal class Assessments
    {
        private readonly Dictionary<string, string> _programs = [];

        private readonly Student _student;


        public Assessments(Student student)
        {
            var r = new Random();
            _student = student;
            InitializeGrade(student.Enrolled, r.Next(0, 100));
            TransferAdmissionPoints(student);
        }

        private void InitializeGrade(List<string> program, int score)
        {
            string[] ch =
            [
                "A", "A-", "B+",
                "B", "B-", "C+",
                "C", "C-", "D+",
                "D", "D-", "F"
            ];
            foreach (var element in program)
            {
                switch (score)
                {
                    //  Assign the grade based on the score
                    case >= 90:
                        _programs.Add(element, ch[0]);
                        break;
                    case > 86:
                        _programs.Add(element, ch[1]);
                        break;
                    case > 82:
                        _programs.Add(element, ch[2]);
                        break;
                    case > 78:
                        _programs.Add(element, ch[3]);
                        break;
                    case > 74:
                        _programs.Add(element, ch[4]);
                        break;
                    case > 70:
                        _programs.Add(element, ch[5]);
                        break;
                    case > 66:
                        _programs.Add(element, ch[6]);
                        break;
                    case > 62:
                        _programs.Add(element, ch[7]);
                        break;
                    case > 58:
                        _programs.Add(element, ch[8]);
                        break;
                    case > 56:
                        _programs.Add(element, ch[9]);
                        break;
                    case > 54:
                        _programs.Add(element, ch[10]);
                        break;
                    default:
                        _programs.Add(element, ch[11]);
                        break;
                }
            }
        }

        private void TransferAdmissionPoints(Student student)
        {
            foreach (var element in student.Subjects)
            {
                //  Transfer the credits to the student
                foreach (var (key, value) in _programs)
                {
                    if (element.Name == key) //&& value != "F")
                    {
                        if (value != "F")
                        {
                            student.Ap += element.Creds;
                        }

                        student.VerifiedPrograms.Add(key, value);
                    }
                }
            }
        }
    }
}