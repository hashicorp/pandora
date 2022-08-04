using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.PATCH;


internal class IPFilterRuleModel
{
    [JsonPropertyName("action")]
    [Required]
    public IPFilterActionTypeConstant Action { get; set; }

    [JsonPropertyName("filterName")]
    [Required]
    public string FilterName { get; set; }

    [JsonPropertyName("ipMask")]
    [Required]
    public string IPMask { get; set; }

    [JsonPropertyName("target")]
    public IPFilterTargetTypeConstant? Target { get; set; }
}
