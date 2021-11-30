using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Domains
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(DomainUpdateParametersModel);

        public override ResourceID? ResourceId() => new DomainId();

        public override Type? ResponseObject() => typeof(DomainModel);


    }
}
