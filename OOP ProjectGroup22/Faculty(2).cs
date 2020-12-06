using System;
using System.Collections.Generic;

namespace TESTTT
{
    public class Faculty
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public List<User> allUsers { get; set; }

        public Faculty()
        {
            allUsers = new List<User>();
        }

        public void facultyToString()
        {
            string ans = null;
            foreach (User user in allUsers)
            {
                if (user is Student)
                {
                    ans += $"The person called { user.firstName } is a Student\n";
                }
                if (user is Admin)
                {
                    ans += $"The person called { user.firstName } is an Admin\n";
                }
                if (user is FacultyMember)
                {
                    ans += $"The person called { user.firstName } is a Teacher\n";
                }
            }
            Console.WriteLine(ans);
        }

        public void addAUser(User user)
        {
            allUsers.Add(user);
        }
        public bool connect(string login, string password)
        {
            bool ans = false;
            foreach (User user in allUsers)
            {
                if (login == user.login && password == user.password)
                {
                    ans = true;
                }
            }
            return ans;
        }
        public User findUser(string login, string password)
        {
            User ans = null;
            foreach (User user in allUsers)
            {
                if (login == user.login && password == user.password)
                {
                    ans = user;
                }
            }
            return ans;
        }
        public User findStudent(int studentID)
        {
            User ans = null;
            foreach (User user in allUsers)
            {
                if (studentID == user.userID && user is Student)
                {
                    ans = user;
                }
            }
            return ans;
        }
        public User findTeacher(int teacherID)
        {
            User ans = null;
            foreach (User user in allUsers)
            {
                if (teacherID == user.userID && user is FacultyMember)
                {
                    ans = user;
                }
            }
            return ans;
        }
        public void displayClassName(List<Class> listClass)
        {
            string ans = $"The different classes are : ";
            foreach (Class aClass in listClass)
            {
                ans += $"-> { aClass.className };   \n";
            }
            Console.WriteLine(ans);
        }
        public Class classExists(List<Class> allClasses)
        {

            Console.WriteLine("in which class do you want to add the student ?");
            string classNameSearched = Console.ReadLine();

            foreach (Class aClass in allClasses)
            {
                if (aClass.className == classNameSearched)
                {
                    return aClass;
                }
            }
            return null;
        }
    }
}
