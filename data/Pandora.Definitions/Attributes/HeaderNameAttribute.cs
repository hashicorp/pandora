using System;

namespace Pandora.Definitions.Attributes;

public class HeaderNameAttribute : Attribute
{
    public string Name { get; }

    public HeaderNameAttribute(string name)
    {
        Name = name;
    }
}