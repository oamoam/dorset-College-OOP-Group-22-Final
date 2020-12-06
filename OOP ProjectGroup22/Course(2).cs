using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class Course
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public string courseName { get; set; }
        public string courseDescription { get; set; }
        public string courseObjectives { get; set; }
        public int hoursDedicated { get; set; }
        public int lessonsDedicated { get; set; }
        public Date courseDate { get; set; }

        public Course(string courseName, string courseDescription, string courseObjectives, int lessonsDedicated, int hoursDedicated, Date courseDate)
        {
            this.courseName = courseName;
            this.courseDescription = courseDescription;
            this.courseObjectives = courseObjectives;
            this.hoursDedicated = hoursDedicated;
            this.lessonsDedicated = lessonsDedicated;
            this.courseDate = courseDate;
        }

        public void displayLessonPlan()
        {
            string info = $"Course name : {courseName};\nCourse description : {courseDescription}; \nHours dedicated for this course : {hoursDedicated} hours;\nNumber of lessons : {lessonsDedicated} lessons;\n";
            info += $"This course objectives are : {courseObjectives}  ;\n";
            info += $"The timetable : ";
            string info2 = null;
            info2 = "-> Each lesson will be the " + courseDate.days + " during the " + courseDate.moments + "; \n";
            Console.WriteLine(info);
            Console.WriteLine(info2);
        }

        public void displayStudentCourse()
        {
            Console.WriteLine($"For the course '{courseName}' the lesson will be the {courseDate.days} during the {courseDate.moments}; \n");
        }

    }
}
