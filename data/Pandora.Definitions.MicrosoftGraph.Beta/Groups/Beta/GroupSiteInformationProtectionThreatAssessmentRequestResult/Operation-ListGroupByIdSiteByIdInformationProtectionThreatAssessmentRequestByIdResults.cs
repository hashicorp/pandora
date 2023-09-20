// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionThreatAssessmentRequestResult;

internal class ListGroupByIdSiteByIdInformationProtectionThreatAssessmentRequestByIdResultsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdInformationProtectionThreatAssessmentRequestId();
    public override Type NestedItemType() => typeof(ThreatAssessmentResultCollectionResponseModel);
    public override string? UriSuffix() => "/results";
}
