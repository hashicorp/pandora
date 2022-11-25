using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ExtendedLocation.v2021_08_15.CustomLocations;


internal class CustomLocationPropertiesModel
{
    [JsonPropertyName("authentication")]
    public CustomLocationPropertiesAuthenticationModel? Authentication { get; set; }

    [JsonPropertyName("clusterExtensionIds")]
    public List<string>? ClusterExtensionIds { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("hostResourceId")]
    public string? HostResourceId { get; set; }

    [JsonPropertyName("hostType")]
    public HostTypeConstant? HostType { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
