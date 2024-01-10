using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceEnvironments;


internal class IPSecurityRestrictionModel
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("headers")]
    public Dictionary<string, List<string>>? Headers { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("subnetMask")]
    public string? SubnetMask { get; set; }

    [JsonPropertyName("subnetTrafficTag")]
    public int? SubnetTrafficTag { get; set; }

    [JsonPropertyName("tag")]
    public IPFilterTagConstant? Tag { get; set; }

    [JsonPropertyName("vnetSubnetResourceId")]
    public string? VnetSubnetResourceId { get; set; }

    [JsonPropertyName("vnetTrafficTag")]
    public int? VnetTrafficTag { get; set; }
}
