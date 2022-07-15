using Pandora.Data.Helpers;

namespace Pandora.Data.Transformers;

public static class TerraformMethodDefinition
{
    public static Models.TerraformMethodDefinition Map(Definitions.Interfaces.MethodDefinition input)
    {
        var methodName = input.Method.Name.TrimSuffix("Operation");
        return new Models.TerraformMethodDefinition
        {
            Generate = input.Generate,
            MethodName = methodName,
            TimeoutInMinutes = input.TimeoutInMinutes,
        };
    }
}