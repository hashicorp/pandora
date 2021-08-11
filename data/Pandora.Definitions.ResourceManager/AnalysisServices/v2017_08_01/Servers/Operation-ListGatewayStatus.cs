using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class ListGatewayStatusOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override object? RequestObject()
        {
            return null;
        }

        public override ResourceID? ResourceId()
        {
            return new ServerId();
        }

        public override object? ResponseObject()
        {
            return new GatewayListStatusLiveModel();
        }

        public override string? UriSuffix()
        {
            return "/listGatewayStatus";
        }


    }
}
