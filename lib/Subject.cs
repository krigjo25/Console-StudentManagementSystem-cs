namespace Console_StudentManagementSystem.lib
{
    internal class Subject : Ms
    {
        protected internal Subject(string name, int duration, int weeks, int n, int capacity = 25)
        {
            Name = name;
            Creds = calculate_credits(duration, weeks);
            Console.WriteLine(Name, Creds);
            AdmissionScore = calculate_admissionScore(n, capacity);
        }

        public int Creds { get; }
        public float AdmissionScore { get; set; }
        public string Name { get; }

        // Calculate the Credentails

        private int calculate_credits(int d, int w)
        {
            /*
             * The revised algorithm is based on Google Gemini's calculations, where:
                    Credits Value (CV) = Total Workload (TW) * Multiplier (0.1)
                    Total Workload (TW) = Duration * Weeks

            * The original algorithm was defined as:
                    Credits Value (CV) = Difficulty (Total Workload (TW)) * Weeks

             */

            //  USN's constant multiplier
            const float n = 0.0015f;

            int tw = d * w;
            return (int)Math.Round(tw * n);
        }

        private float calculate_admissionScore(float n, int capacity)
        {
            if (n > capacity)
            {
                n *= capacity;
                n /= capacity;
                return (float)Math.Sqrt(n);
            }

            return 0.0f;
        }
    }
}