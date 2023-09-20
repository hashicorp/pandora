// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PayloadCompatibleAssignmentFilterModel
{
    [JsonPropertyName("assignmentFilterManagementType")]
    public PayloadCompatibleAssignmentFilterAssignmentFilterManagementTypeConstant? AssignmentFilterManagementType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payloadType")]
    public PayloadCompatibleAssignmentFilterPayloadTypeConstant? PayloadType { get; set; }

    [JsonPropertyName("payloads")]
    public List<PayloadByFilterModel>? Payloads { get; set; }

    [JsonPropertyName("platform")]
    public PayloadCompatibleAssignmentFilterPlatformConstant? Platform { get; set; }

    [JsonPropertyName("roleScopeTags")]
    public List<string>? RoleScopeTags { get; set; }

    [JsonPropertyName("rule")]
    public string? Rule { get; set; }
}
