using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Zones;


internal class ZonePropertiesModel
{
    [JsonPropertyName("maxNumberOfRecordSets")]
    public int? MaxNumberOfRecordSets { get; set; }

    [JsonPropertyName("maxNumberOfRecordsPerRecordSet")]
    public int? MaxNumberOfRecordsPerRecordSet { get; set; }

    [JsonPropertyName("nameServers")]
    public List<string>? NameServers { get; set; }

    [JsonPropertyName("numberOfRecordSets")]
    public int? NumberOfRecordSets { get; set; }

    [JsonPropertyName("registrationVirtualNetworks")]
    public List<SubResourceModel>? RegistrationVirtualNetworks { get; set; }

    [JsonPropertyName("resolutionVirtualNetworks")]
    public List<SubResourceModel>? ResolutionVirtualNetworks { get; set; }

    [JsonPropertyName("zoneType")]
    public ZoneTypeConstant? ZoneType { get; set; }
}
