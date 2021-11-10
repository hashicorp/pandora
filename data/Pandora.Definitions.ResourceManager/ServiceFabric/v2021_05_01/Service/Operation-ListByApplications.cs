using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Service
{
    internal class ListByApplicationsOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new ApplicationId();

        public override Type NestedItemType() => typeof(ServiceResourceModel);

        public override string? UriSuffix() => "/services";


    }
}
