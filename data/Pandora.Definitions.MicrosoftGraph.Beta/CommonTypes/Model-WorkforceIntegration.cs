// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkforceIntegrationModel
{
    [JsonPropertyName("apiVersion")]
    public int? ApiVersion { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("eligibilityFilteringEnabledEntities")]
    public WorkforceIntegrationEligibilityFilteringEnabledEntitiesConstant? EligibilityFilteringEnabledEntities { get; set; }

    [JsonPropertyName("encryption")]
    public WorkforceIntegrationEncryptionModel? Encryption { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("supportedEntities")]
    public WorkforceIntegrationSupportedEntitiesConstant? SupportedEntities { get; set; }

    [JsonPropertyName("supports")]
    public WorkforceIntegrationSupportsConstant? Supports { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
