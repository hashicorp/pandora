using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ValueForType("ServiceInitiated")]
internal class ServiceInitiatedSoftwareConfigurationModel : SoftwareConfigurationModel
{
    [JsonPropertyName("bomUrl")]
    [Required]
    public string BomUrl { get; set; }

    [JsonPropertyName("highAvailabilitySoftwareConfiguration")]
    public HighAvailabilitySoftwareConfigurationModel? HighAvailabilitySoftwareConfiguration { get; set; }

    [JsonPropertyName("sapBitsStorageAccountId")]
    [Required]
    public string SapBitsStorageAccountId { get; set; }

    [JsonPropertyName("sapFqdn")]
    [Required]
    public string SapFqdn { get; set; }

    [JsonPropertyName("softwareVersion")]
    [Required]
    public string SoftwareVersion { get; set; }

    [JsonPropertyName("sshPrivateKey")]
    [Required]
    public string SshPrivateKey { get; set; }
}
