using System;
using System.Collections.Generic;

namespace TESTTT
{
    public abstract class Work
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public Course workCourse;
        public DateTime workDate;
        public string workContent;
        public List<Class> workClasses;

        public Work(Course workCourse, DateTime workDate, string workContent, List<Class> workClasses)
        {
            this.workCourse = workCourse;
            this.workDate = workDate;
            this.workContent = workContent;
            this.workClasses = workClasses;
        }
        public Course WorkCourse
        {
            get
            {
                return this.workCourse;
            }
            set
            {
                this.workCourse = value;
            }
        }
        public DateTime WorkDate
        {
            get
            {
                return this.workDate;
            }
            set
            {
                this.workDate = value;
            }
        }
        public string WorkContent
        {
            get
            {
                return this.workContent;
            }
            set
            {
                this.workContent = value;
            }
        }
        public List<Class> WorkClasses
        {
            get
            {
                return this.workClasses;
            }
            set
            {
                this.workClasses = value;
            }
        }
    }
}
