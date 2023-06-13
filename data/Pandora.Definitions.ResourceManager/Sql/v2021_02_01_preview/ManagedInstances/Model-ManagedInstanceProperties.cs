using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;


internal class ManagedInstancePropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("administrators")]
    public ManagedInstanceExternalAdministratorModel? Administrators { get; set; }

    [JsonPropertyName("collation")]
    public string? Collation { get; set; }

    [JsonPropertyName("dnsZone")]
    public string? DnsZone { get; set; }

    [JsonPropertyName("dnsZonePartner")]
    public string? DnsZonePartner { get; set; }

    [JsonPropertyName("fullyQualifiedDomainName")]
    public string? FullyQualifiedDomainName { get; set; }

    [JsonPropertyName("instancePoolId")]
    public string? InstancePoolId { get; set; }

    [JsonPropertyName("keyId")]
    public string? KeyId { get; set; }

    [JsonPropertyName("licenseType")]
    public ManagedInstanceLicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("maintenanceConfigurationId")]
    public string? MaintenanceConfigurationId { get; set; }

    [JsonPropertyName("managedInstanceCreateMode")]
    public ManagedServerCreateModeConstant? ManagedInstanceCreateMode { get; set; }

    [JsonPropertyName("minimalTlsVersion")]
    public string? MinimalTlsVersion { get; set; }

    [JsonPropertyName("primaryUserAssignedIdentityId")]
    public string? PrimaryUserAssignedIdentityId { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<ManagedInstancePecPropertyModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("proxyOverride")]
    public ManagedInstanceProxyOverrideConstant? ProxyOverride { get; set; }

    [JsonPropertyName("publicDataEndpointEnabled")]
    public bool? PublicDataEndpointEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restorePointInTime")]
    public DateTime? RestorePointInTime { get; set; }

    [JsonPropertyName("sourceManagedInstanceId")]
    public string? SourceManagedInstanceId { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("storageAccountType")]
    public StorageAccountTypeConstant? StorageAccountType { get; set; }

    [JsonPropertyName("storageSizeInGB")]
    public int? StorageSizeInGB { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("timezoneId")]
    public string? TimezoneId { get; set; }

    [JsonPropertyName("vCores")]
    public int? VCores { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
