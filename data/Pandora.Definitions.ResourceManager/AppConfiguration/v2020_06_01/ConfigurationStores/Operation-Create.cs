using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class CreateOperation : Operations.PutOperation
    {
        public override bool LongRunning()
        {
            return true;
        }

        public override Type? RequestObject()
        {
            return typeof(ConfigurationStoreModel);
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        public override Type? ResponseObject()
        {
            return typeof(ConfigurationStoreModel);
        }


    }
}
