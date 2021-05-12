using System;

namespace Pandora.Definitions.Attributes
{
    public class HclLabelAttribute : Attribute
    {
        public HclLabelAttribute(string name)
        {
            Name = name;
        }
        
        public string Name { get; private set; }
    }
}