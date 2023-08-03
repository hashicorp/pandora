// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedOperationEventModel
{
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }

    [JsonPropertyName("creationDateTime")]
    public DateTime? CreationDateTime { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("referenceKey")]
    public string? ReferenceKey { get; set; }

    [JsonPropertyName("referenceSystem")]
    public string? ReferenceSystem { get; set; }

    [JsonPropertyName("requestType")]
    public string? RequestType { get; set; }

    [JsonPropertyName("requestorId")]
    public string? RequestorId { get; set; }

    [JsonPropertyName("requestorName")]
    public string? RequestorName { get; set; }

    [JsonPropertyName("roleId")]
    public string? RoleId { get; set; }

    [JsonPropertyName("roleName")]
    public string? RoleName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userMail")]
    public string? UserMail { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
