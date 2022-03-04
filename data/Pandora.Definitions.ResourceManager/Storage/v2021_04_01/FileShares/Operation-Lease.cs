using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;

internal class LeaseOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(LeaseShareRequestModel);

    public override ResourceID? ResourceId() => new ShareId();

    public override Type? ResponseObject() => typeof(LeaseShareResponseModel);

    public override Type? OptionsObject() => typeof(LeaseOperation.LeaseOptions);

    public override string? UriSuffix() => "/lease";

    internal class LeaseOptions
    {
        [HeaderName("x-ms-snapshot")]
        [Optional]
        public string XMsSnapshot { get; set; }
    }
}
