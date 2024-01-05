using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.VolumeQuotaRules;


internal class VolumeQuotaRulesPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("quotaSizeInKiBs")]
    public int? QuotaSizeInKiBs { get; set; }

    [JsonPropertyName("quotaTarget")]
    public string? QuotaTarget { get; set; }

    [JsonPropertyName("quotaType")]
    public TypeConstant? QuotaType { get; set; }
}
