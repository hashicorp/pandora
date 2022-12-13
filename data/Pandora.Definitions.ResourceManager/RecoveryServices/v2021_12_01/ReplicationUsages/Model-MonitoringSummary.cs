using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_12_01.ReplicationUsages;


internal class MonitoringSummaryModel
{
    [JsonPropertyName("deprecatedProviderCount")]
    public int? DeprecatedProviderCount { get; set; }

    [JsonPropertyName("eventsCount")]
    public int? EventsCount { get; set; }

    [JsonPropertyName("supportedProviderCount")]
    public int? SupportedProviderCount { get; set; }

    [JsonPropertyName("unHealthyProviderCount")]
    public int? UnHealthyProviderCount { get; set; }

    [JsonPropertyName("unHealthyVmCount")]
    public int? UnHealthyVMCount { get; set; }

    [JsonPropertyName("unsupportedProviderCount")]
    public int? UnsupportedProviderCount { get; set; }
}
