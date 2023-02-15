using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.ManagedClusters;


internal class ManagedClusterAADProfileModel
{
    [JsonPropertyName("adminGroupObjectIDs")]
    public List<string>? AdminGroupObjectIDs { get; set; }

    [JsonPropertyName("clientAppID")]
    public string? ClientAppID { get; set; }

    [JsonPropertyName("enableAzureRBAC")]
    public bool? EnableAzureRBAC { get; set; }

    [JsonPropertyName("managed")]
    public bool? Managed { get; set; }

    [JsonPropertyName("serverAppID")]
    public string? ServerAppID { get; set; }

    [JsonPropertyName("serverAppSecret")]
    public string? ServerAppSecret { get; set; }

    [JsonPropertyName("tenantID")]
    public string? TenantID { get; set; }
}
