using System;
using System.Text;
using FlyuiaTestFramework.Models;

namespace FlyuiaTestFramework.Services
{
    class UserDataCreator
    {
       public static UserData FilledUserFields()
       {
            return new UserData(TestDataReader.GetTestData("Email"), TestDataReader.GetTestData("UserName"), TestDataReader.GetTestData("UserSecondName"), TestDataReader.GetTestData("Mobile"));
       }
    }
}
