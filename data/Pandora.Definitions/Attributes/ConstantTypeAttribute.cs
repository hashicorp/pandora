using System;

namespace Pandora.Definitions.Attributes
{
    public class ConstantTypeAttribute : Attribute
    {
        public ConstantType Type { get; }

        public ConstantTypeAttribute(ConstantType type)
        {
            Type = type;
        }

        public enum ConstantType
        {
            String = 1,
            Integer = 2,
            Float = 3,
        }
    }
}