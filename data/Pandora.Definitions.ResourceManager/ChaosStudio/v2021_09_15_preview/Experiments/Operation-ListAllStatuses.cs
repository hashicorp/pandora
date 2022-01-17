using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments
{
    internal class ListAllStatusesOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new ExperimentId();

        public override Type NestedItemType() => typeof(ExperimentStatusModel);

        public override string? UriSuffix() => "/statuses";


    }
}
