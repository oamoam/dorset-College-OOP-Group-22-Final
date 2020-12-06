using System;
namespace TESTTT
{
    public class Date
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public string days { get; set; }
        public string moments { get; set; }
        public int lessonNumber { get; set; }

        public Date(string days, string moments)
        {
            this.days = days;
            this.moments = moments;
        }

        public Date(string days, string moments, int lessonNumber)
        {
            this.days = days;
            this.moments = moments;
            this.lessonNumber = lessonNumber;
        }

        public string courseToString()
        {
            return ("Each"+days+" during the "+moments+" you will have this course.");
        }
    }
}
