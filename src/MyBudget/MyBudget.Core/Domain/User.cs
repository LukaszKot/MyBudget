using System;
using System.Text.RegularExpressions;
using MyBudget.Core.Exceptions;

namespace MyBudget.Core.Domain
{
    public class User
    {
        public Guid Id { get; init; }
        public string Username  { get; private set; }
        public string Hash { get; set; }
        
        // for serialization
        private User()
        {
        }
        public User(string username, string hash)
        {
            Id = Guid.NewGuid();
            SetUsername(username);
            Hash = hash;
        }

        private void SetUsername(string username)
        {
            if (!Regex.IsMatch(username,@"^[A-Za-z][A-Za-z0-9_]{4,20}$"))
            {
                throw new DomainException(DomainError.InvalidUsername);
            }
            Username = username;
        }
    }
}