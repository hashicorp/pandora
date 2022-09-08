using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes.Validation;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaFieldValidationDefinitionTests
{
    [TestCase]
    public static void MappingPossibleValues()
    {
        var input = typeof(ModelContainingAFieldWithFixedPossibleValues).GetProperty("WithFixedPossibleValues");
        Assert.NotNull(input);

        var actual = TerraformSchemaFieldValidationDefinition.Map(input);
        Assert.AreEqual(TerraformSchemaFieldValidationType.PossibleValues, actual.Type);
        Assert.NotNull(actual.PossibleValues);
        Assert.AreEqual(new List<string> { "First1", "Second1" }, actual.PossibleValues!);
    }

    private class ModelContainingAFieldWithFixedPossibleValues
    {
        [PossibleValuesFromConstant(typeof(SomeValues))]
        public string WithFixedPossibleValues { get; set; }

        private enum SomeValues
        {
            [System.ComponentModel.Description("First1")]
            FirstOne,

            [System.ComponentModel.Description("Second1")]
            SecondOne,
        }
    }
}