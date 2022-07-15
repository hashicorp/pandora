using NUnit.Framework;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers;

public class TerraformMethodDefinitionTests
{
    [TestCase]
    public void MappingAMethodWithGenerationDisabled()
    {
        var input = new Definitions.Interfaces.MethodDefinition
        {
            Generate = false,
            Method = typeof(FakeGetOperation),
            TimeoutInMinutes = 10,
        };
        var actual = TerraformMethodDefinition.Map(input);
        Assert.NotNull(actual);
        Assert.False(actual.Generate);
        Assert.AreEqual("FakeGet", actual.MethodName);
        Assert.AreEqual(10, actual.TimeoutInMinutes);
    }
    
    [TestCase]
    public void MappingAMethodWithGenerationEnabled()
    {
        var input = new Definitions.Interfaces.MethodDefinition
        {
            Generate = true,
            Method = typeof(FakeGetOperation),
            TimeoutInMinutes = 20,
        };
        var actual = TerraformMethodDefinition.Map(input);
        Assert.NotNull(actual);
        Assert.True(actual.Generate);
        Assert.AreEqual("FakeGet", actual.MethodName);
        Assert.AreEqual(20, actual.TimeoutInMinutes);
    }
    
    private class FakeGetOperation : GetOperation
    {
        public override string? UriSuffix()
        {
            return "/example";
        }
    }
}