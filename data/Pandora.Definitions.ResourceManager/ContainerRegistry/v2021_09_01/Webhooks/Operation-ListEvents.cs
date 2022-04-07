using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;

internal class ListEventsOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new WebhookId();

    public override Type NestedItemType() => typeof(EventModel);

    public override string? UriSuffix() => "/listEvents";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
