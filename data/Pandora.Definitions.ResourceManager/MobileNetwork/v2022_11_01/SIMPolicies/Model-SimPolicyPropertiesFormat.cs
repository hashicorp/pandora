using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMPolicies;


internal class SimPolicyPropertiesFormatModel
{
    [JsonPropertyName("defaultSlice")]
    [Required]
    public SliceResourceIdModel DefaultSlice { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("registrationTimer")]
    public int? RegistrationTimer { get; set; }

    [JsonPropertyName("rfspIndex")]
    public int? RfspIndex { get; set; }

    [JsonPropertyName("siteProvisioningState")]
    public Dictionary<string, SiteProvisioningStateConstant>? SiteProvisioningState { get; set; }

    [MinItems(1)]
    [JsonPropertyName("sliceConfigurations")]
    [Required]
    public List<SliceConfigurationModel> SliceConfigurations { get; set; }

    [JsonPropertyName("ueAmbr")]
    [Required]
    public AmbrModel UeAmbr { get; set; }
}
