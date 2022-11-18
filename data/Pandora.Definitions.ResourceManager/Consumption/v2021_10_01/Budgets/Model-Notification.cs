using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Budgets;


internal class NotificationModel
{
    [MinItems(0)]
    [MaxItems(50)]
    [JsonPropertyName("contactEmails")]
    [Required]
    public List<string> ContactEmails { get; set; }

    [MinItems(0)]
    [MaxItems(50)]
    [JsonPropertyName("contactGroups")]
    public List<string>? ContactGroups { get; set; }

    [JsonPropertyName("contactRoles")]
    public List<string>? ContactRoles { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("locale")]
    public CultureCodeConstant? Locale { get; set; }

    [JsonPropertyName("operator")]
    [Required]
    public OperatorTypeConstant Operator { get; set; }

    [JsonPropertyName("threshold")]
    [Required]
    public float Threshold { get; set; }

    [JsonPropertyName("thresholdType")]
    public ThresholdTypeConstant? ThresholdType { get; set; }
}
