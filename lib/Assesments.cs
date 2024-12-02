namespace Console_StudentManagementSystem.lib
{
    internal class Assesments : Ms
    {
        private Student student { get;}
        private Ms Base { get; set; }
        private Dictionary<string, string> Programs = [];
        public Assesments(Student student, Ms obj)
        {
            var r = new Random();

            this.student = student;
            Base = obj;
            InitializePrograms(r.Next(0, 100));
            TransferAdmissionPoints();
            PushAssessments(this);
        }
        private void InitializePrograms(int score)
        {
            
            string[] ch =
            [
                "A", "A-", "B+", 
                "B", "B-", "C+",
                "C", "C-", "D+",
                "D", "D-", "F"
            ];
            
            foreach (var sub in Base.Subjects)
            {
                for (int i = 0; i < student.Enrolled.Count; i++)
                {
                    if (sub.Name == student.Enrolled[i])
                    {
                        if (score >= 0 && score <= 100)
                        {
                            switch (score)
                            {
                                case var j when score >= 90:
                                    Programs.Add(student.Enrolled[i], ch[0]);
                                    break;
                                case var j when score <= 90 && score > 86:
                                    Programs.Add(student.Enrolled[i], ch[1]);
                                    break;

                                case var j when score <= 86 && score > 82:
                                    Programs.Add(student.Enrolled[i], ch[2]);
                                    break;

                                case var j when score <= 82 && score > 78:
                                    Programs.Add(student.Enrolled[i], ch[3]);
                                    break;

                                case var j when score <= 78 && score > 74:
                                    Programs.Add(student.Enrolled[i], ch[4]);
                                    break;

                                case var j when score <= 74 && score > 70:
                                    Programs.Add(student.Enrolled[i], ch[5]);
                                    break;

                                case var j when score <= 70 && score > 66:
                                    Programs.Add(student.Enrolled[i], ch[6]);
                                    break;

                                case var j when score <= 66 && score > 62:
                                    Programs.Add(student.Enrolled[i], ch[7]);
                                    break;
                                case var j when score <= 62 && score > 58:
                                    Programs.Add(student.Enrolled[i], ch[8]);
                                    break;

                                case var j when score <= 58 && score > 56:
                                    Programs.Add(student.Enrolled[i], ch[9]);
                                    break;

                                case var j when score <= 56 && score > 54:
                                    Programs.Add(student.Enrolled[i], ch[10]);
                                    break;

                                case var j when score < 54:
                                    Programs.Add(student.Enrolled[i], ch[11]);
                                    break;
                                default:
                                    throw new Exception("Another mess occured !");
                            }
                            
                        }
                    }
                }
            }
        }
        
        private void TransferAdmissionPoints()
        {

            //  Ensure that the student has a passing grade
            //  Transfer the credits to the student
            foreach (var sub in Base.Subjects)
            {
                foreach(KeyValuePair<string, string> entry in Programs) 
                { 
                    if (sub.Name == entry.Key && entry.Value != "F") 
                    { 
                        student.Ap += sub.Creds; 
                        student.VerifiedPrograms.Add(entry.Key, entry.Value); 
                    }
                }
            }
        }
    }
}
