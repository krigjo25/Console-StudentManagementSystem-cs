using Console_StudentManagementSystem.lib;

namespace Console_StudentManagementSystem
{
    class ConsoleApp
    {
        public static void Main()
        {
            // Initalize a MS class
            MS ms = new MS();
            Console.WriteLine("Hello World!");
            
            // Initializing Students
            InitializeStudent("Kriss", "02/25/1994", ms);
            InitializeStudent("Terje", "02/25/1994", ms);
            
            
            
            
            foreach (var student in ms.Students)
            {
                Console.WriteLine($"The {student.Name} is a {student.Age} years old. ");
                
            }
        }

        private static void InitializeStudent(string name, string bday, MS obj)
        {
            obj.PushStudent(new Student(name, bday, obj));
        }
    }
}