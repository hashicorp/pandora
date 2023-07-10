using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

internal class SubscriptionOperationGetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new SubscriptionOperationId();

    public override Type? ResponseObject() => typeof(SubscriptionCreationResultModel);


}
