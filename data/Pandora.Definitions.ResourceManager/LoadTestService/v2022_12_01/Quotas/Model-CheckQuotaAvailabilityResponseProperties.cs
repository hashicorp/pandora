using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01.Quotas;


internal class CheckQuotaAvailabilityResponsePropertiesModel
{
    [JsonPropertyName("availabilityStatus")]
    public string? AvailabilityStatus { get; set; }

    [JsonPropertyName("isAvailable")]
    public bool? IsAvailable { get; set; }
}
