// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcAuditActorModel
{
    [JsonPropertyName("applicationDisplayName")]
    public string? ApplicationDisplayName { get; set; }

    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remoteTenantId")]
    public string? RemoteTenantId { get; set; }

    [JsonPropertyName("remoteUserId")]
    public string? RemoteUserId { get; set; }

    [JsonPropertyName("servicePrincipalName")]
    public string? ServicePrincipalName { get; set; }

    [JsonPropertyName("type")]
    public CloudPcAuditActorTypeConstant? Type { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPermissions")]
    public List<string>? UserPermissions { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("userRoleScopeTags")]
    public List<CloudPcUserRoleScopeTagInfoModel>? UserRoleScopeTags { get; set; }
}
