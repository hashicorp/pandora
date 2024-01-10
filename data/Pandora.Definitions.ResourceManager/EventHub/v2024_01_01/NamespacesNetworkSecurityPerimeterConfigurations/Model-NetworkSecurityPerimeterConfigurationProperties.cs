using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NamespacesNetworkSecurityPerimeterConfigurations;


internal class NetworkSecurityPerimeterConfigurationPropertiesModel
{
    [JsonPropertyName("applicableFeatures")]
    public List<string>? ApplicableFeatures { get; set; }

    [JsonPropertyName("isBackingResource")]
    public bool? IsBackingResource { get; set; }

    [JsonPropertyName("networkSecurityPerimeter")]
    public NetworkSecurityPerimeterModel? NetworkSecurityPerimeter { get; set; }

    [JsonPropertyName("parentAssociationName")]
    public string? ParentAssociationName { get; set; }

    [JsonPropertyName("profile")]
    public NetworkSecurityPerimeterConfigurationPropertiesProfileModel? Profile { get; set; }

    [JsonPropertyName("provisioningIssues")]
    public List<ProvisioningIssueModel>? ProvisioningIssues { get; set; }

    [JsonPropertyName("provisioningState")]
    public NetworkSecurityPerimeterConfigurationProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceAssociation")]
    public NetworkSecurityPerimeterConfigurationPropertiesResourceAssociationModel? ResourceAssociation { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }
}
