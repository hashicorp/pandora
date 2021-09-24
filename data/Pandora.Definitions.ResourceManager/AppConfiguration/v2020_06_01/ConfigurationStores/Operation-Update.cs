using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(ConfigurationStoreUpdateParametersModel);

        public override ResourceID? ResourceId() => new ConfigurationStoreId();

        public override Type? ResponseObject() => typeof(ConfigurationStoreModel);


    }
}
