using System;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class PutImmediate : PutOperation
    {
        public override Type? RequestObject()
        {
            return typeof(NestedItem);
        }
    }
}