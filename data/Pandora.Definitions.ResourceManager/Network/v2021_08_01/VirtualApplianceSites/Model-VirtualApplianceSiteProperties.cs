using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualApplianceSites;


internal class VirtualApplianceSitePropertiesModel
{
    [JsonPropertyName("addressPrefix")]
    public string? AddressPrefix { get; set; }

    [JsonPropertyName("o365Policy")]
    public Office365PolicyPropertiesModel? O365Policy { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
