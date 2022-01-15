using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Domain
{
    public class User
    {
        public Guid Id { get; init; }
        public string Username  { get; private set; }
        public string Hash { get; set; }
        public IEnumerable<BudgetTemplate> BudgetTemplates { get; set; }
        public IEnumerable<OperationTemplate> OperationTemplates { get; set; }
        
        // for serialization
        private User()
        {
        }
        public User(string username, string hash)
        {
            Id = Guid.NewGuid();
            SetUsername(username);
            Hash = hash;
            BudgetTemplates = new List<BudgetTemplate>();
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