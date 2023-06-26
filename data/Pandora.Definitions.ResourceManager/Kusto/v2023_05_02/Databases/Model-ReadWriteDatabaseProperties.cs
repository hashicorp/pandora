using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.Databases;


internal class ReadWriteDatabasePropertiesModel
{
    [JsonPropertyName("hotCachePeriod")]
    public string? HotCachePeriod { get; set; }

    [JsonPropertyName("isFollowed")]
    public bool? IsFollowed { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("softDeletePeriod")]
    public string? SoftDeletePeriod { get; set; }

    [JsonPropertyName("statistics")]
    public DatabaseStatisticsModel? Statistics { get; set; }

    [JsonPropertyName("suspensionDetails")]
    public SuspensionDetailsModel? SuspensionDetails { get; set; }
}
