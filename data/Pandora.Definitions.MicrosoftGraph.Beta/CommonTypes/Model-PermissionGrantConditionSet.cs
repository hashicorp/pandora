// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionGrantConditionSetModel
{
    [JsonPropertyName("certifiedClientApplicationsOnly")]
    public bool? CertifiedClientApplicationsOnly { get; set; }

    [JsonPropertyName("clientApplicationIds")]
    public List<string>? ClientApplicationIds { get; set; }

    [JsonPropertyName("clientApplicationPublisherIds")]
    public List<string>? ClientApplicationPublisherIds { get; set; }

    [JsonPropertyName("clientApplicationTenantIds")]
    public List<string>? ClientApplicationTenantIds { get; set; }

    [JsonPropertyName("clientApplicationsFromVerifiedPublisherOnly")]
    public bool? ClientApplicationsFromVerifiedPublisherOnly { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionClassification")]
    public string? PermissionClassification { get; set; }

    [JsonPropertyName("permissionType")]
    public PermissionTypeConstant? PermissionType { get; set; }

    [JsonPropertyName("permissions")]
    public List<string>? Permissions { get; set; }

    [JsonPropertyName("resourceApplication")]
    public string? ResourceApplication { get; set; }
}
