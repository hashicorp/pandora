using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{
    internal class GetOperation : Operations.GetOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
            };
        }

        public override ResourceID? ResourceId()
        {
            return new WcfRelayId();
        }

        public override Type? ResponseObject()
        {
            return typeof(WcfRelayModel);
        }


    }
}
