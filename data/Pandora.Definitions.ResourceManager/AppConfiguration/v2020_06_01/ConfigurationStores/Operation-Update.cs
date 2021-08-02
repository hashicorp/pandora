using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override bool LongRunning()
        {
            return true;
        }

        public override object? RequestObject()
        {
            return new ConfigurationStoreUpdateParametersModel();
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        public override object? ResponseObject()
        {
            return new ConfigurationStoreModel();
        }


    }
}
