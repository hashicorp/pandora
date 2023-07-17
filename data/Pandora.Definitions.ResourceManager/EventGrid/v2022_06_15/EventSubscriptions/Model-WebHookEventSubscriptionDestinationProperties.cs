using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;


internal class WebHookEventSubscriptionDestinationPropertiesModel
{
    [JsonPropertyName("azureActiveDirectoryApplicationIdOrUri")]
    public string? AzureActiveDirectoryApplicationIdOrUri { get; set; }

    [JsonPropertyName("azureActiveDirectoryTenantId")]
    public string? AzureActiveDirectoryTenantId { get; set; }

    [JsonPropertyName("deliveryAttributeMappings")]
    public List<DeliveryAttributeMappingModel>? DeliveryAttributeMappings { get; set; }

    [JsonPropertyName("endpointBaseUrl")]
    public string? EndpointBaseUrl { get; set; }

    [JsonPropertyName("endpointUrl")]
    public string? EndpointUrl { get; set; }

    [JsonPropertyName("maxEventsPerBatch")]
    public int? MaxEventsPerBatch { get; set; }

    [JsonPropertyName("preferredBatchSizeInKilobytes")]
    public int? PreferredBatchSizeInKilobytes { get; set; }
}
