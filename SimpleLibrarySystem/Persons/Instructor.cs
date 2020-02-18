using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Instructor : Person
    {
        private string _instructorId;


        public Instructor()
        : base("John", "Doe", "100 Dogwood Drive", "123-12-1234", "W0", 5)
        {

            InstructorId = "E123";
        }

        public Instructor(string fName, string lName, string addy, string social, string wnum, string instructorId)
        : base(fName, lName, addy, social, wnum, 5)
        {

            InstructorId = instructorId;
        }


        public string InstructorId
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    if(value[0] == 'E')
                    {
                        _instructorId = value;
                    }
                }
            }
            get
            {
                if(!string.IsNullOrEmpty(_instructorId))
                {
                    return _instructorId;
                }
                else
                {
                    return "No Instructor Id Set";
                }
            }
        }

        
    }
}
