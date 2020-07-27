using MvvmApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp.Models
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string email;
        public string Email
        {
            get { return email; }
            set 
            {
                if (Commons.IsValidEmail(value))
                    email = value;
                else
                    throw new Exception("Invalid Email");
            }
        }

        

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set 
            {
                var result = Commons.CalcAge(value);
                if (result > 150 || result < 0)
                    throw new Exception("Invalid Age");
                else
                    date = value;
            }
        }

        public Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }

        public bool IsBirthDay
        {
            get
            {
                return DateTime.Now.Month == Date.Month &&
                    DateTime.Now.Day == Date.Day;
            }
        }

        public bool IsAdult
        {
            get
            {
                return (Commons.CalcAge(Date) > 18);
            }
        }

        public string ChnZodiac
        {
            get
            {
                return Commons.GetChineseZodiac(Date);
            }
        }

        public string Zodiac
        {
            get
            {
                return Commons.GetZodiac(Date);
            }
        }
    }
}
