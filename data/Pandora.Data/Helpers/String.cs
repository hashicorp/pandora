namespace Pandora.Data.Helpers;

public static class String
{
    public static string? RemoveConstantSuffixFromTypeName(this string? input)
    {
        if (input == null)
        {
            return null;
        }

        input = input.TrimSuffix("Constant");
        return input;
    }

    public static string? RemoveModelSuffixFromTypeName(this string? input)
    {
        if (input == null)
        {
            return null;
        }

        input = input.TrimSuffix("Model");
        return input;
    }

    public static string? RemoveSuffixFromTypeName(this string? input)
    {
        if (input == null)
        {
            return null;
        }

        input = input.RemoveModelSuffixFromTypeName();
        input = input.RemoveConstantSuffixFromTypeName();
        return input;
    }

    public static string TrimPrefix(this string input, string suffix)
    {
        return !input.StartsWith(suffix) ? input : input.TrimStart(suffix.ToCharArray());
    }

    public static string TrimSuffix(this string input, string suffix)
    {
        return !input.EndsWith(suffix) ? input : input.Substring(0, input.Length - suffix.Length);
    }
}