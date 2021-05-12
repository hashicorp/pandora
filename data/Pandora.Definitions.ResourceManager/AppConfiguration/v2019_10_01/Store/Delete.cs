using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2019_10_01.Store
{
    internal class Delete : DeleteOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }
    }
}