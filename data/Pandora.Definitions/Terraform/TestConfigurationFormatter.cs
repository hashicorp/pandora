using System;

namespace Pandora.Definitions.Terraform
{
    public class TestConfigurationFormatter
    {
        public static string WithHclString(Func<TestDataFormatValues, string> input)
        {
            var terraformTestData = new TestDataFormatValues
            {
                RandomIntegerFormat = "%[1]s",
                PrimaryLocationFormat = "%[2]s"
            };
            return input.Invoke(terraformTestData);
        }
    }
}