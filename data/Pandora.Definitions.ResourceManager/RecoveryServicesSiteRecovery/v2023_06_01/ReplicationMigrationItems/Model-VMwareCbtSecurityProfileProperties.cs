using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationMigrationItems;


internal class VMwareCbtSecurityProfilePropertiesModel
{
    [JsonPropertyName("isTargetVmConfidentialEncryptionEnabled")]
    public string? IsTargetVMConfidentialEncryptionEnabled { get; set; }

    [JsonPropertyName("isTargetVmIntegrityMonitoringEnabled")]
    public string? IsTargetVMIntegrityMonitoringEnabled { get; set; }

    [JsonPropertyName("isTargetVmSecureBootEnabled")]
    public string? IsTargetVMSecureBootEnabled { get; set; }

    [JsonPropertyName("isTargetVmTpmEnabled")]
    public string? IsTargetVMTpmEnabled { get; set; }

    [JsonPropertyName("targetVmSecurityType")]
    public SecurityTypeConstant? TargetVMSecurityType { get; set; }
}
