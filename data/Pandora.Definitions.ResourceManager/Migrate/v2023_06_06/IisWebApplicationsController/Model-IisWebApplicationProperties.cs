using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.IisWebApplicationsController;


internal class IisWebApplicationPropertiesModel
{
    [JsonPropertyName("applianceNames")]
    public List<string>? ApplianceNames { get; set; }

    [JsonPropertyName("applications")]
    public List<IisApplicationUnitModel>? Applications { get; set; }

    [JsonPropertyName("bindings")]
    public List<FrontEndBindingModel>? Bindings { get; set; }

    [JsonPropertyName("configurations")]
    public List<WebApplicationConfigurationUnitModel>? Configurations { get; set; }

    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("directories")]
    public List<WebApplicationDirectoryUnitModel>? Directories { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errors")]
    public List<HealthErrorDetailsModel>? Errors { get; set; }

    [JsonPropertyName("frameworks")]
    public List<WebApplicationFrameworkModel>? Frameworks { get; set; }

    [JsonPropertyName("hasErrors")]
    public bool? HasErrors { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("machineDisplayName")]
    public string? MachineDisplayName { get; set; }

    [JsonPropertyName("physicalPath")]
    public string? PhysicalPath { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serverType")]
    public string? ServerType { get; set; }

    [JsonPropertyName("staticFolders")]
    public List<string>? StaticFolders { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("virtualApplications")]
    public List<IisVirtualApplicationUnitModel>? VirtualApplications { get; set; }

    [JsonPropertyName("virtualPath")]
    public string? VirtualPath { get; set; }

    [JsonPropertyName("webServerId")]
    public string? WebServerId { get; set; }

    [JsonPropertyName("webServerName")]
    public string? WebServerName { get; set; }
}
