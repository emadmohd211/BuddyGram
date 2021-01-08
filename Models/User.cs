using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buddiegram.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    /*    public User() { }

        public User(string Email, string Password, string FirstName,string LastName, string PhoneNumber)
        {

            this.Email = Email;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            
        }*/
    }
}
