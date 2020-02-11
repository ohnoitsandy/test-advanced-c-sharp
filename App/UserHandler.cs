using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Console;
using CoreTest.Entities;
using CoreTest.Utilities;

namespace CoreTest.App
{
    public class UserHandler
    {
        public static List<User> Users;

        static UserHandler()
        {
            Users = new List<User>();
        }

        public static void Start()
        {
            string filePath = @"/home/sandy/Documents/platzi/test-advanced-c-sharp/User.xml";
            if (File.Exists(filePath))
                WriteLine("The file already exists");
            File.Create(filePath);
        }

         // public static void End()
         // {
         //     XmlDocument document = new XmlDocument();
         //     document.Load("User.xml");
         //     XmlNodeList userNodes = document.SelectNodes("//Users/User");
         //     foreach (XmlNode userNode in userNodes)
         //     {
         //         userNode.Attributes["Id"].Value = Users.
         //     }
         // }
        
        //USER CRUD
        
        #region CreateUser
        public static void CreateUser()
        {
            UiPainter.PaintAddTitle();
            User user = new User();
            AddFirstName(user);
            AddLastName(user);
            AddMoLastName(user);
            AddBirthDate(user);
            SetMaritalStatus(user);
            SetBloodType(user);
            SetGender(user);
            Users.Add(user);
        }
        
        private static void AddFirstName(User user)
        {
            UiPainter.PaintAddFirstName();
            user.FirstName = ReadLine();
            Clear();
        }
        private static void AddLastName(User user)
        {
            UiPainter.PaintAddLastName();
            user.LastName = ReadLine();
            Clear();
        }

        private static void AddMoLastName(User user)
        {
            UiPainter.PaintAddMoLastName();
            user.MothersLastName = ReadLine();
            Clear();
        }
        
        private static void AddBirthDate(User user)
        {
            UiPainter.PaintAddBirthDate();
            user.Birthdate = DateTime.Parse(ReadLine());
            Clear();
        }
        
        private static void SetMaritalStatus(User user)
        {
            UiPainter.PaintSetMaStatus();
            switch (ReadLine())
            {
                case "1":
                    user.MaritalStatus = MaritalStatus.Single;
                    break;
                case "2":
                    user.MaritalStatus = MaritalStatus.Married;
                    break;
            }
            Clear();
        }

        private static void SetBloodType(User user)
        {
            UiPainter.PaintSetBloodType();
            user.BloodType = ReadLine() switch
            {
                "1" => BloodType.Orhpositive,
                "2" => BloodType.Orhnegative,
                "3" => BloodType.Brhpositive,
                "4" => BloodType.Brhnegative,
                "5" => BloodType.Arhpositive,
                "6" => BloodType.Arhnegative,
                "7" => BloodType.Abrhpositive,
                "8" => BloodType.Abrhnegative,
                _ => user.BloodType
            };
            Clear();
        }

        private static void SetGender(User user)
        {
            UiPainter.PaintSetGender();
            user.Gender = ReadLine() switch
            {
                "1" => Gender.Female,
                "2" => Gender.Male,
                "3" => Gender.NonBinary,
                _ => user.Gender
            };
            Clear();
        }
        #endregion

        #region ModifyUser
        public static void EditUser()
        {
            var query = SearchUser();
            UiPainter.PaintEdit();
            string newValue = ReadLine();
            foreach (var user in query)
            {
                int index = Users.FindIndex(res => res.FirstName == user.FirstName);
                user.FirstName = newValue;
                Users.Insert(index, user);
            }
        }
        #endregion

        #region DeleteUser

        public static void DeleteUser()
        {
            var query = SearchUser();
            UiPainter.PaintDelete();
            foreach (var user in query)
            {
                Users.Remove(user);
            }
        }
        #endregion

        #region SearchUser
        public static IEnumerable<User> SearchUser()
        {
            UiPainter.PaintSearch();
            string selection;
            IEnumerable<User> query = null;
            switch (ReadLine())
            {
                case "1":
                    UiPainter.PaintAddFirstName();
                    selection = ReadLine();
                     query = from user in Users where user.FirstName == selection select user;
                    UiPainter.PaintResult(query);
                    break;
                case "2":
                    UiPainter.PaintAddMoLastName();
                    selection = ReadLine();
                    query = from user in Users where user.LastName == selection select user;
                    UiPainter.PaintResult(query);
                    break;
                case "3":
                    UiPainter.PaintAddMoLastName();
                    selection = ReadLine();
                    query = from user in Users where user.MothersLastName == selection select user;
                    break;
                case "4":
                    UiPainter.PaintAddBirthDate();
                    selection = ReadLine();
                    query = from user in Users where user.Birthdate.ToString() == selection select user;
                break;
                case "5":
                    UiPainter.PaintSetMaStatus();
                    selection = ReadLine();
                    query = from user in Users where selection != null && String.Equals(user.MaritalStatus.ToString(),
                                                         selection, StringComparison.CurrentCultureIgnoreCase) select user;
                    break;
                case "6":
                    UiPainter.PaintSetBloodType();
                    selection = ReadLine();
                    query = from user in Users
                        where user.MaritalStatus.ToString().ToUpper() == selection.ToUpper()
                        select user;
                    break;
                case "7":
                    UiPainter.PaintSetGender();
                    selection = ReadLine();
                    query = from user in Users
                        where user.Gender.ToString().ToUpper() == selection.ToUpper()
                        select user;
                    break;
            }
            UiPainter.PaintResult(query);
            return query.ToList();
        }
        #endregion
    }
}