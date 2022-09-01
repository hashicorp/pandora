using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.NamespacesNetworkSecurityPerimeterConfigurations;


internal class NetworkSecurityPerimeterConfigurationPropertiesModel
{
    [JsonPropertyName("networkSecurityPerimeter")]
    public NetworkSecurityPerimeterModel? NetworkSecurityPerimeter { get; set; }

    [JsonPropertyName("profile")]
    public NetworkSecurityPerimeterConfigurationPropertiesProfileModel? Profile { get; set; }

    [JsonPropertyName("provisioningIssues")]
    public List<ProvisioningIssueModel>? ProvisioningIssues { get; set; }

    [JsonPropertyName("provisioningState")]
    public NetworkSecurityPerimeterConfigurationProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceAssociation")]
    public NetworkSecurityPerimeterConfigurationPropertiesResourceAssociationModel? ResourceAssociation { get; set; }
}
