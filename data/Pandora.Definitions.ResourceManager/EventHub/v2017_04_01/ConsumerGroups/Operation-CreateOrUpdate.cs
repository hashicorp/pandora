using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(ConsumerGroupModel);
        }

        public override ResourceID? ResourceId()
        {
            return new ConsumergroupId();
        }

        public override Type? ResponseObject()
        {
            return typeof(ConsumerGroupModel);
        }


    }
}
