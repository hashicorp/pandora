using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.Monitors;

internal class ListUserRolesOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(UserRoleRequestModel);

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type NestedItemType() => typeof(UserRoleResponseModel);

    public override string? UriSuffix() => "/listUserRoles";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
