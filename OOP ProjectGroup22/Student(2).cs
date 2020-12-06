using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class Student : User
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public double FeesDue { get; set; }
        public Class CurrentClass { get; set; }
        public SortedList<DateTime,double> feesMemory { get; set; }
        public SortedList<Course, DateTime> missingDay { get; set; }
        public List<Course> myCourses { get; set; }
        public List<Work> myWorks { get; set; }

        public Student(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            FeesDue = 8000;
            feesMemory = new SortedList<DateTime, double>();
            missingDay = new SortedList<Course, DateTime>();
            myCourses = new List<Course>();
            myWorks = new List<Work>();
        }
        public void showMyCalendar()
        {
            foreach(Course aCourse in myCourses)
            {
                aCourse.displayStudentCourse();
            }
        }
        public void Payfee()
        {
            Console.WriteLine($"You have to pay: {FeesDue} euros; \n");
            Console.WriteLine("Select the amount :");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (amount == FeesDue)
            {
                    FeesDue = 0;
                    Console.WriteLine("You've paid everythings.");
            }
            else if (amount < FeesDue)
            {
                    FeesDue -= amount;
                    feesMemory.Add(DateTime.Now, amount);
                    Console.WriteLine("You've paid " + amount + " euros.");
                    Console.WriteLine($"Now, you have to pay: {FeesDue} euros; \n");
            }
            else if(amount>FeesDue)
            {
                Console.WriteLine("That is too much !");
            }
        }
        public void displayAbscence()
        {
            string ans = null;
            foreach (KeyValuePair<Course, DateTime> abscence in missingDay)
            {
                ans+=$"-> You were absent at {abscence.Value} for the course {abscence.Key.courseName};\n";
            }
            if(ans==null)
            {
                Console.WriteLine("No abscences");
            }
            else Console.WriteLine("Your absences are :\n" + ans);
        }
        public void showMyWorks()
        {
            string ans = null;
            foreach (Work awork in myWorks)
            {
                if (awork is Assignement)
                {
                    ans += "The " + awork.workDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")) + ", there will " +
                        "be a work for the course " + awork.WorkCourse.courseName + ". And It will be an assignement.\n";

                }
                else
                {

                    ans += "The " + awork.workDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")) + ", there will " +
                        "be a work for the course " + awork.WorkCourse.courseName + ". And It will be an exam. \n";

                }
            }
            if (ans != null)
            {
                Console.WriteLine(ans);
            }
            else Console.WriteLine("No works...");
        }
    }
}
