using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;

internal class ListVhdsOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new LabId();

    public override Type NestedItemType() => typeof(LabVhdModel);

    public override string? UriSuffix() => "/listVhds";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
