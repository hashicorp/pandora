using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class ListSkusForExistingOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ServerId();
        }

        public override object? ResponseObject()
        {
            return new SkuEnumerationForExistingResourceResult();
        }

        public override string? UriSuffix()
        {
            return "/skus";
        }


    }
}
