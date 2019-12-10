using System;
using System.Text;


namespace FlyuiaTestFramework.Models
{
    public class UserData
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserSecondName { get; set; }
        public string Mobile { get; set; }

        public UserData(string email, string username, string usersecondname, string mobile)
        {
            Email = email;
            UserName = username;
            UserSecondName = usersecondname;
            Mobile = mobile;
        }
    }
}
