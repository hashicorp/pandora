namespace Pandora.Data.Helpers
{
    public static class String
    {
        public static string TrimSuffix(this string input, string suffix)
        {
            return !input.EndsWith(suffix) ? input : input.Substring(0, input.Length - suffix.Length);
        }
    }
}