using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class Exam : Work
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        List<Double> examGrades;
        bool examIsCorriged;
        int examCoeff;

        public Exam(List<double> examGrades, bool examIsCorriged, int examCoeff, Course workCourse, DateTime workDate, string workContent, List<Class> workClasses) : base(workCourse, workDate, workContent, workClasses)
        {
            this.examGrades = examGrades;
            this.examIsCorriged = examIsCorriged;
            this.examCoeff = examCoeff;
        }
        public List<double> ExamGrades
        {
            get
            {
                return this.examGrades;
            }
            set
            {
                this.examGrades = value;
            }
        }
        public bool ExamIsCorriged
        {
            get
            {
                return this.examIsCorriged;
            }
            set
            {
                this.examIsCorriged = value;
            }
        }
        public int ExamCoeff
        {
            get
            {
                return this.examCoeff;
            }
            set
            {
                this.examCoeff = value;
            }
        }
    }
}
