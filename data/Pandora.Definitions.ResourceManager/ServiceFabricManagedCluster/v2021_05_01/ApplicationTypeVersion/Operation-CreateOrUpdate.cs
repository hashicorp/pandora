using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ApplicationTypeVersion
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(ApplicationTypeVersionResourceModel);

        public override ResourceID? ResourceId() => new VersionId();

        public override Type? ResponseObject() => typeof(ApplicationTypeVersionResourceModel);


    }
}
