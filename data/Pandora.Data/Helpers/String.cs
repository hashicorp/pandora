namespace Pandora.Data.Helpers
{
    public static class String
    {
        public static string? RemoveSuffixFromTypeName(this string? input)
        {
            if (input == null)
            {
                return null;
            }

            input = input.TrimSuffix("Constant");
            input = input.TrimSuffix("Model");
            return input;
        }

        public static string TrimSuffix(this string input, string suffix)
        {
            return !input.EndsWith(suffix) ? input : input.Substring(0, input.Length - suffix.Length);
        }
    }
}