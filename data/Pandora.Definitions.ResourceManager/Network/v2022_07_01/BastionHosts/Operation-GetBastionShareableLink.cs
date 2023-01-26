using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.BastionHosts;

internal class GetBastionShareableLinkOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(BastionShareableLinkListRequestModel);

    public override ResourceID? ResourceId() => new BastionHostId();

    public override Type NestedItemType() => typeof(BastionShareableLinkModel);

    public override string? UriSuffix() => "/getShareableLinks";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
