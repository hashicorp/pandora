using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ModelDefinition
{
    /// <summary>
    /// Name is the name of this Model
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// TypeHintIn specifies the Property containing the Type Hint, for example 'ObjectType'
    /// </summary>
    public string? TypeHintIn { get; set; }

    /// <summary>
    /// ParentTypeName is the name of the Parent Type which this inherits from.
    /// </summary>
    public string? ParentTypeName { get; set; }

    /// <summary>
    /// TypeHintValue is the value which should be used to identify this type when a type hint is provided
    /// </summary>
    public string? TypeHintValue { get; set; }

    /// <summary>
    /// Properties is a list of Properties/Fields within this Model
    /// </summary>
    public List<PropertyDefinition> Properties { get; set; }
}