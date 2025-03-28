using System.Diagnostics.CodeAnalysis;

namespace Atlantic.Api.Models.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class StringExtensions
    {
        private const string CONCAT_SOMETHING = "CONCAT_SOMETHING";

        public static string ToConcatSomething(this int warnMeKey)
        {
            return string.Concat(CONCAT_SOMETHING, warnMeKey);
        }
    }
}
