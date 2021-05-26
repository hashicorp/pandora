using System;

namespace Pandora.Definitions.Attributes.Validation
{
    public class MaxItemsAttribute : Attribute
    {
        public int MaxItems { get; private set; }

        public MaxItemsAttribute(int maxItems)
        {
            MaxItems = maxItems;
        }
    }
}