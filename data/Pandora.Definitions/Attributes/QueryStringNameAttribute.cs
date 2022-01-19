using System;

namespace Pandora.Definitions.Attributes;

public class QueryStringName : Attribute
{
    public string Name { get; }

    public QueryStringName(string name)
    {
        Name = name;
    }
}