using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_03_01.ContainerInstance;


internal class ContainerGroupPropertiesModel
{
    [JsonPropertyName("containers")]
    [Required]
    public List<ContainerModel> Containers { get; set; }

    [JsonPropertyName("diagnostics")]
    public ContainerGroupDiagnosticsModel? Diagnostics { get; set; }

    [JsonPropertyName("dnsConfig")]
    public DnsConfigurationModel? DnsConfig { get; set; }

    [JsonPropertyName("encryptionProperties")]
    public EncryptionPropertiesModel? EncryptionProperties { get; set; }

    [JsonPropertyName("ipAddress")]
    public IPAddressModel? IPAddress { get; set; }

    [JsonPropertyName("imageRegistryCredentials")]
    public List<ImageRegistryCredentialModel>? ImageRegistryCredentials { get; set; }

    [JsonPropertyName("initContainers")]
    public List<InitContainerDefinitionModel>? InitContainers { get; set; }

    [JsonPropertyName("instanceView")]
    public ContainerGroupPropertiesInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("networkProfile")]
    public ContainerGroupNetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("osType")]
    [Required]
    public OperatingSystemTypesConstant OsType { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("restartPolicy")]
    public ContainerGroupRestartPolicyConstant? RestartPolicy { get; set; }

    [JsonPropertyName("sku")]
    public ContainerGroupSkuConstant? Sku { get; set; }

    [JsonPropertyName("volumes")]
    public List<VolumeModel>? Volumes { get; set; }
}
