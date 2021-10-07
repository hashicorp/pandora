using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class ListOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ProviderId();

        public override Type? ResponseObject() => typeof(AnalysisServicesServersModel);

        public override string? UriSuffix() => "/servers";


    }
}
