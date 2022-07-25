using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Workspaces;


internal class DiagnoseRequestPropertiesModel
{
    [JsonPropertyName("applicationInsights")]
    public Dictionary<string, object>? ApplicationInsights { get; set; }

    [JsonPropertyName("containerRegistry")]
    public Dictionary<string, object>? ContainerRegistry { get; set; }

    [JsonPropertyName("dnsResolution")]
    public Dictionary<string, object>? DnsResolution { get; set; }

    [JsonPropertyName("keyVault")]
    public Dictionary<string, object>? KeyVault { get; set; }

    [JsonPropertyName("nsg")]
    public Dictionary<string, object>? Nsg { get; set; }

    [JsonPropertyName("others")]
    public Dictionary<string, object>? Others { get; set; }

    [JsonPropertyName("resourceLock")]
    public Dictionary<string, object>? ResourceLock { get; set; }

    [JsonPropertyName("storageAccount")]
    public Dictionary<string, object>? StorageAccount { get; set; }

    [JsonPropertyName("udr")]
    public Dictionary<string, object>? Udr { get; set; }
}
