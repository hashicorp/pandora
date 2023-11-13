using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class VnetInfoModel
{
    [JsonPropertyName("certBlob")]
    public string? CertBlob { get; set; }

    [JsonPropertyName("certThumbprint")]
    public string? CertThumbprint { get; set; }

    [JsonPropertyName("dnsServers")]
    public string? DnsServers { get; set; }

    [JsonPropertyName("isSwift")]
    public bool? IsSwift { get; set; }

    [JsonPropertyName("resyncRequired")]
    public bool? ResyncRequired { get; set; }

    [JsonPropertyName("routes")]
    public List<VnetRouteModel>? Routes { get; set; }

    [JsonPropertyName("vnetResourceId")]
    public string? VnetResourceId { get; set; }
}
