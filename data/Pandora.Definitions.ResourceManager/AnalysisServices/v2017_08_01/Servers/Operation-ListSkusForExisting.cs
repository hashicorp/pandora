using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class ListSkusForExistingOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ServerId();

        public override Type? ResponseObject() => typeof(SkuEnumerationForExistingResourceResultModel);

        public override string? UriSuffix() => "/skus";


    }
}
