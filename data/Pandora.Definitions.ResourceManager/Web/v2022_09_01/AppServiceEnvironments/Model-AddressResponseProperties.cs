using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class AddressResponsePropertiesModel
{
    [JsonPropertyName("internalIpAddress")]
    public string? InternalIPAddress { get; set; }

    [JsonPropertyName("outboundIpAddresses")]
    public List<string>? OutboundIPAddresses { get; set; }

    [JsonPropertyName("serviceIpAddress")]
    public string? ServiceIPAddress { get; set; }

    [JsonPropertyName("vipMappings")]
    public List<VirtualIPMappingModel>? VipMappings { get; set; }
}
