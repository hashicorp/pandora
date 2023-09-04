using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.Registries;


internal class RegistryPropertiesUpdateParametersModel
{
    [JsonPropertyName("adminUserEnabled")]
    public bool? AdminUserEnabled { get; set; }

    [JsonPropertyName("anonymousPullEnabled")]
    public bool? AnonymousPullEnabled { get; set; }

    [JsonPropertyName("dataEndpointEnabled")]
    public bool? DataEndpointEnabled { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionPropertyModel? Encryption { get; set; }

    [JsonPropertyName("networkRuleBypassOptions")]
    public NetworkRuleBypassOptionsConstant? NetworkRuleBypassOptions { get; set; }

    [JsonPropertyName("networkRuleSet")]
    public NetworkRuleSetModel? NetworkRuleSet { get; set; }

    [JsonPropertyName("policies")]
    public PoliciesModel? Policies { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }
}
