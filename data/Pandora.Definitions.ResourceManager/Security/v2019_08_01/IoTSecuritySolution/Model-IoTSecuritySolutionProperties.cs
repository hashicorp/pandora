using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolution;


internal class IoTSecuritySolutionPropertiesModel
{
    [JsonPropertyName("additionalWorkspaces")]
    public List<AdditionalWorkspacesPropertiesModel>? AdditionalWorkspaces { get; set; }

    [JsonPropertyName("autoDiscoveredResources")]
    public List<string>? AutoDiscoveredResources { get; set; }

    [JsonPropertyName("disabledDataSources")]
    public List<DataSourceConstant>? DisabledDataSources { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("export")]
    public List<ExportDataConstant>? Export { get; set; }

    [JsonPropertyName("iotHubs")]
    [Required]
    public List<string> IotHubs { get; set; }

    [JsonPropertyName("recommendationsConfiguration")]
    public List<RecommendationConfigurationPropertiesModel>? RecommendationsConfiguration { get; set; }

    [JsonPropertyName("status")]
    public SecuritySolutionStatusConstant? Status { get; set; }

    [JsonPropertyName("unmaskedIpLoggingStatus")]
    public UnmaskedIPLoggingStatusConstant? UnmaskedIPLoggingStatus { get; set; }

    [JsonPropertyName("userDefinedResources")]
    public UserDefinedResourcesPropertiesModel? UserDefinedResources { get; set; }

    [JsonPropertyName("workspace")]
    public string? Workspace { get; set; }
}
