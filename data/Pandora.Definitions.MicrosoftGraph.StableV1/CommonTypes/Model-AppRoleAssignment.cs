// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AppRoleAssignmentModel
{
    [JsonPropertyName("appRoleId")]
    public string? AppRoleId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principalDisplayName")]
    public string? PrincipalDisplayName { get; set; }

    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("principalType")]
    public string? PrincipalType { get; set; }

    [JsonPropertyName("resourceDisplayName")]
    public string? ResourceDisplayName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }
}
