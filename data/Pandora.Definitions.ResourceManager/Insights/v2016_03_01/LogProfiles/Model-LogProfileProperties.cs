using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.LogProfiles;


internal class LogProfilePropertiesModel
{
    [JsonPropertyName("categories")]
    [Required]
    public List<string> Categories { get; set; }

    [JsonPropertyName("locations")]
    [Required]
    public List<string> Locations { get; set; }

    [JsonPropertyName("retentionPolicy")]
    [Required]
    public RetentionPolicyModel RetentionPolicy { get; set; }

    [JsonPropertyName("serviceBusRuleId")]
    public string? ServiceBusRuleId { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }
}
