// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class HardwareInformationModel
{
    [JsonPropertyName("batteryChargeCycles")]
    public int? BatteryChargeCycles { get; set; }

    [JsonPropertyName("batteryHealthPercentage")]
    public int? BatteryHealthPercentage { get; set; }

    [JsonPropertyName("batterySerialNumber")]
    public string? BatterySerialNumber { get; set; }

    [JsonPropertyName("cellularTechnology")]
    public string? CellularTechnology { get; set; }

    [JsonPropertyName("deviceFullQualifiedDomainName")]
    public string? DeviceFullQualifiedDomainName { get; set; }

    [JsonPropertyName("deviceGuardLocalSystemAuthorityCredentialGuardState")]
    public HardwareInformationDeviceGuardLocalSystemAuthorityCredentialGuardStateConstant? DeviceGuardLocalSystemAuthorityCredentialGuardState { get; set; }

    [JsonPropertyName("deviceGuardVirtualizationBasedSecurityHardwareRequirementState")]
    public HardwareInformationDeviceGuardVirtualizationBasedSecurityHardwareRequirementStateConstant? DeviceGuardVirtualizationBasedSecurityHardwareRequirementState { get; set; }

    [JsonPropertyName("deviceGuardVirtualizationBasedSecurityState")]
    public HardwareInformationDeviceGuardVirtualizationBasedSecurityStateConstant? DeviceGuardVirtualizationBasedSecurityState { get; set; }

    [JsonPropertyName("deviceLicensingLastErrorCode")]
    public int? DeviceLicensingLastErrorCode { get; set; }

    [JsonPropertyName("deviceLicensingLastErrorDescription")]
    public string? DeviceLicensingLastErrorDescription { get; set; }

    [JsonPropertyName("deviceLicensingStatus")]
    public HardwareInformationDeviceLicensingStatusConstant? DeviceLicensingStatus { get; set; }

    [JsonPropertyName("esimIdentifier")]
    public string? EsimIdentifier { get; set; }

    [JsonPropertyName("freeStorageSpace")]
    public int? FreeStorageSpace { get; set; }

    [JsonPropertyName("imei")]
    public string? Imei { get; set; }

    [JsonPropertyName("ipAddressV4")]
    public string? IpAddressV4 { get; set; }

    [JsonPropertyName("isEncrypted")]
    public bool? IsEncrypted { get; set; }

    [JsonPropertyName("isSharedDevice")]
    public bool? IsSharedDevice { get; set; }

    [JsonPropertyName("isSupervised")]
    public bool? IsSupervised { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("meid")]
    public string? Meid { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystemEdition")]
    public string? OperatingSystemEdition { get; set; }

    [JsonPropertyName("operatingSystemLanguage")]
    public string? OperatingSystemLanguage { get; set; }

    [JsonPropertyName("operatingSystemProductType")]
    public int? OperatingSystemProductType { get; set; }

    [JsonPropertyName("osBuildNumber")]
    public string? OsBuildNumber { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("residentUsersCount")]
    public int? ResidentUsersCount { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("sharedDeviceCachedUsers")]
    public List<SharedAppleDeviceUserModel>? SharedDeviceCachedUsers { get; set; }

    [JsonPropertyName("subnetAddress")]
    public string? SubnetAddress { get; set; }

    [JsonPropertyName("subscriberCarrier")]
    public string? SubscriberCarrier { get; set; }

    [JsonPropertyName("systemManagementBIOSVersion")]
    public string? SystemManagementBIOSVersion { get; set; }

    [JsonPropertyName("totalStorageSpace")]
    public int? TotalStorageSpace { get; set; }

    [JsonPropertyName("tpmManufacturer")]
    public string? TpmManufacturer { get; set; }

    [JsonPropertyName("tpmSpecificationVersion")]
    public string? TpmSpecificationVersion { get; set; }

    [JsonPropertyName("tpmVersion")]
    public string? TpmVersion { get; set; }

    [JsonPropertyName("wifiMac")]
    public string? WifiMac { get; set; }

    [JsonPropertyName("wiredIPv4Addresses")]
    public List<string>? WiredIPv4Addresses { get; set; }
}
