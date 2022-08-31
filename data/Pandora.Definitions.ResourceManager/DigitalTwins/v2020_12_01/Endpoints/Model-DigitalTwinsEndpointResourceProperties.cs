using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2020_12_01.Endpoints;


internal abstract class DigitalTwinsEndpointResourcePropertiesModel
{
    [JsonPropertyName("authenticationType")]
    public AuthenticationTypeConstant? AuthenticationType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("deadLetterSecret")]
    public string? DeadLetterSecret { get; set; }

    [JsonPropertyName("deadLetterUri")]
    public string? DeadLetterUri { get; set; }

    [JsonPropertyName("endpointType")]
    [ProvidesTypeHint]
    [Required]
    public EndpointTypeConstant EndpointType { get; set; }

    [JsonPropertyName("provisioningState")]
    public EndpointProvisioningStateConstant? ProvisioningState { get; set; }
}
