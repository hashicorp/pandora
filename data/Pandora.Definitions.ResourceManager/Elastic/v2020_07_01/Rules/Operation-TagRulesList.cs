using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.Rules;

internal class TagRulesListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type NestedItemType() => typeof(MonitoringTagRulesModel);

    public override string? UriSuffix() => "/tagRules";


}
