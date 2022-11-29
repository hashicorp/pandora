using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachines;


internal class VirtualMachinePropertiesModel
{
    [JsonPropertyName("additionalCapabilities")]
    public AdditionalCapabilitiesModel? AdditionalCapabilities { get; set; }

    [JsonPropertyName("applicationProfile")]
    public ApplicationProfileModel? ApplicationProfile { get; set; }

    [JsonPropertyName("availabilitySet")]
    public SubResourceModel? AvailabilitySet { get; set; }

    [JsonPropertyName("billingProfile")]
    public BillingProfileModel? BillingProfile { get; set; }

    [JsonPropertyName("capacityReservation")]
    public CapacityReservationProfileModel? CapacityReservation { get; set; }

    [JsonPropertyName("diagnosticsProfile")]
    public DiagnosticsProfileModel? DiagnosticsProfile { get; set; }

    [JsonPropertyName("evictionPolicy")]
    public VirtualMachineEvictionPolicyTypesConstant? EvictionPolicy { get; set; }

    [JsonPropertyName("extensionsTimeBudget")]
    public string? ExtensionsTimeBudget { get; set; }

    [JsonPropertyName("hardwareProfile")]
    public HardwareProfileModel? HardwareProfile { get; set; }

    [JsonPropertyName("host")]
    public SubResourceModel? Host { get; set; }

    [JsonPropertyName("hostGroup")]
    public SubResourceModel? HostGroup { get; set; }

    [JsonPropertyName("instanceView")]
    public VirtualMachineInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("osProfile")]
    public OSProfileModel? OsProfile { get; set; }

    [JsonPropertyName("platformFaultDomain")]
    public int? PlatformFaultDomain { get; set; }

    [JsonPropertyName("priority")]
    public VirtualMachinePriorityTypesConstant? Priority { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("proximityPlacementGroup")]
    public SubResourceModel? ProximityPlacementGroup { get; set; }

    [JsonPropertyName("scheduledEventsProfile")]
    public ScheduledEventsProfileModel? ScheduledEventsProfile { get; set; }

    [JsonPropertyName("securityProfile")]
    public SecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("userData")]
    public string? UserData { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }

    [JsonPropertyName("virtualMachineScaleSet")]
    public SubResourceModel? VirtualMachineScaleSet { get; set; }
}
