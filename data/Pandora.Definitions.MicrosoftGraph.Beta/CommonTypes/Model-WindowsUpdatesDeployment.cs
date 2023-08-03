// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdatesDeploymentModel
{
    [JsonPropertyName("audience")]
    public DeploymentAudienceModel? Audience { get; set; }

    [JsonPropertyName("content")]
    public DeployableContentModel? Content { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settings")]
    public DeploymentSettingsModel? Settings { get; set; }

    [JsonPropertyName("state")]
    public DeploymentStateModel? State { get; set; }
}
