using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerNamespaces
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(PartnerNamespaceUpdateParametersModel);

        public override ResourceID? ResourceId() => new PartnerNamespaceId();

        public override Type? ResponseObject() => typeof(PartnerNamespaceModel);


    }
}
