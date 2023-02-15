using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class AppResourcePropertiesModel
{
    [JsonPropertyName("addonConfigs")]
    public Dictionary<string, object>? AddonConfigs { get; set; }

    [JsonPropertyName("customPersistentDisks")]
    public List<CustomPersistentDiskResourceModel>? CustomPersistentDisks { get; set; }

    [JsonPropertyName("enableEndToEndTLS")]
    public bool? EnableEndToEndTLS { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("httpsOnly")]
    public bool? HTTPSOnly { get; set; }

    [JsonPropertyName("ingressSettings")]
    public IngressSettingsModel? IngressSettings { get; set; }

    [JsonPropertyName("loadedCertificates")]
    public List<LoadedCertificateModel>? LoadedCertificates { get; set; }

    [JsonPropertyName("persistentDisk")]
    public PersistentDiskModel? PersistentDisk { get; set; }

    [JsonPropertyName("provisioningState")]
    public AppResourceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("temporaryDisk")]
    public TemporaryDiskModel? TemporaryDisk { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("vnetAddons")]
    public AppVNetAddonsModel? VnetAddons { get; set; }
}
