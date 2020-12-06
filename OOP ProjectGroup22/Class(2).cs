using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTTT
{
    public class Class
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public string className { get; set; }
        public List<Student> classOfStudents { get; set; }

        public Class(string className, List<Student> classOfStudents)
        {
            this.className = className;
            this.classOfStudents = classOfStudents;
        }


        public void displayClassMembers()
        {
            string ans = $"The students of the class { className } are : \n";
            foreach(Student student in classOfStudents)
            {
                ans += $"-> { student.firstName };   \n";
            }
            Console.WriteLine(ans);
        }



        public void displayClassInfo()
        {
            string ans = $"In the class { className }, there are { classOfStudents.Count() } students.";
            Console.WriteLine(ans);
        }

        

    }
}
