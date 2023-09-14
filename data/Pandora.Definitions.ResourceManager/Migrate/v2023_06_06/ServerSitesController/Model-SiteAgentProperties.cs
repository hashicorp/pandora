using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ServerSitesController;


internal class SiteAgentPropertiesModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("keyVaultId")]
    public string? KeyVaultId { get; set; }

    [JsonPropertyName("keyVaultUri")]
    public string? KeyVaultUri { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartBeatUtc")]
    public DateTime? LastHeartBeatUtc { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
