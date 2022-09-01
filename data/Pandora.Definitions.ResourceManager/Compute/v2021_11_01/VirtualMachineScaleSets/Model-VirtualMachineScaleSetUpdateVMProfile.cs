using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;


internal class VirtualMachineScaleSetUpdateVMProfileModel
{
    [JsonPropertyName("billingProfile")]
    public BillingProfileModel? BillingProfile { get; set; }

    [JsonPropertyName("diagnosticsProfile")]
    public DiagnosticsProfileModel? DiagnosticsProfile { get; set; }

    [JsonPropertyName("extensionProfile")]
    public VirtualMachineScaleSetExtensionProfileModel? ExtensionProfile { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("networkProfile")]
    public VirtualMachineScaleSetUpdateNetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("osProfile")]
    public VirtualMachineScaleSetUpdateOSProfileModel? OsProfile { get; set; }

    [JsonPropertyName("scheduledEventsProfile")]
    public ScheduledEventsProfileModel? ScheduledEventsProfile { get; set; }

    [JsonPropertyName("securityProfile")]
    public SecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public VirtualMachineScaleSetUpdateStorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("userData")]
    public string? UserData { get; set; }
}
