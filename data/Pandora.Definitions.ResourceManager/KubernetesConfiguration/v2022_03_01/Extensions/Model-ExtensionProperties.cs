using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.Extensions;


internal class ExtensionPropertiesModel
{
    [JsonPropertyName("aksAssignedIdentity")]
    public ExtensionPropertiesAksAssignedIdentityModel? AksAssignedIdentity { get; set; }

    [JsonPropertyName("autoUpgradeMinorVersion")]
    public bool? AutoUpgradeMinorVersion { get; set; }

    [JsonPropertyName("configurationProtectedSettings")]
    public Dictionary<string, string>? ConfigurationProtectedSettings { get; set; }

    [JsonPropertyName("configurationSettings")]
    public Dictionary<string, string>? ConfigurationSettings { get; set; }

    [JsonPropertyName("customLocationSettings")]
    public Dictionary<string, string>? CustomLocationSettings { get; set; }

    [JsonPropertyName("errorInfo")]
    public ErrorDetailModel? ErrorInfo { get; set; }

    [JsonPropertyName("extensionType")]
    public string? ExtensionType { get; set; }

    [JsonPropertyName("installedVersion")]
    public string? InstalledVersion { get; set; }

    [JsonPropertyName("packageUri")]
    public string? PackageUri { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("releaseTrain")]
    public string? ReleaseTrain { get; set; }

    [JsonPropertyName("scope")]
    public ScopeModel? Scope { get; set; }

    [JsonPropertyName("statuses")]
    public List<ExtensionStatusModel>? Statuses { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
