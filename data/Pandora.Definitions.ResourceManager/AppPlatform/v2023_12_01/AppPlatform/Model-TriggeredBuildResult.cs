using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;


internal class TriggeredBuildResultModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("lastTransitionReason")]
    public string? LastTransitionReason { get; set; }

    [JsonPropertyName("lastTransitionStatus")]
    public string? LastTransitionStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastTransitionTime")]
    public DateTime? LastTransitionTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public TriggeredBuildResultProvisioningStateConstant? ProvisioningState { get; set; }
}
