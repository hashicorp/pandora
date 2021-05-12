using System;

namespace Pandora.Definitions.Attributes
{
    public class MinItemsAttribute : Attribute
    {
        public int MinItems { get; private set; }

        public MinItemsAttribute(int minItems)
        {
            MinItems = minItems;
        }
    }
}