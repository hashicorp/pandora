using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01.Monitors;

internal class SwitchBillingOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(SwitchBillingRequestModel);

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type? ResponseObject() => typeof(NewRelicMonitorResourceModel);

    public override string? UriSuffix() => "/switchBilling";


}
