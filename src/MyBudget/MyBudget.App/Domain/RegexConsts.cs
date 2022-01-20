using System.Text.RegularExpressions;

namespace MyBudget.App.Domain
{
    public static class RegexConsts
    {
        public const string ObjectName = @"^[ĄąĆćĘęŁłŃńÓóŚśŻżŹź0-9A-Za-z\s\-]{1,50}$";
        public const string Username = @"^[A-Za-z][A-Za-z0-9_]{4,20}$";
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        public static bool IsMatch(this string regex, string value)
        {
            return Regex.IsMatch(value, regex);
        }
    }
}