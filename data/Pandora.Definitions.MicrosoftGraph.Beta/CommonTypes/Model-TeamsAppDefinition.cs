// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamsAppDefinitionModel
{
    [JsonPropertyName("allowedInstallationScopes")]
    public TeamsAppInstallationScopesConstant? AllowedInstallationScopes { get; set; }

    [JsonPropertyName("authorization")]
    public TeamsAppAuthorizationModel? Authorization { get; set; }

    [JsonPropertyName("azureADAppId")]
    public string? AzureADAppId { get; set; }

    [JsonPropertyName("bot")]
    public TeamworkBotModel? Bot { get; set; }

    [JsonPropertyName("colorIcon")]
    public TeamsAppIconModel? ColorIcon { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

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

    [JsonPropertyName("outlineIcon")]
    public TeamsAppIconModel? OutlineIcon { get; set; }

    [JsonPropertyName("publishingState")]
    public TeamsAppPublishingStateConstant? PublishingState { get; set; }

    [JsonPropertyName("shortdescription")]
    public string? Shortdescription { get; set; }

    [JsonPropertyName("teamsAppId")]
    public string? TeamsAppId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
