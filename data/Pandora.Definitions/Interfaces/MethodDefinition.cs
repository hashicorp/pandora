using System;

namespace Pandora.Definitions.Interfaces;

public class MethodDefinition
{
    /// <summary>
    /// Generate specifies whether this method should be generated or not.
    /// </summary>
    public bool Generate { get; set; }

    /// <summary>
    /// Method defines the SDK Method which should be called in this Terraform method.
    /// </summary>
    public Type Method { get; set; }

    /// <summary>
    /// TimeoutInMinutes defines the Terraform Resource Timeout in minutes for this method.
    /// </summary>
    public int TimeoutInMinutes { get; set; }
}