using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Pandamonium.v2020_01_01.Grouping
{
    public class PutLongRunning : LongRunningPutOperation
    {
        public override object? RequestObject()
        {
            return new NestedItem();
        }
    }
}