using System;

namespace Pandora.Definitions.Attributes
{
    public class ValueForTypeAttribute : Attribute
    {
        public string Value { get; }

        public ValueForTypeAttribute(string value)
        {
            Value = value;
        }
    }
}