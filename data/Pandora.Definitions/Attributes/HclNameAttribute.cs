using System;

namespace Pandora.Definitions.Attributes;

public class HclNameAttribute : Attribute
{
    public HclNameAttribute(string name)
    {
        Name = name;
    }
    
    public string Name { get; set; }
}