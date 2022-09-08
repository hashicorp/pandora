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
    /// Possible values is a List<int>, List<float> or List<string> defining
    /// the list of possible values which are valid for this field.
    /// </summary>
    public List<object>? PossibleValues { get; set; }
}

public enum TerraformSchemaFieldValidationType
{
    Unknown = 0,

    /// <summary>
    /// PossibleValues indicates that there's a fixed set of possible values allowed.
    /// </summary>
    PossibleValues = 1,
}