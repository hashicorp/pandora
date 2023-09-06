using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class L3NetworkAttachmentConfigurationModel
{
    [JsonPropertyName("ipamEnabled")]
    public L3NetworkConfigurationIPamEnabledConstant? IPamEnabled { get; set; }

    [JsonPropertyName("networkId")]
    [Required]
    public string NetworkId { get; set; }

    [JsonPropertyName("pluginType")]
    public KubernetesPluginTypeConstant? PluginType { get; set; }
}
