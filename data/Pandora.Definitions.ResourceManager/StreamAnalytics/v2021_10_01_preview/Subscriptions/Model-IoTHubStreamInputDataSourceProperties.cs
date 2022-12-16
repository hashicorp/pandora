using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class IoTHubStreamInputDataSourcePropertiesModel
{
    [JsonPropertyName("consumerGroupName")]
    public string? ConsumerGroupName { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("iotHubNamespace")]
    public string? IotHubNamespace { get; set; }

    [JsonPropertyName("sharedAccessPolicyKey")]
    public string? SharedAccessPolicyKey { get; set; }

    [JsonPropertyName("sharedAccessPolicyName")]
    public string? SharedAccessPolicyName { get; set; }
}
