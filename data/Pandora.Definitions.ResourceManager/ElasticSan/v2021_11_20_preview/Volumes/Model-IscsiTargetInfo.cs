using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.Volumes;


internal class IscsiTargetInfoModel
{
    [JsonPropertyName("provisioningState")]
    public ProvisioningStatesConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public OperationalStatusConstant? Status { get; set; }

    [JsonPropertyName("targetIqn")]
    public string? TargetIqn { get; set; }

    [JsonPropertyName("targetPortalHostname")]
    public string? TargetPortalHostname { get; set; }

    [JsonPropertyName("targetPortalPort")]
    public int? TargetPortalPort { get; set; }
}
