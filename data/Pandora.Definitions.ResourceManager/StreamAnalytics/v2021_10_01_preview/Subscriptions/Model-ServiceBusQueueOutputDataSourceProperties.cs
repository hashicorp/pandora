using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class ServiceBusQueueOutputDataSourcePropertiesModel
{
    [JsonPropertyName("authenticationMode")]
    public AuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("propertyColumns")]
    public List<string>? PropertyColumns { get; set; }

    [JsonPropertyName("queueName")]
    public string? QueueName { get; set; }

    [JsonPropertyName("serviceBusNamespace")]
    public string? ServiceBusNamespace { get; set; }

    [JsonPropertyName("sharedAccessPolicyKey")]
    public string? SharedAccessPolicyKey { get; set; }

    [JsonPropertyName("sharedAccessPolicyName")]
    public string? SharedAccessPolicyName { get; set; }

    [JsonPropertyName("systemPropertyColumns")]
    public object? SystemPropertyColumns { get; set; }
}
