using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.IpFilterRules
{
    internal class NamespacesListIPFilterRulesOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new NamespaceId();

        public override Type NestedItemType() => typeof(IpFilterRuleModel);

        public override string? UriSuffix() => "/ipfilterrules";


    }
}
