using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService;

internal class LinkNotificationHubOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(LinkNotificationHubParametersModel);

\t\tpublic override ResourceID? ResourceId() => new CommunicationServiceId();

\t\tpublic override Type? ResponseObject() => typeof(LinkedNotificationHubModel);

\t\tpublic override string? UriSuffix() => "/linkNotificationHub";


}
