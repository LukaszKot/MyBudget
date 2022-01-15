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
        public IEnumerable<BudgetTemplate> BudgetTemplates { get; }
        public IEnumerable<OperationTemplate> OperationTemplates { get; }
        
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
            if (!RegexConsts.ObjectName.IsMatch(username))
            {
                throw new DomainException(DomainError.InvalidUsername);
            }
            Username = username;
        }
    }
}