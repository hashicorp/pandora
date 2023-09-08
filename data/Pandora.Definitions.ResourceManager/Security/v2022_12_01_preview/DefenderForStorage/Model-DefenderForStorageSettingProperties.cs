using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2022_12_01_preview.DefenderForStorage;


internal class DefenderForStorageSettingPropertiesModel
{
    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("malwareScanning")]
    public MalwareScanningPropertiesModel? MalwareScanning { get; set; }

    [JsonPropertyName("overrideSubscriptionLevelSettings")]
    public bool? OverrideSubscriptionLevelSettings { get; set; }

    [JsonPropertyName("sensitiveDataDiscovery")]
    public SensitiveDataDiscoveryPropertiesModel? SensitiveDataDiscovery { get; set; }
}
