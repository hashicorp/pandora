using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_11_01.IotConnectors;


internal class IotConnectorPropertiesModel
{
    [JsonPropertyName("deviceMapping")]
    public IotMappingPropertiesModel? DeviceMapping { get; set; }

    [JsonPropertyName("ingestionEndpointConfiguration")]
    public IotEventHubIngestionEndpointConfigurationModel? IngestionEndpointConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
