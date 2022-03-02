using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.VMHHostList;

internal class VMHostListOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type NestedItemType() => typeof(VMResourcesModel);

    public override string? UriSuffix() => "/listVMHost";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
