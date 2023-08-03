// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceModel
{
    [JsonPropertyName("accountEnabled")]
    public bool? AccountEnabled { get; set; }

    [JsonPropertyName("alternativeSecurityIds")]
    public List<AlternativeSecurityIdModel>? AlternativeSecurityIds { get; set; }

    [JsonPropertyName("approximateLastSignInDateTime")]
    public DateTime? ApproximateLastSignInDateTime { get; set; }

    [JsonPropertyName("commands")]
    public List<CommandModel>? Commands { get; set; }

    [JsonPropertyName("complianceExpirationDateTime")]
    public DateTime? ComplianceExpirationDateTime { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("deviceCategory")]
    public string? DeviceCategory { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceMetadata")]
    public string? DeviceMetadata { get; set; }

    [JsonPropertyName("deviceOwnership")]
    public string? DeviceOwnership { get; set; }

    [JsonPropertyName("deviceVersion")]
    public int? DeviceVersion { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("enrollmentProfileName")]
    public string? EnrollmentProfileName { get; set; }

    [JsonPropertyName("enrollmentType")]
    public string? EnrollmentType { get; set; }

    [JsonPropertyName("extensionAttributes")]
    public OnPremisesExtensionAttributesModel? ExtensionAttributes { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("hostnames")]
    public List<string>? Hostnames { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isCompliant")]
    public bool? IsCompliant { get; set; }

    [JsonPropertyName("isManaged")]
    public bool? IsManaged { get; set; }

    [JsonPropertyName("isManagementRestricted")]
    public bool? IsManagementRestricted { get; set; }

    [JsonPropertyName("isRooted")]
    public bool? IsRooted { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("managementType")]
    public string? ManagementType { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("mdmAppId")]
    public string? MdmAppId { get; set; }

    [JsonPropertyName("memberOf")]
    public List<DirectoryObjectModel>? MemberOf { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesLastSyncDateTime")]
    public DateTime? OnPremisesLastSyncDateTime { get; set; }

    [JsonPropertyName("onPremisesSyncEnabled")]
    public bool? OnPremisesSyncEnabled { get; set; }

    [JsonPropertyName("operatingSystem")]
    public string? OperatingSystem { get; set; }

    [JsonPropertyName("operatingSystemVersion")]
    public string? OperatingSystemVersion { get; set; }

    [JsonPropertyName("physicalIds")]
    public List<string>? PhysicalIds { get; set; }

    [JsonPropertyName("platform")]
    public string? Platform { get; set; }

    [JsonPropertyName("profileType")]
    public string? ProfileType { get; set; }

    [JsonPropertyName("registeredOwners")]
    public List<DirectoryObjectModel>? RegisteredOwners { get; set; }

    [JsonPropertyName("registeredUsers")]
    public List<DirectoryObjectModel>? RegisteredUsers { get; set; }

    [JsonPropertyName("registrationDateTime")]
    public DateTime? RegistrationDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("systemLabels")]
    public List<string>? SystemLabels { get; set; }

    [JsonPropertyName("transitiveMemberOf")]
    public List<DirectoryObjectModel>? TransitiveMemberOf { get; set; }

    [JsonPropertyName("trustType")]
    public string? TrustType { get; set; }

    [JsonPropertyName("usageRights")]
    public List<UsageRightModel>? UsageRights { get; set; }
}
