// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityGovernanceModel
{
    [JsonPropertyName("accessReviews")]
    public AccessReviewSetModel? AccessReviews { get; set; }

    [JsonPropertyName("appConsent")]
    public AppConsentApprovalRouteModel? AppConsent { get; set; }

    [JsonPropertyName("entitlementManagement")]
    public EntitlementManagementModel? EntitlementManagement { get; set; }

    [JsonPropertyName("lifecycleWorkflows")]
    public IdentityGovernanceLifecycleWorkflowsContainerModel? LifecycleWorkflows { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("privilegedAccess")]
    public PrivilegedAccessRootModel? PrivilegedAccess { get; set; }

    [JsonPropertyName("termsOfUse")]
    public TermsOfUseContainerModel? TermsOfUse { get; set; }
}
