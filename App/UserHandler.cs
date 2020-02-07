using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
        
        #region UserCreation
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
            switch (ReadLine())
            {
                case "1":
                    user.BloodType = BloodType.BRhPositive;
                    break;
                case "2":
                    user.BloodType = BloodType.ORhNegative;
                    break;
                case "3":
                    user.BloodType = BloodType.BRhPositive;
                    break;
                case "4":
                    user.BloodType = BloodType.BRhNegative;
                    break;
                case "5":
                    user.BloodType = BloodType.ARhPositive;
                    break;
                case "6":
                    user.BloodType = BloodType.ARhNegative;
                    break;
                case "7":
                    user.BloodType = BloodType.ABRhPositive;
                    break;
                case "8":
                    user.BloodType = BloodType.ARhNegative;
                    break;
            }
            Clear();
        }

        private static void SetGender(User user)
        {
            UiPainter.PaintSetGender();
            switch (ReadLine())
            {
                case "1":
                    user.Gender = Gender.Female;
                    break;
                case "2":
                    user.Gender = Gender.Male;
                    break;
                case "3":
                    user.Gender = Gender.NonBinary;
                    break;
            }
            Clear();
        }
        #endregion

        #region UserModification
        public static void EditUser()
        {
            UiPainter.PaintEdit();
            var selection = ReadLine();
        }
        #endregion
    }
}