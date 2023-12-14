using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.NetworkSecurityPerimeterConfigurations;


internal class NetworkSecurityPerimeterConfigurationPropertiesModel
{
    [JsonPropertyName("networkSecurityPerimeter")]
    public NSPConfigPerimeterModel? NetworkSecurityPerimeter { get; set; }

    [JsonPropertyName("profile")]
    public NSPConfigProfileModel? Profile { get; set; }

    [JsonPropertyName("provisioningIssues")]
    public List<NSPProvisioningIssueModel>? ProvisioningIssues { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceAssociation")]
    public NSPConfigAssociationModel? ResourceAssociation { get; set; }
}
