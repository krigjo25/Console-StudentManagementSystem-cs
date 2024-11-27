using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace console_StudentManageMentSystem_cs
{
    internal class StudentManagementSystem
    {
        // Universal
        protected int count;
        //  Stuedent fields

        private int _id_;
        private int _age_;
        private string _name_;
        private string _email_;
        private string _program_;
        private string _dateOfBirth_; // dd.mm-yyyy

        //  Properties for students
        protected string Birthday
        {
            get => _dateOfBirth_;
            set
            {
                //  Ensure that the Value is correctly formatted
                if (DateTime.Now > DateTime.Parse(value)) { _dateOfBirth_ = value;}
            }
        } 
        protected int Age
        {
            get => _age_;
            set
            {
                if ( calculate_date(_dateOfBirth_) > 0)
                {
                    _age_ = calculate_date(_dateOfBirth_);
                }
            }
        }
        
        protected string Name
        {
            get => _name_;
            set
            {
                string pattern = "[^a-zA-Z$]";
                if (Regex.IsMatch(value, pattern))
                {
                    _name_ = value;
                }
            }
        }
        protected string Email
        { 
            get => _email_;
            set
            {
                _email_ = value;
            }
        }
        protected string Program
        {
            get => _program_;
            set
            {
                _program_ = value;

            }
        }
        protected int StudentId 
        { 
            get => _id_;
            set
            {
                _id_ = count + 1;
            }
        }

        // Subject fields
        private int _creds_;
        private int _subjectid_;
        private string _subjectname_;

        protected int Creds
        {
            get => _creds_;
            set
            {
                _creds_ = value;
            }
        }
        protected int SubjectID
        { 
            get => _subjectid_;
            set
            {
                _subjectid_ = value;
            }
        }
        protected string SubjectName { 
            get => _subjectname_;
            set
            {
                _subjectname_ = value;
            }
        }

        // Characters
        // references to a student 
        // references to a subject
        // value

        private int calculate_credits(int d, int m)
        {
            /*
             * Clarification of  this algorthm is based on google Gemini's calculations
             * Where original Algorithm was introduced as Credits Value = Difficulty (Total Workload) * Weeks
             *  CV = TW * Multiplier (0.1),  TW = Duration * weeks 
             
             */
            //  Constant multiplier
            float n = 0.1f;
            int TW = d * m;
            return (int)Math.Round(TW * n);
        }
        private  int calculate_date(string bday)
        {
            // Initializing n days / year
            int n = 365;

            //  Fetch todays date
            DateTime today = DateTime.Today;

            //  Initializing the date to compare
            DateTime date = new DateTime();
           date = DateTime.Parse(bday);

            // Calculates the difference between todays date and argument
            TimeSpan diff = today.Date - date.Date ;

            //  Ensure that the user's day is less than todays day.
            if ( today.Month < date.Month || (today.Month == date.Month && today.Day < date.Day) )
            {
                return (int)(diff.TotalDays / n) - 1;

            }

            //  Return age
            return (int)diff.TotalDays / n;

        }
    }

  
}
