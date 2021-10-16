using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolment_Register
{
    class Student
    {

        private string _studentName, _studenDob, _studentAddress, _studentGender;

        public Student()
        {
            _studentName = "";
            _studenDob = "";
            _studentAddress = "";
            _studentGender = "";
        }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        
    }
}
