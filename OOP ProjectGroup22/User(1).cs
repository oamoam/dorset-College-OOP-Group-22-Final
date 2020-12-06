using System;
namespace TESTTT
{
    public abstract class User
    {
        // 23209 Adrien SFEIR, 23193 Paul CROSNIER, 22846 Brice OUCHIKH
        public string lastName { get; }
        public string firstName { get; }
        public string login { get; }
        public string password { get; }
        public int userID { get; }

        public User(string lastName, string firstName, string login, string password, int userID)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.login = login;
            this.password = password;
            this.userID = userID;
        }

        public void PersonalInformation()
        {
            Console.WriteLine($"The personal information are : \n First Name : {firstName} \n Last Name : {lastName} \n ID : {userID} \n e-mail : {login} \n password : {password} \n ");
        }

        public void PublicInformation()
        {
            Console.WriteLine($" The public information are : \n First Name : {firstName} \n Last Name : {lastName} \n ID : {userID} \n");
        }

        public string showPublicInformation()
        {
            return $" The public information are : \n First Name : {firstName} \n Last Name : {lastName} \n ID : {userID} \n";
        }

    }
}
