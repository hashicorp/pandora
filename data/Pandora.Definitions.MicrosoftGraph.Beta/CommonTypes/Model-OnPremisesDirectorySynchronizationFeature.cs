// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesDirectorySynchronizationFeatureModel
{
    [JsonPropertyName("blockCloudObjectTakeoverThroughHardMatchEnabled")]
    public bool? BlockCloudObjectTakeoverThroughHardMatchEnabled { get; set; }

    [JsonPropertyName("blockSoftMatchEnabled")]
    public bool? BlockSoftMatchEnabled { get; set; }

    [JsonPropertyName("bypassDirSyncOverridesEnabled")]
    public bool? BypassDirSyncOverridesEnabled { get; set; }

    [JsonPropertyName("cloudPasswordPolicyForPasswordSyncedUsersEnabled")]
    public bool? CloudPasswordPolicyForPasswordSyncedUsersEnabled { get; set; }

    [JsonPropertyName("concurrentCredentialUpdateEnabled")]
    public bool? ConcurrentCredentialUpdateEnabled { get; set; }

    [JsonPropertyName("concurrentOrgIdProvisioningEnabled")]
    public bool? ConcurrentOrgIdProvisioningEnabled { get; set; }

    [JsonPropertyName("deviceWritebackEnabled")]
    public bool? DeviceWritebackEnabled { get; set; }

    [JsonPropertyName("directoryExtensionsEnabled")]
    public bool? DirectoryExtensionsEnabled { get; set; }

    [JsonPropertyName("fopeConflictResolutionEnabled")]
    public bool? FopeConflictResolutionEnabled { get; set; }

    [JsonPropertyName("groupWriteBackEnabled")]
    public bool? GroupWriteBackEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordSyncEnabled")]
    public bool? PasswordSyncEnabled { get; set; }

    [JsonPropertyName("passwordWritebackEnabled")]
    public bool? PasswordWritebackEnabled { get; set; }

    [JsonPropertyName("quarantineUponProxyAddressesConflictEnabled")]
    public bool? QuarantineUponProxyAddressesConflictEnabled { get; set; }

    [JsonPropertyName("quarantineUponUpnConflictEnabled")]
    public bool? QuarantineUponUpnConflictEnabled { get; set; }

    [JsonPropertyName("softMatchOnUpnEnabled")]
    public bool? SoftMatchOnUpnEnabled { get; set; }

    [JsonPropertyName("synchronizeUpnForManagedUsersEnabled")]
    public bool? SynchronizeUpnForManagedUsersEnabled { get; set; }

    [JsonPropertyName("unifiedGroupWritebackEnabled")]
    public bool? UnifiedGroupWritebackEnabled { get; set; }

    [JsonPropertyName("userForcePasswordChangeOnLogonEnabled")]
    public bool? UserForcePasswordChangeOnLogonEnabled { get; set; }

    [JsonPropertyName("userWritebackEnabled")]
    public bool? UserWritebackEnabled { get; set; }
}
