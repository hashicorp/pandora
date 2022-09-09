using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
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
        var type = mapPossibleValuesType(input);
        var values = ValuesForEnum(input, type);
        return new Models.TerraformSchemaFieldValidationDefinition
        {
            Type = TerraformSchemaFieldValidationType.PossibleValues,
            PossibleValues = new TerraformSchemaFieldValidationPossibleTypes
            {
                Type = type,
                Values = values.Select(k => (object)k.Value).ToList()
            },
        };
    }

    private static TerraformSchemaFieldValidationPossibleType mapPossibleValuesType(Type input)
    {
        var type = input.GetCustomAttribute<ConstantTypeAttribute>();
        if (type == null)
        {
            throw new NotSupportedException($"constant {input.FullName} was missing a [ConstantType] attribute");
        }

        switch (type.Type)
        {
            case ConstantTypeAttribute.ConstantType.Float:
                return TerraformSchemaFieldValidationPossibleType.Float;
            case ConstantTypeAttribute.ConstantType.Integer:
                return TerraformSchemaFieldValidationPossibleType.Int;
            case ConstantTypeAttribute.ConstantType.String:
                return TerraformSchemaFieldValidationPossibleType.String;
        }

        throw new NotSupportedException($"unimplemented Validation PossibleType for Constant Type {type.Type}");
    }

    private static Dictionary<string, string> ValuesForEnum(Type input, TerraformSchemaFieldValidationPossibleType type)
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
                throw new NotSupportedException($"Each value for the enum {input.Name} must implement the 'Description' attribute - but {val.ToString()} doesn't");
            }

            // switch (type)
            // {
            //     case TerraformSchemaFieldValidationPossibleType.Float:
            //     {
            //         output.Add(val.ToString(), float.Parse(description.Description, NumberStyles.Any));
            //         break;
            //     }
            //         
            //     case TerraformSchemaFieldValidationPossibleType.Int:
            //     {
            //         output.Add(val.ToString(), int.Parse(description.Description));
            //         break;
            //     }
            //         
            //     case TerraformSchemaFieldValidationPossibleType.String:
            //     {
            //         output.Add(val.ToString(), description.Description);
            //         break;
            //     }
            //
            //     default:
            //     {
            //         throw new NotSupportedException($"unimplemented mapping for Variable PossibleType for Constant Type {type}");
            //     }
            // }
            // TODO: change the [Description] attribute for [ConstantValue] taking a float/int/string rather than strings?
            output.Add(val.ToString(), description.Description);
        }

        return output;
    }
}