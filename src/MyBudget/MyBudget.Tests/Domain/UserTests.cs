using FluentAssertions;
using MyBudget.Core.Domain;
using MyBudget.Core.Exceptions;
using NUnit.Framework;

namespace MyBudget.Tests.Domain
{
    public class UserTests
    {

        [TestCase("test123")]
        [TestCase("Test123")]
        public void user_with_valid_username_can_be_created(string username)
        {
            var user = new User(username, "hash");
            user.Should().NotBeNull();
        }
        
        [TestCase("1asdb2")]
        [TestCase("abc")]
        [TestCase("asdasdsdasdadasdasdasdadadasdadasdasdasdasdasdasdsdasdada")]
        public void user_with_invalid_username_throws_exceptions(string username)
        {
            var ex = Assert.Throws<DomainException>(()=> new User(username, "hash"));
            ex.ErrorType.Should().Be(DomainError.InvalidUsername);
        }
    }
}