using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.SourceControlConfiguration;


internal class ComplianceStatusModel
{
    [JsonPropertyName("complianceState")]
    public ComplianceStateTypeConstant? ComplianceState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastConfigApplied")]
    public DateTime? LastConfigApplied { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("messageLevel")]
    public MessageLevelTypeConstant? MessageLevel { get; set; }
}
