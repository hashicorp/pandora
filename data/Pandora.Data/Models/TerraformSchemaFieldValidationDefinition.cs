using System.Collections.Generic;

namespace Pandora.Data.Models;

public class TerraformSchemaFieldValidationDefinition
{
    /// <summary>
    /// Type specifies the type of Field Validation applicable to this field, for example
    /// `PossibleValues` (to only allow specific values).
    /// </summary>
    public TerraformSchemaFieldValidationType Type { get; set; }

    /// <summary>
    /// PossibleValues defines the values for this field `Type` is set to `PossibleValues`.
    /// </summary>
    public TerraformSchemaFieldValidationPossibleTypes? PossibleValues { get; set; }
}

public class TerraformSchemaFieldValidationPossibleTypes
{
    /// <summary>
    /// Type specifies the Type used for the PossibleValues (float/int/string)
    /// </summary>
    public TerraformSchemaFieldValidationPossibleType Type { get; set; }

    /// <summary>
    /// Values is a List<int>, List<float> or List<string> defining the list of
    /// possible values which are valid for this field.
    /// </summary>
    public List<object> Values { get; set; }
}

public enum TerraformSchemaFieldValidationPossibleType
{
    Float,
    Int,
    String,
}

public enum TerraformSchemaFieldValidationType
{
    Unknown = 0,

    /// <summary>
    /// PossibleValues indicates that there's a fixed set of possible values allowed.
    /// </summary>
    PossibleValues = 1,
}