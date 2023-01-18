using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironments;


internal class IntegrationServiceEnvironmentPropertiesModel
{
    [JsonPropertyName("encryptionConfiguration")]
    public IntegrationServiceEnvironmenEncryptionConfigurationModel? EncryptionConfiguration { get; set; }

    [JsonPropertyName("endpointsConfiguration")]
    public FlowEndpointsConfigurationModel? EndpointsConfiguration { get; set; }

    [JsonPropertyName("integrationServiceEnvironmentId")]
    public string? IntegrationServiceEnvironmentId { get; set; }

    [JsonPropertyName("networkConfiguration")]
    public NetworkConfigurationModel? NetworkConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkflowProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("state")]
    public WorkflowStateConstant? State { get; set; }
}
