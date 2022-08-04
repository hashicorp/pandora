using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.PUT;


internal class IotDpsPropertiesDescriptionModel
{
    [JsonPropertyName("allocationPolicy")]
    public AllocationPolicyConstant? AllocationPolicy { get; set; }

    [JsonPropertyName("authorizationPolicies")]
    public List<SharedAccessSignatureAuthorizationRuleAccessRightsDescriptionModel>? AuthorizationPolicies { get; set; }

    [JsonPropertyName("deviceProvisioningHostName")]
    public string? DeviceProvisioningHostName { get; set; }

    [JsonPropertyName("enableDataResidency")]
    public bool? EnableDataResidency { get; set; }

    [JsonPropertyName("ipFilterRules")]
    public List<IPFilterRuleModel>? IPFilterRules { get; set; }

    [JsonPropertyName("idScope")]
    public string? IdScope { get; set; }

    [JsonPropertyName("iotHubs")]
    public List<IotHubDefinitionDescriptionModel>? IotHubs { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("serviceOperationsHostName")]
    public string? ServiceOperationsHostName { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }
}
