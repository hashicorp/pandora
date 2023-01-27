using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.Agreements;

internal class MarketplaceAgreementsCreateOrUpdateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(DatadogAgreementResourceModel);

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(DatadogAgreementResourceModel);

    public override string? UriSuffix() => "/providers/Microsoft.Datadog/agreements/default";


}
