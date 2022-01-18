using System.Text.RegularExpressions;

namespace MyBudget.App.Domain
{
    public static class RegexConsts
    {
        public static Regex ObjectName => new(@"^[ĄąĆćĘęŁłŃńÓóŚśŻżŹź0-9A-Za-z\s\-]{1,50}$");
        public static Regex Username => new(@"^[A-Za-z][A-Za-z0-9_]{4,20}$");
    }
}