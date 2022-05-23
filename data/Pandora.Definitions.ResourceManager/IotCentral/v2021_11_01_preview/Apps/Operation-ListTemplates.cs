using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IotCentral.v2021_11_01_preview.Apps;

internal class ListTemplatesOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(AppTemplateModel);

    public override string? UriSuffix() => "/providers/Microsoft.IoTCentral/appTemplates";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
