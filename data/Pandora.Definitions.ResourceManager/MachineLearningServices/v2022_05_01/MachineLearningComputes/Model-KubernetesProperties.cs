using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;


internal class KubernetesPropertiesModel
{
    [JsonPropertyName("defaultInstanceType")]
    public string? DefaultInstanceType { get; set; }

    [JsonPropertyName("extensionInstanceReleaseTrain")]
    public string? ExtensionInstanceReleaseTrain { get; set; }

    [JsonPropertyName("extensionPrincipalId")]
    public string? ExtensionPrincipalId { get; set; }

    [JsonPropertyName("instanceTypes")]
    public Dictionary<string, InstanceTypeSchemaModel>? InstanceTypes { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("relayConnectionString")]
    public string? RelayConnectionString { get; set; }

    [JsonPropertyName("serviceBusConnectionString")]
    public string? ServiceBusConnectionString { get; set; }

    [JsonPropertyName("vcName")]
    public string? VcName { get; set; }
}
