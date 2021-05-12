using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.Store
{
    internal class Get : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }
        
        public override object? ResponseObject()
        {
            return new GetStore();
        }
    }
}