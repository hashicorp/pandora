using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Share;

internal class ProviderShareSubscriptionsAdjustOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ProviderShareSubscriptionModel);

    public override ResourceID? ResourceId() => new ProviderShareSubscriptionId();

    public override Type? ResponseObject() => typeof(ProviderShareSubscriptionModel);

    public override string? UriSuffix() => "/adjust";


}
