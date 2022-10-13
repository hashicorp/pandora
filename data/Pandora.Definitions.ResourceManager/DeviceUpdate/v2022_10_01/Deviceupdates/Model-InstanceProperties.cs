using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.Deviceupdates;


internal class InstancePropertiesModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("diagnosticStorageProperties")]
    public DiagnosticStoragePropertiesModel? DiagnosticStorageProperties { get; set; }

    [JsonPropertyName("enableDiagnostics")]
    public bool? EnableDiagnostics { get; set; }

    [JsonPropertyName("iotHubs")]
    public List<IotHubSettingsModel>? IotHubs { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
