using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class FacultyMember : User
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public List<Course> courseTeached;
        public  List<Class> classTeached;
        public List<Work> workCreated;

        public FacultyMember(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            courseTeached = new List<Course>();
            classTeached = new List<Class>();
            workCreated = new List<Work>();
        }

        public List<Course> CourseTeached
        {
            get
            {
                return this.courseTeached;
            }
            set
            {
                this.courseTeached = value;
            }
        }
        public List<Class> ClassTeached
        {
            get
            {
                return this.classTeached;
            }
            set
            {
                this.classTeached = value;
            }
        }
        public void dipslayMyClasses()
        {
            string ans = null;
            foreach (Class aClass in classTeached)
            {
                ans+="-> " + aClass.className + "\n";
            }
            if (ans != null)
            {
                Console.WriteLine("Your classes are : \n");
                Console.WriteLine(ans);
            }
            else Console.WriteLine("You don't have any classes");
        }
        public void addAClassToMyList(Class classToAdd)
        {
            bool ans = true;
            foreach (Class aClass in classTeached)
            {
                if (classToAdd.className == aClass.className)
                {
                    Console.WriteLine("You already have this class in your list.");
                    ans = false;
                }
            }
            if (ans == true)
            {
                ClassTeached.Add(classToAdd);
            }
        }
        public bool classExists(string classNameToAdd, List<Class> allClasses)
        {
            bool ans = false;
            foreach (Class aClass in allClasses)
            {
                if (classNameToAdd == aClass.className)
                {
                    return true;
                }
            }
            return ans;
        }
        public void addACourseToMyList(Course courseToAdd)
        {
            bool ans = true;
            foreach (Course aCourse in courseTeached)
            {
                if (courseToAdd.courseName == aCourse.courseName)
                {
                    Console.WriteLine("You already have this course in your list.");
                    ans = false;
                }
            }
            if (ans ==true)
            {
                courseTeached.Add(courseToAdd);
            }
        }
        public bool courseExists(string courseNameToAdd, List<Course> allCourses)
        {
            bool ans = false;
            foreach (Course aCourse in allCourses)
            {
                if (courseNameToAdd == aCourse.courseName)
                {
                    return true;
                }
            }
            return ans;

        }
        public void dipslayMyCourses()
        {
            string ans = null;
            
            foreach (Course aCours in courseTeached)
            {
                ans+="-> " + aCours.courseName + "\n";
            }
            if (ans != null)
            {
                Console.WriteLine("Your courses are : \n");
                Console.WriteLine(ans);
            }
            else Console.WriteLine("You don't have any courses");

        }
        public bool courseExistsInMyList(string courseNameToSearched)
        {
            bool ans = false;
            foreach (Course aCourse in courseTeached)
            {
                if (courseNameToSearched == aCourse.courseName)
                {
                    return true;
                }
            }
            return ans;

        }
        private Course returnACourse(string courseNameToSearched )
        {
            foreach (Course aCourse in courseTeached)
            {
                if (courseNameToSearched == aCourse.courseName)
                {
                    return aCourse;
                }
            }
            return null;
        }
        public bool classExistsInMyList(string classNameToSearched)
        {
            bool ans = false;
            foreach (Class aClass in classTeached)
            {
                if (classNameToSearched == aClass.className)
                {
                    return true;
                }
            }
            return ans;
        }
        public void CreateWork()
        {
            bool mycourses = false;
            Course workCourse = null;
            while (mycourses != true)
            {
                dipslayMyCourses();
                Console.WriteLine("For which of your courses do you want to add a work ?");
                string courseName = Console.ReadLine();
                mycourses = courseExistsInMyList(courseName);
                if (mycourses == true) workCourse = returnACourse(courseName);

            }
            Console.WriteLine("Write the coef of work (1 means it will be an assignement) ");
            int examCoeff = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the day of work (the number)");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the month of work (the number)");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the year of work ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the hour of work ");
            int hour = Convert.ToInt32(Console.ReadLine());

            DateTime workDate = new DateTime(year, month, day, hour, 0, 0);

            Console.WriteLine("Write the content of the work ");
            string workContent = Console.ReadLine();

            if (examCoeff == 1)
            {
                workCreated.Add(new Assignement(workCourse, workDate, workContent, ClassTeached));
                addWorkForStudent(new Assignement(workCourse, workDate, workContent, ClassTeached));
            }
            else
            {
                List<double> examGrades = new List<double>();
                workCreated.Add(new Exam(examGrades, false, examCoeff, workCourse, workDate, workContent, ClassTeached));
                addWorkForStudent(new Exam(examGrades, false, examCoeff, workCourse, workDate, workContent, ClassTeached));
            }
        }
        public void showAllTheWorks()
        {
            string ans = null;
            foreach(Work awork in workCreated)
            {
                if (awork is Assignement)
                {
                    ans+="The "+awork.workDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"))+ ", there will " +
                        "be a work for the course "+awork.WorkCourse.courseName+". And It will be an assignement.\n";
                
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
        public void CheckOwnStudents()
        {
           string ans = null;
           foreach(Class aClass in classTeached)
           {
                ans += ("In the class '" + aClass.className + "' your students are : \n");
                foreach (Student aStudent in aClass.classOfStudents)
                {
                    ans += "-> "+aStudent.firstName+" "+aStudent.lastName+", "+aStudent.userID+";\n";
                }
           }
            if (ans != null)
            {
                Console.WriteLine(ans);
            }
            else Console.WriteLine("You don't have any student");
        }
        public void FindOneOfMyStudent(int IDSearched) 
        {
            string ans = null;
            foreach (Class aClass in classTeached)
            {
                foreach (Student aStudent in aClass.classOfStudents)
                {
                    if(IDSearched==aStudent.userID)
                    {
                        ans += "Student found \n";
                        Console.WriteLine(ans);
                        aStudent.PublicInformation();
                    }
                }
            }
            if (ans == null)
            {
                Console.WriteLine("You don't have this student");
            }
        }
        public Student returnOneOfMyStudent(int IDSearched)
        {
            Student studentSearched = null;
            foreach (Class aClass in classTeached)
            {
                foreach (Student aStudent in aClass.classOfStudents)
                {
                    if (IDSearched == aStudent.userID)
                    {
                        studentSearched= aStudent;
                    }
                }
            }
            return studentSearched;
        }
        public void addAbscence()
        {
            bool mycourses = false;
            Course missingCourse = null;
            while (mycourses != true)
            {
                dipslayMyCourses();
                Console.WriteLine("For which of your courses do you want to add a work ?");
                string courseName = Console.ReadLine();
                mycourses = courseExistsInMyList(courseName);
                if (mycourses == true) missingCourse = returnACourse(courseName);

            }

            Console.WriteLine("Type the ID of the missing student");
            int missingStudentID = Convert.ToInt32(Console.ReadLine());
            Student missingStudent = returnOneOfMyStudent(missingStudentID);
            missingStudent.missingDay.Add(missingCourse, DateTime.Now);
        }
        public void addTimeForStudent()
        {
            foreach (Class aClass in classTeached)
            {
                foreach (Student aStudent in aClass.classOfStudents)
                {
                    foreach(Course aCourse in courseTeached)
                    {
                        if (!aStudent.myCourses.Contains(aCourse))
                        {
                            aStudent.myCourses.Add(aCourse);
                        }
                    }
                }
            }
        }
        public void addWorkForStudent(Work aWork)
        {
            foreach (Class aClass in classTeached)
            {
                foreach (Student aStudent in aClass.classOfStudents)
                {
                    aStudent.myWorks.Add(aWork);
                }
            }
        }
    }
}
