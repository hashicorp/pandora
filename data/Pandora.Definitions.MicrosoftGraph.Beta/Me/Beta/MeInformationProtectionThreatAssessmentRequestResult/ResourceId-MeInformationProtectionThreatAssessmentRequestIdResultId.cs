// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionThreatAssessmentRequestResult;

internal class MeInformationProtectionThreatAssessmentRequestIdResultId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/informationProtection/threatAssessmentRequests/{threatAssessmentRequestId}/results/{threatAssessmentResultId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticThreatAssessmentRequests", "threatAssessmentRequests"),
        ResourceIDSegment.UserSpecified("threatAssessmentRequestId"),
        ResourceIDSegment.Static("staticResults", "results"),
        ResourceIDSegment.UserSpecified("threatAssessmentResultId")
    };
}
