using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.FeaturesetVersion;


internal class MaterializationSettingsModel
{
    [JsonPropertyName("notification")]
    public NotificationSettingModel? Notification { get; set; }

    [JsonPropertyName("resource")]
    public MaterializationComputeResourceModel? Resource { get; set; }

    [JsonPropertyName("schedule")]
    public RecurrenceTriggerModel? Schedule { get; set; }

    [JsonPropertyName("sparkConfiguration")]
    public Dictionary<string, string>? SparkConfiguration { get; set; }

    [JsonPropertyName("storeType")]
    public MaterializationStoreTypeConstant? StoreType { get; set; }
}
