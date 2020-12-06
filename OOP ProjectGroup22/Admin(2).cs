using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class Admin : User
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public Faculty listUser = new Faculty();

        public Admin(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {

        }

        
        public Course createACourse()
        {
            Console.WriteLine("Write the name :");
            string courseName = Console.ReadLine();

            Console.WriteLine("Write the description :");
            string courseDescription = Console.ReadLine();

            Console.WriteLine("Write the objectives :");
            string courseObjectives = Console.ReadLine();
        
            Console.WriteLine("Write the number of lessons");
            int lessonsDedicated = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How long will a lesson be ?");
            int hoursDedicated = (Convert.ToInt32(Console.ReadLine()))*lessonsDedicated;

            Console.WriteLine("Which day ?");
            string day = Console.ReadLine().ToLower();

            Console.WriteLine("the lessons will be during the morning or evening ?");
            string moment = Console.ReadLine().ToLower();

            Date coursTT = new Date(day, moment, lessonsDedicated);

            

            Course newCourse = new Course(courseName, courseDescription, courseObjectives,lessonsDedicated,hoursDedicated,coursTT);
            Console.WriteLine(" The course is added! ");
            newCourse.displayLessonPlan();
            return newCourse;

        }

        public Class createAClass()
        {
            Console.WriteLine("Write the name of the class : ");
            string className = Console.ReadLine();

            List<Student> studentsOfTheNewClass = new List<Student>();

            Class newClass = new Class(className, studentsOfTheNewClass);

            Console.WriteLine(" The new class is added! ");

            return newClass;
        }


        public Admin AddAdmin()//idem pour student, faculty...
        {
            Console.WriteLine("Write his last name :");
            string lastName = Console.ReadLine();

            Console.WriteLine("Write his first name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Write his email :");
            string login = Console.ReadLine();

            Console.WriteLine("Write his password :");
            string password = Console.ReadLine();

            Console.WriteLine("Write his ID :");
            int userID = Convert.ToInt32(Console.ReadLine());

            Admin newAdmin = new Admin(lastName, firstName, login, password, userID);
            return newAdmin;


        }

        
        public Student addStudent()// idem pour faculty...
        {
            Console.WriteLine("Write his last name :");
            string lastName = Console.ReadLine();

            Console.WriteLine("Write his first name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Write his email :");
            string login = Console.ReadLine();

            Console.WriteLine("Write his password :");
            string password = Console.ReadLine();

            Console.WriteLine("Write his ID :");
            int userID = Convert.ToInt32(Console.ReadLine());

            Student newStudent = new Student(lastName, firstName, login, password, userID);
            return newStudent;

        }

        public FacultyMember addTeacher()
        {
            Console.WriteLine("Write his last name :");
            string lastName = Console.ReadLine();

            Console.WriteLine("Write his first name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Write his email :");
            string login = Console.ReadLine();

            Console.WriteLine("Write his password :");
            string password = Console.ReadLine();

            Console.WriteLine("Write his ID :");
            int userID = Convert.ToInt32(Console.ReadLine());

            FacultyMember newTeacher = new FacultyMember(lastName, firstName, login, password, userID);
            return newTeacher;

        }



        public void CheckPublicInfos(List<User> allUsers)
        {
            string ans = null;
            Console.WriteLine("Write the ID of the person that you're looking for.");
            int userID = Convert.ToInt32(Console.ReadLine());
            foreach (User users in allUsers)
            {
                if (users.userID == userID)
                {

                    ans += users.showPublicInformation() + "\n";
                }
            }
            if (ans == null) ans += "The person doesn't exist \n";
            Console.WriteLine(ans);
        }




        public bool alreadyInAClass(Student studentToAdd, List<Class> allClasses)
        {
            bool ans = false;
            foreach (Class aClass in allClasses)
            {
                if (aClass.classOfStudents.Contains(studentToAdd))
                {
                    ans = true;
                    Console.WriteLine("The student is already in a class :" + aClass.className);
                }
            }
            return ans;
        }


        public bool courseAlreadyExist(Course courseToAdd, List<Course> allCourses)
        {
            bool ans = false;
            foreach (Course aClass in allCourses)
            {
                if (courseToAdd.courseName==aClass.courseName)
                {
                    ans = true;
                    Console.WriteLine($"The course {courseToAdd.courseName} already exists");
                }
            }
            return ans;
        }




        








    }
}
