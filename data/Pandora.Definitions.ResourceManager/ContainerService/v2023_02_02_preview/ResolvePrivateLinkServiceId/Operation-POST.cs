using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.ResolvePrivateLinkServiceId;

internal class POSTOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(PrivateLinkResourceModel);

    public override ResourceID? ResourceId() => new ManagedClusterId();

    public override Type? ResponseObject() => typeof(PrivateLinkResourceModel);

    public override string? UriSuffix() => "/resolvePrivateLinkServiceId";


}
