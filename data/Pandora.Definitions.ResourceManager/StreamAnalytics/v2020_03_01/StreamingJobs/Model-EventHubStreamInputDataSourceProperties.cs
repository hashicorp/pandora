using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;


internal class EventHubStreamInputDataSourcePropertiesModel
{
    [JsonPropertyName("authenticationMode")]
    public AuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("consumerGroupName")]
    public string? ConsumerGroupName { get; set; }

    [JsonPropertyName("eventHubName")]
    public string? EventHubName { get; set; }

    [JsonPropertyName("serviceBusNamespace")]
    public string? ServiceBusNamespace { get; set; }

    [JsonPropertyName("sharedAccessPolicyKey")]
    public string? SharedAccessPolicyKey { get; set; }

    [JsonPropertyName("sharedAccessPolicyName")]
    public string? SharedAccessPolicyName { get; set; }
}
