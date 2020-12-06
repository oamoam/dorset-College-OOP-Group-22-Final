using System;
using System.Collections.Generic;

namespace TESTTT
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH

            // Things to create for the memory
            Faculty School = new Faculty();
            Fees fee = new Fees();
            List<Class> allclasses = new List<Class>();
            List<Course> allcourses = new List<Course>();

            //Create some courses for the memory:
            Date mathsDate = new Date("monday", "morning", 5);
            Course mathematics = new Course("Mathematics", "You will learn how to write numbers", "You will have to write 10 numbers", 5, 2, mathsDate);
            allcourses.Add(mathematics);

            Date OPPDate = new Date("tuesday", "evening", 6);
            Course OOP = new Course("OOP", "C#", "You will have to do a project", 6, 3, OPPDate);
            allcourses.Add(OOP);

            //Create the only Administrator
            Admin admin = new Admin("TEST1AD", "Luc", "1", "a", 1);
            School.addAUser(admin);

            //Create the first two Students of the Group A
            Student student1 = new Student("TEST2ST", "Marie", "100@gmail.com", "qwerty", 100);
            School.addAUser(student1);
            Student student2 = new Student("TEST3ST", "Jean", "200@gmail.com", "qwerty", 200);
            School.addAUser(student2);
            List<Student> studentsOfGroupA = new List<Student>();
            studentsOfGroupA.Add(student1);
            studentsOfGroupA.Add(student2);
            Class GroupA = new Class("Group A", studentsOfGroupA);


            //Create the first two Students of the Group B
            Student student3 = new Student("TEST4ST", "Luc", "300@gmail.com", "qwerty", 300);
            School.addAUser(student3);
            Student student4 = new Student("TEST5ST", "Laura", "400@gmail.com", "qwerty", 400);
            School.addAUser(student4);
            List<Student> studentsOfGroupB = new List<Student>();
            studentsOfGroupB.Add(student3);
            studentsOfGroupB.Add(student4);
            Class GroupB = new Class("Group B", studentsOfGroupB);

            //Add the new classes to the memory of all classes
            allclasses.Add(GroupA);
            allclasses.Add(GroupB);

            //Create a Teacher
            FacultyMember teacher1 = new FacultyMember("TEST1FM", "Bruce", "10", "b", 10);
            School.addAUser(teacher1);

            //Add a course and class to teacher1
            teacher1.classTeached.Add(GroupA);
            teacher1.courseTeached.Add(OOP);

            //Début application
            bool start = true;

            while (start == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                string title = $"- Welcome to the login section.  -";  
                int leadingSpaces = (90 - title.Length) / 2;
                Console.WriteLine(title.PadLeft(leadingSpaces + title.Length)); 
                Console.WriteLine();

                string loginMessage = $"- Enter your login : -";
                Console.WriteLine(loginMessage.PadLeft(leadingSpaces + loginMessage.Length));
                string login = Console.ReadLine();

                string passwordMessage = $"- Enter your password : -";
                Console.WriteLine(passwordMessage.PadLeft(leadingSpaces + passwordMessage.Length));
                string password = Console.ReadLine();

                bool connection = School.connect(login, password);
                Console.ResetColor();
                Console.Clear();

                if (connection == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*Error ! Wrong Login or password*");
                    Console.ResetColor();
                }
                while (connection == true)
                {
                    User personConnected = School.findUser(login, password);

                    // For an Admin
                    if (personConnected is Admin)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Admin adminConnected = (Admin)personConnected;
                        string adminTitle = $"- You're in the Administrator section.  -";
                        int leadingSpacesAdmin = (90 - adminTitle.Length) / 2;
                        Console.WriteLine(adminTitle.PadLeft(leadingSpacesAdmin + adminTitle.Length));
                        Console.WriteLine();
                        Console.WriteLine("\nWhat do you want to do ? \n1-> Add an Admin \n2-> Add a Student\n3-> Add a Teacher " +
                            "\n4-> Add a Course \n5-> Check public informations from an ID " +
                            "\n6-> Check a student's fees \n7-> See all the classes infos \n8-> Create a class " +
                            "\n9-> Add a student to a class \n\n20-> Logout \n");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Admin newAdmin = adminConnected.AddAdmin();
                                School.addAUser(newAdmin);
                                break;
                            case 2:
                                Student newStudent = adminConnected.addStudent();
                                School.addAUser(newStudent);
                                break;
                            case 3:
                                FacultyMember newTeacher = adminConnected.addTeacher();
                                School.addAUser(newTeacher);
                                break;
                            case 4:
                                Course newCourse = adminConnected.createACourse();
                                if (admin.courseAlreadyExist(newCourse, allcourses) == false)
                                {
                                    Console.WriteLine("The course is added");
                                    allcourses.Add(newCourse);
                                }
                                else Console.WriteLine("The course already exists ");
                                break;
                            case 5:
                                adminConnected.CheckPublicInfos(School.allUsers);
                                break;
                            case 6:
                                Console.WriteLine("write the ID of the student");
                                int ID = Convert.ToInt32(Console.ReadLine());
                                Student personSearched = (Student)School.findStudent(ID);
                                if (personSearched is Student)
                                {
                                    fee.displayFeeinfo(personSearched);
                                }
                                else Console.WriteLine("It isn't the ID of a Student or doesn't exist");
                                break;
                            case 7:
                                Console.WriteLine("There are " + allclasses.Count + " different classes :");
                                foreach (Class classindex in allclasses)
                                {
                                    classindex.displayClassInfo();
                                }
                                break;
                            case 8:
                                allclasses.Add(adminConnected.createAClass());
                                break;
                            case 9:
                                School.displayClassName(allclasses);
                                Class classSearched = School.classExists(allclasses);
                                if (classSearched != null)
                                {
                                    Console.WriteLine("write the ID of the student");
                                    int studentID = Convert.ToInt32(Console.ReadLine());
                                    Student personSearched2 = (Student)School.findStudent(studentID);
                                    if (personSearched2 is Student)
                                    {
                                        if (adminConnected.alreadyInAClass(personSearched2, allclasses) == false)
                                        {
                                            classSearched.classOfStudents.Add(personSearched2);
                                            Console.WriteLine("The student is added to the new class.");
                                        }
                                    }
                                    else Console.WriteLine("It isn't a Student or doesn't exist");
                                }
                                else Console.WriteLine("the class doesn't exist");
                                break;
                            case 20:
                                Console.WriteLine("Good bye !\n");
                                connection = false;
                                break;
                        }
                        Console.ResetColor();
                    }
                    //For a Student
                    if (personConnected is Student)
                    {
                        Student studentConnected = (Student)personConnected;

                        Console.ForegroundColor = ConsoleColor.Green;
                        string studentTitle = $"- You're in the Student section.  -";
                        int leadingSpacesStudent = (90 - studentTitle.Length) / 2;
                        Console.WriteLine(studentTitle.PadLeft(leadingSpacesStudent + studentTitle.Length));
                        Console.WriteLine();
                        Console.WriteLine("\nWhat do you want to do ? \n1-> Pay the fees \n2-> See your fees memory\n3-> Check your personal informations " +
                            "\n4-> See your absences \n5-> See your class \n6-> See your timetable \n7-> See your works  \n\n20-> Logout\n");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                studentConnected.Payfee();
                                break;
                            case 2:
                                fee.displayFeeMemory(studentConnected);
                                break;
                            case 3:
                                studentConnected.PersonalInformation();
                                break;
                            case 4:
                                studentConnected.displayAbscence();

                                break;
                            case 5:
                                string ans = "You are in the class called : ";
                                foreach(Class aClass in allclasses)
                                {
                                    if(aClass.classOfStudents.Contains(studentConnected))
                                    {
                                        ans+=aClass.className+"\n";
                                    }
                                }
                                Console.WriteLine(ans);
                                break;
                            case 6:
                                studentConnected.showMyCalendar();
                                break;
                            case 7:
                                studentConnected.showMyWorks();
                                break;
                            case 20:
                                Console.WriteLine("Good bye !\n");
                                connection = false;
                                break;
                        }
                        Console.ResetColor();
                    }
                    //For a Teacher
                    if (personConnected is FacultyMember)
                    {
                        FacultyMember teacherConnected = (FacultyMember)personConnected;

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        string studentTitle = $"- You're in the Teacher section.  -";
                        int leadingSpacesStudent = (90 - studentTitle.Length) / 2;
                        Console.WriteLine(studentTitle.PadLeft(leadingSpacesStudent + studentTitle.Length));
                        Console.WriteLine();
                        Console.WriteLine("\nWhat do you want to do ? \n1-> Check your personal informations \n2-> Add a course to my list " +
                            "\n3-> Display my courses \n4-> Add a class to my list \n5-> Display my classes" +
                            "\n6-> See your students\n7-> Check the public information of one of your students " +
                            "\n8-> Add a work \n9-> Display all the works \n10-> Set an abscence for a student" +
                            "\n11-> Update the calendars of my students \n\n20-> Logout\n");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                teacherConnected.PersonalInformation();
                                break;
                            case 2:
                                Console.WriteLine("The courses are : \n");
                                foreach (Course aCours in allcourses)
                                {
                                    Console.WriteLine("-> " + aCours.courseName + "\n");
                                }
                                Console.WriteLine("Which course do you want to add to your list ? \n");
                                string courseAnswer = Console.ReadLine();
                                Course courseToAdd = null;
                                bool check = teacherConnected.courseExists(courseAnswer, allcourses);
                                if (check == true)
                                {
                                    foreach (Course aCours in allcourses)
                                    {
                                        if (aCours.courseName == courseAnswer)
                                        {
                                            courseToAdd = aCours;
                                        }
                                    }
                                }
                                else Console.WriteLine("The course doesn't exists.  \n");
                                if (courseToAdd != null)
                                {
                                    teacherConnected.addACourseToMyList(courseToAdd);
                                }
                                break;
                            case 3:
                                teacherConnected.dipslayMyCourses();
                                break;
                            case 4:
                                Console.WriteLine("The classes are : \n");
                                foreach (Class aClass in allclasses)
                                {
                                    Console.WriteLine("-> " + aClass.className + "\n");
                                }
                                Console.WriteLine("Which class do you want to add to your list ? \n");
                                string classAnswer = Console.ReadLine();
                                Class classtoAdd = null;
                                bool checkClasses = teacherConnected.classExists(classAnswer, allclasses);
                                if (checkClasses == true)
                                {
                                    foreach (Class aClass in allclasses)
                                    {
                                        if (aClass.className == classAnswer)
                                        {
                                            classtoAdd = aClass;
                                        }
                                    }
                                }
                                else Console.WriteLine("The class doesn't exists.  \n");
                                if (classtoAdd != null)
                                {
                                    teacherConnected.addAClassToMyList(classtoAdd);
                                }
                                break;
                            case 5:
                                teacherConnected.dipslayMyClasses();
                                break;
                            case 6:
                                teacherConnected.CheckOwnStudents();
                                break;
                            case 7:
                                Console.WriteLine("write the ID of the student");
                                int studentID = Convert.ToInt32(Console.ReadLine());
                                teacherConnected.FindOneOfMyStudent(studentID);
                                break;
                            case 8:
                                teacherConnected.CreateWork();
                                break;
                            case 9:
                                teacherConnected.showAllTheWorks();
                                break;
                            case 10:
                                teacherConnected.addAbscence();
                                break;
                            case 11:
                                teacherConnected.addTimeForStudent();
                                Console.WriteLine("Calendars updated");
                                break;
                            case 20:
                                Console.WriteLine("Good bye !\n");
                                connection = false;
                                break;
                        }
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
