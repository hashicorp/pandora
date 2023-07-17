using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;


internal class EventSubscriptionPropertiesModel
{
    [JsonPropertyName("deadLetterDestination")]
    public DeadLetterDestinationModel? DeadLetterDestination { get; set; }

    [JsonPropertyName("deadLetterWithResourceIdentity")]
    public DeadLetterWithResourceIdentityModel? DeadLetterWithResourceIdentity { get; set; }

    [JsonPropertyName("deliveryWithResourceIdentity")]
    public DeliveryWithResourceIdentityModel? DeliveryWithResourceIdentity { get; set; }

    [JsonPropertyName("destination")]
    public EventSubscriptionDestinationModel? Destination { get; set; }

    [JsonPropertyName("eventDeliverySchema")]
    public EventDeliverySchemaConstant? EventDeliverySchema { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTimeUtc")]
    public DateTime? ExpirationTimeUtc { get; set; }

    [JsonPropertyName("filter")]
    public EventSubscriptionFilterModel? Filter { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("provisioningState")]
    public EventSubscriptionProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("retryPolicy")]
    public RetryPolicyModel? RetryPolicy { get; set; }

    [JsonPropertyName("topic")]
    public string? Topic { get; set; }
}
