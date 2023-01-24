using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.DscNode;


internal class DscNodePropertiesModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("extensionHandler")]
    public List<DscNodeExtensionHandlerAssociationPropertyModel>? ExtensionHandler { get; set; }

    [JsonPropertyName("ip")]
    public string? IP { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSeen")]
    public DateTime? LastSeen { get; set; }

    [JsonPropertyName("nodeConfiguration")]
    public DscNodeConfigurationAssociationPropertyModel? NodeConfiguration { get; set; }

    [JsonPropertyName("nodeId")]
    public string? NodeId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("registrationTime")]
    public DateTime? RegistrationTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("totalCount")]
    public int? TotalCount { get; set; }
}
