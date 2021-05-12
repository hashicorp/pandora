using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.Store
{
    internal class Delete : LongRunningDeleteOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }
    }
}