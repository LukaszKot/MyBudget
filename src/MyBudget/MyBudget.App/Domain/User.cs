using System;
using System.Collections;
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
        public IEnumerable<OperationCategory> OperationCategories { get; set; }
        public IEnumerable<Budget> Budgets { get; set; }
        
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