using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

internal class AliasCreateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(PutAliasRequestModel);

\t\tpublic override ResourceID? ResourceId() => new AliasId();

\t\tpublic override Type? ResponseObject() => typeof(SubscriptionAliasResponseModel);


}
