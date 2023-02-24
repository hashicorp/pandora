using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.ThreatIntelligence;

internal class IndicatorQueryIndicatorsOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(ThreatIntelligenceFilteringCriteriaModel);

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(ThreatIntelligenceInformationModel);

    public override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/threatIntelligence/main/queryIndicators";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
