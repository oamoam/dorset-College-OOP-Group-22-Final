using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class Assignement : Work
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH

        public Assignement(Course workCourse, DateTime workDate, string workContent, List<Class> workClasses) : base(workCourse, workDate, workContent, workClasses)
        {

        }

        
        public void DisplayAssignementInfos()
        {
            Console.WriteLine(WorkCourse.courseName + WorkDate + WorkClasses);
            Console.WriteLine(WorkContent);
        }
        
    }
}
