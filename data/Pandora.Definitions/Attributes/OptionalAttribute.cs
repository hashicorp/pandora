using System;

namespace Pandora.Definitions.Attributes
{
    public class OptionalAttribute : Attribute
    {
        public object? DefaultValue { get; set; }
    }
}