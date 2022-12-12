using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.Service;


internal class ServiceDataFlowTemplateModel
{
    [JsonPropertyName("direction")]
    [Required]
    public SdfDirectionConstant Direction { get; set; }

    [JsonPropertyName("ports")]
    public List<string>? Ports { get; set; }

    [MinItems(1)]
    [JsonPropertyName("protocol")]
    [Required]
    public List<string> Protocol { get; set; }

    [MinItems(1)]
    [JsonPropertyName("remoteIpList")]
    [Required]
    public List<string> RemoteIPList { get; set; }

    [JsonPropertyName("templateName")]
    [Required]
    public string TemplateName { get; set; }
}
