namespace Console_StudentManagementSystem.lib
{
    internal class Subject : Ms
    {
        public int Creds { get; set; }

        public string Name { get; set; }

        private Subject(string name, int d, int w)
        {
            Name = name;
            Creds = calculate_credits(d, w);
            
        }
        
        public static void InitializeSubject(string arg, int arg1, int arg2, Ms @base)
        {
            var subject = new Subject(arg, arg1, arg2);
            @base.PushSubject(subject);
        }

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

            //  UNS's constant multiplier
            const float n = 0.0015f;
            
            int tw = d * w;
            return (int)Math.Round((tw)* n);
        }

        

    }
}
