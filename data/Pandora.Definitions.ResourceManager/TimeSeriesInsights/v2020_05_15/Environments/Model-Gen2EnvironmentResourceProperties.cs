using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.Environments;


internal class Gen2EnvironmentResourcePropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("dataAccessFqdn")]
    public string? DataAccessFqdn { get; set; }

    [JsonPropertyName("dataAccessId")]
    public string? DataAccessId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public EnvironmentStatusModel? Status { get; set; }

    [JsonPropertyName("storageConfiguration")]
    [Required]
    public Gen2StorageConfigurationOutputModel StorageConfiguration { get; set; }

    [JsonPropertyName("timeSeriesIdProperties")]
    [Required]
    public List<TimeSeriesIdPropertyModel> TimeSeriesIdProperties { get; set; }

    [JsonPropertyName("warmStoreConfiguration")]
    public WarmStoreConfigurationPropertiesModel? WarmStoreConfiguration { get; set; }
}
