using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Student : Person
    {
        private string _studentId;

        /// <summary>
        /// Initializes a student object with fill-ins for personal information (constructor)
        /// </summary>
        public Student()
        :base("John", "Doe", "100 Dogwood Drive", "123-12-1234", "W0", 3)
        {
            StudentId = "S123";
        }

        /// <summary>
        /// Initializes a student that can be custom made (constructor)
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="wNum"></param>
        /// <param name="ssn"></param>
        public Student(string fName, string lName, string addy, string social, string wnum, string sId)
        : base(fName, lName, addy, social, wnum, 3)
        {
            StudentId = sId;
        }

  

        public string StudentId
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    if(value[0] == 'E')
                    {
                        _studentId = value;
                    }
                }
            }
            get
            {
                if(!string.IsNullOrEmpty(_studentId))
                {
                    return _studentId;
                }
                else
                {
                    return "No Student Id Set";
                }
            }
        }


    }
}
