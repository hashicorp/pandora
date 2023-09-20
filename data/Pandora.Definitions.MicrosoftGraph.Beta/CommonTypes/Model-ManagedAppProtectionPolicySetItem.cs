// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedAppProtectionPolicySetItemModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errorCode")]
    public ManagedAppProtectionPolicySetItemErrorCodeConstant? ErrorCode { get; set; }

    [JsonPropertyName("guidedDeploymentTags")]
    public List<string>? GuidedDeploymentTags { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("itemType")]
    public string? ItemType { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payloadId")]
    public string? PayloadId { get; set; }

    [JsonPropertyName("status")]
    public ManagedAppProtectionPolicySetItemStatusConstant? Status { get; set; }

    [JsonPropertyName("targetedAppManagementLevels")]
    public string? TargetedAppManagementLevels { get; set; }
}
