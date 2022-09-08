using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes.Validation;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaFieldValidationDefinition
{
    public static Models.TerraformSchemaFieldValidationDefinition? Map(PropertyInfo input)
    {
        var possibleValues = input.GetCustomAttribute<PossibleValuesFromConstantAttribute>();
        if (possibleValues != null)
        {
            return mapPossibleValues(possibleValues.ConstantSource);
        }

        return null;
    }

    private static Models.TerraformSchemaFieldValidationDefinition? mapPossibleValues(Type input)
    {
        var values = ValuesForEnum(input);
        return new Models.TerraformSchemaFieldValidationDefinition
        {
            Type = TerraformSchemaFieldValidationType.PossibleValues,
            PossibleValues = values.Select(k => (object)k.Value).ToList(),
        };
    }

    private static Dictionary<string, string> ValuesForEnum(Type input)
    {
        var output = new Dictionary<string, string>();
        var values = input.GetEnumValues();
        foreach (var val in values)
        {
            // Some Enum's define `Equals` as a value, however all objects implement Equals too which apparently conflicts here
            // so filter to the member on this specific Enum
            var enumValue = input.GetMember(val.ToString()).First(m => m.DeclaringType == input);
            var description = enumValue.GetCustomAttribute<DescriptionAttribute>();
            if (description == null)
            {
                throw new NotSupportedException(
                    $"Each value for the enum {input.Name} must implement the 'Description' attribute - but {val.ToString()} doesn't");
            }

            output.Add(val.ToString(), description.Description);
        }

        return output;
    }
}