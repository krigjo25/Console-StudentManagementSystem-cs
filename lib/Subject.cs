﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_StudentManageMentSystem_cs
{
    internal class Subject : StudentManagementSystem
    {

        public Subject(string name)
        {
            SubjectName = name;
            SubjectID = count + 1;
            count++;
        }

    }
}
