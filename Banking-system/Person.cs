using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Person(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }}