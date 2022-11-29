using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.Compute;


internal class RestorePointSourceMetadataModel
{
    [JsonPropertyName("diagnosticsProfile")]
    public DiagnosticsProfileModel? DiagnosticsProfile { get; set; }

    [JsonPropertyName("hardwareProfile")]
    public HardwareProfileModel? HardwareProfile { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("osProfile")]
    public OSProfileModel? OsProfile { get; set; }

    [JsonPropertyName("securityProfile")]
    public SecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public RestorePointSourceVMStorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }
}
