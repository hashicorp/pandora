// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionThreatAssessmentRequestResult;

internal class UserIdInformationProtectionThreatAssessmentRequestIdResultId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/informationProtection/threatAssessmentRequests/{threatAssessmentRequestId}/results/{threatAssessmentResultId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticThreatAssessmentRequests", "threatAssessmentRequests"),
        ResourceIDSegment.UserSpecified("threatAssessmentRequestId"),
        ResourceIDSegment.Static("staticResults", "results"),
        ResourceIDSegment.UserSpecified("threatAssessmentResultId")
    };
}
