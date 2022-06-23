using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.DataConnectors;


internal class TiTaxiiDataConnectorPropertiesModel
{
    [JsonPropertyName("collectionId")]
    public string? CollectionId { get; set; }

    [JsonPropertyName("dataTypes")]
    [Required]
    public TiTaxiiDataConnectorDataTypesModel DataTypes { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("pollingFrequency")]
    [Required]
    public PollingFrequencyConstant PollingFrequency { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("taxiiLookbackPeriod")]
    public DateTime? TaxiiLookbackPeriod { get; set; }

    [JsonPropertyName("taxiiServer")]
    public string? TaxiiServer { get; set; }

    [JsonPropertyName("tenantId")]
    [Required]
    public string TenantId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    [JsonPropertyName("workspaceId")]
    public string? WorkspaceId { get; set; }
}
