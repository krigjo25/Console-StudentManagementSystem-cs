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
        //  class member fields
        private string _dateOfBirth_; // dd.mm-yyyy
        private int _age_;
        private string _name_;
        private string _email_;
        private string _program_;
        private int _id_;

        //  Properties for the class fields
        private string Birthday
        {
            get => _dateOfBirth_;
            set
            {
                //  Ensure that the Value is correctly formatted
                if (DateTime.Now > DateTime.Parse(value)) { _dateOfBirth_ = value;}
            }
        } 
        private string Age
        {
            get => Convert.ToString(_age_);
            set
            {
                if ( calculate_date(_dateOfBirth_) > 0)
                {
                    _age_ = calculate_date(_dateOfBirth_);
                }
            }
        }
        
        private string Name
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
        private string Email
        { 
            get => _email_;
            set
            {
                _email_ = value;
            }
        }
        private string Program
        {
            get => _program_;
            set
            {
                _program_ = value;

            }
        }
        private int StudentId 
        { 
            get;
            set;
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
