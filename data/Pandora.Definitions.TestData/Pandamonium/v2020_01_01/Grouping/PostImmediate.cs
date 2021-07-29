using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class PostImmediate : PostOperation
    {
        public override object? RequestObject()
        {
            return new NestedItem();
        }
    }
}