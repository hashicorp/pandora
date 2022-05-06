using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;


internal class ProfilePropertiesModel
{
    [JsonPropertyName("allowedEndpointRecordTypes")]
    public List<AllowedEndpointRecordTypeConstant>? AllowedEndpointRecordTypes { get; set; }

    [JsonPropertyName("dnsConfig")]
    public DnsConfigModel? DnsConfig { get; set; }

    [JsonPropertyName("endpoints")]
    public List<EndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("maxReturn")]
    public int? MaxReturn { get; set; }

    [JsonPropertyName("monitorConfig")]
    public MonitorConfigModel? MonitorConfig { get; set; }

    [JsonPropertyName("profileStatus")]
    public ProfileStatusConstant? ProfileStatus { get; set; }

    [JsonPropertyName("trafficRoutingMethod")]
    public TrafficRoutingMethodConstant? TrafficRoutingMethod { get; set; }

    [JsonPropertyName("trafficViewEnrollmentStatus")]
    public TrafficViewEnrollmentStatusConstant? TrafficViewEnrollmentStatus { get; set; }
}
