using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class PostLongRunning : LongRunningPostOperation
    {
        public override object? RequestObject()
        {
            return new NestedItem();
        }
    }
}