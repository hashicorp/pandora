using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{

    internal class ProfileProperties
    {
        [JsonPropertyName("allowedEndpointRecordTypes")]
        public List<AllowedEndpointRecordType>? AllowedEndpointRecordTypes { get; set; }

        [JsonPropertyName("dnsConfig")]
        public DnsConfig? DnsConfig { get; set; }

        [JsonPropertyName("endpoints")]
        public List<Endpoint>? Endpoints { get; set; }

        [JsonPropertyName("maxReturn")]
        public int? MaxReturn { get; set; }

        [JsonPropertyName("monitorConfig")]
        public MonitorConfig? MonitorConfig { get; set; }

        [JsonPropertyName("profileStatus")]
        public ProfileStatus? ProfileStatus { get; set; }

        [JsonPropertyName("trafficRoutingMethod")]
        public TrafficRoutingMethod? TrafficRoutingMethod { get; set; }

        [JsonPropertyName("trafficViewEnrollmentStatus")]
        public TrafficViewEnrollmentStatus? TrafficViewEnrollmentStatus { get; set; }
    }
}
