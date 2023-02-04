using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.ManagedClusters;


internal class ManagedClusterAADProfileModel
{
    [JsonPropertyName("clientAppID")]
    [Required]
    public string ClientAppID { get; set; }

    [JsonPropertyName("serverAppID")]
    [Required]
    public string ServerAppID { get; set; }

    [JsonPropertyName("serverAppSecret")]
    public string? ServerAppSecret { get; set; }

    [JsonPropertyName("tenantID")]
    public string? TenantID { get; set; }
}
