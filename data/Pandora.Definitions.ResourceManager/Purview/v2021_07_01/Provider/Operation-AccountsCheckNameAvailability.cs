using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Provider
{
    internal class AccountsCheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(CheckNameAvailabilityRequestModel);

        public override ResourceID? ResourceId() => new ProviderId();

        public override Type? ResponseObject() => typeof(CheckNameAvailabilityResultModel);

        public override string? UriSuffix() => "/checkNameAvailability";


    }
}
