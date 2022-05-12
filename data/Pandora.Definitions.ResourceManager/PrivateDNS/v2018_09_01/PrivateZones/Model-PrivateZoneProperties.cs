using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.PrivateZones;


internal class PrivateZonePropertiesModel
{
    [JsonPropertyName("maxNumberOfRecordSets")]
    public int? MaxNumberOfRecordSets { get; set; }

    [JsonPropertyName("maxNumberOfVirtualNetworkLinks")]
    public int? MaxNumberOfVirtualNetworkLinks { get; set; }

    [JsonPropertyName("maxNumberOfVirtualNetworkLinksWithRegistration")]
    public int? MaxNumberOfVirtualNetworkLinksWithRegistration { get; set; }

    [JsonPropertyName("numberOfRecordSets")]
    public int? NumberOfRecordSets { get; set; }

    [JsonPropertyName("numberOfVirtualNetworkLinks")]
    public int? NumberOfVirtualNetworkLinks { get; set; }

    [JsonPropertyName("numberOfVirtualNetworkLinksWithRegistration")]
    public int? NumberOfVirtualNetworkLinksWithRegistration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
