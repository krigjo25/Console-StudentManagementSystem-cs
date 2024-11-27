using console_StudentManageMentSystem_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Console_StudentManagementSystem.lib
{
    internal class Student : StudentManagementSystem
    {

        public Student(string name, string bday, string email, string prog = "IT Information Technology")
        {
            Name = name;  //    Krigjo25    
            Email = email;  //  krigjo25@domene.no
            Birthday = bday; // 25/02/1994
            Program = prog; // Path of study 
            StudentId = count + 1;
            count++;
        }


    }
}
