using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PublicIPAddresses;


internal class PublicIPDdosProtectionStatusResultModel
{
    [JsonPropertyName("ddosProtectionPlanId")]
    public string? DdosProtectionPlanId { get; set; }

    [JsonPropertyName("isWorkloadProtected")]
    public IsWorkloadProtectedConstant? IsWorkloadProtected { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIPAddress { get; set; }

    [JsonPropertyName("publicIpAddressId")]
    public string? PublicIPAddressId { get; set; }
}
