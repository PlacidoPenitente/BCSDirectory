using BCSDirectory.Models;
using BCSDirectory.Models.Enums;
using System;
using System.Collections.Generic;

namespace BCSDirectory.Model
{
    public class UserFacade : BaseInpc
    {
        public User User { get; }

        public UserFacade(User user)
        {
            User = user;
        }

        //LastName property from User model.

        #region LastNameProperty

        public string LastName
        {
            get => User.LastName;
            set
            {
                User.LastName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //FirstName property from User model.

        #region FirstNameProperty

        public string FirstName
        {
            get => User.FirstName;
            set
            {
                User.FirstName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //MiddleName property from User model.

        #region MiddleNameProperty

        public string MiddleName
        {
            get => User.MiddleName;
            set
            {
                User.MiddleName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //PhoneNumber property from User model.

        #region PhoneNumberProperty

        public string PhoneNumber
        {
            get => User.PhoneNumber;
            set
            {
                User.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Gender property from User model.

        #region GenderProperty

        public Gender Gender
        {
            get => User.Gender;
            set
            {
                User.Gender = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Birthdate property from User model.

        #region BirthdateProperty

        public DateTime Birthdate
        {
            get => User.Birthdate;
            set
            {
                User.Birthdate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Address property from User model.

        #region AddressProperty

        public string Address
        {
            get => User.Address;
            set
            {
                User.Address = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //CivilStatus property from User model.

        #region CivilStatusProperty

        public CivilStatus CivilStatus
        {
            get => User.CivilStatus;
            set
            {
                User.CivilStatus = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Hobbies property from User model.

        #region HobbiesProperty

        public List<Hobby> Hobbies
        {
            get => User.Hobbies;
            set
            {
                User.Hobbies = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //UserType property from User model.

        #region UserTypeProperty

        public UserType UserType
        {
            get => User.UserType;
            set
            {
                User.UserType = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Username property from User model.

        #region UsernameProperty

        public string Username
        {
            get => User.Username;
            set
            {
                User.Username = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Password property from User model.

        #region PasswordProperty

        public string Password
        {
            get => new String(User.Password);
            set
            {
                User.Password = value.ToCharArray();
                OnPropertyChanged();
            }
        }

        #endregion

        //PasswordHint property from User model.

        #region PasswordHintProperty

        public string PasswordHint
        {
            get => User.PasswordHint;
            set
            {
                User.PasswordHint = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Position property from User model.

        #region PositionProperty

        public Position Position
        {
            get => User.Position;
            set
            {
                User.Position = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
