using System;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class GetImmediate : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(NestedItem);
        }
    }
}