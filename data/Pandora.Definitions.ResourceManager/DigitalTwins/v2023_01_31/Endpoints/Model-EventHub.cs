using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.Endpoints;

[ValueForType("EventHub")]
internal class EventHubModel : DigitalTwinsEndpointResourcePropertiesModel
{
    [JsonPropertyName("connectionStringPrimaryKey")]
    public string? ConnectionStringPrimaryKey { get; set; }

    [JsonPropertyName("connectionStringSecondaryKey")]
    public string? ConnectionStringSecondaryKey { get; set; }

    [JsonPropertyName("endpointUri")]
    public string? EndpointUri { get; set; }

    [JsonPropertyName("entityPath")]
    public string? EntityPath { get; set; }
}
