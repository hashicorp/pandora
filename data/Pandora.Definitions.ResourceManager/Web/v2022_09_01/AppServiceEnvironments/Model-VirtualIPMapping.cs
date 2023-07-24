using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class VirtualIPMappingModel
{
    [JsonPropertyName("inUse")]
    public bool? InUse { get; set; }

    [JsonPropertyName("internalHttpPort")]
    public int? InternalHTTPPort { get; set; }

    [JsonPropertyName("internalHttpsPort")]
    public int? InternalHTTPSPort { get; set; }

    [JsonPropertyName("serviceName")]
    public string? ServiceName { get; set; }

    [JsonPropertyName("virtualIP")]
    public string? VirtualIP { get; set; }
}
