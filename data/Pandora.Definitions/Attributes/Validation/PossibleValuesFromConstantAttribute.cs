using System;

namespace Pandora.Definitions.Attributes.Validation;

public class PossibleValuesFromConstantAttribute : Attribute
{
    public Type ConstantSource { get; private set; }

    public PossibleValuesFromConstantAttribute(Type constantSource)
    {
        ConstantSource = constantSource;
    }
}