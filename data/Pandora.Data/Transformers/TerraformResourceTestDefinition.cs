using System;

namespace Pandora.Data.Transformers;

public static class TerraformResourceTestDefinition
{
    public static Models.TerraformResourceTestDefinition Map(Definitions.Interfaces.TerraformResourceTestDefinition input)
    {
        // this just does validation when mapping, nothing fancy
        if (string.IsNullOrWhiteSpace(input.BasicTestConfig))
        {
            throw new NotSupportedException($"the basic test configuration cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(input.RequiresImportConfig))
        {
            throw new NotSupportedException($"the requires import test configuration cannot be empty");
        }

        return new Models.TerraformResourceTestDefinition {
            BasicConfig = input.BasicTestConfig,
            RequiresImportConfig = input.RequiresImportConfig,
            CompleteConfig = input.CompleteConfig,
            TemplateConfig = input.TemplateConfig,
            OtherTests = input.OtherTests,
        };
    }
}