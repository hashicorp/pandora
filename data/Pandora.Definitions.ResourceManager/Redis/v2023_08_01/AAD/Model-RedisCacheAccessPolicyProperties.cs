using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.AAD;


internal class RedisCacheAccessPolicyPropertiesModel
{
    [JsonPropertyName("permissions")]
    [Required]
    public string Permissions { get; set; }

    [JsonPropertyName("provisioningState")]
    public AccessPolicyProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("type")]
    public AccessPolicyTypeConstant? Type { get; set; }
}
