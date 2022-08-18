namespace Pandora.Definitions.Helpers;

public static class TerraformTestConfiguration
{
    public static string AsTerraformTestConfig(this string input)
    {
        return input.Replace("'", "\"");
    }
}