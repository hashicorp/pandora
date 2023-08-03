// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DomainModel
{
    [JsonPropertyName("authenticationType")]
    public string? AuthenticationType { get; set; }

    [JsonPropertyName("availabilityStatus")]
    public string? AvailabilityStatus { get; set; }

    [JsonPropertyName("domainNameReferences")]
    public List<DirectoryObjectModel>? DomainNameReferences { get; set; }

    [JsonPropertyName("federationConfiguration")]
    public List<InternalDomainFederationModel>? FederationConfiguration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAdminManaged")]
    public bool? IsAdminManaged { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isInitial")]
    public bool? IsInitial { get; set; }

    [JsonPropertyName("isRoot")]
    public bool? IsRoot { get; set; }

    [JsonPropertyName("isVerified")]
    public bool? IsVerified { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordNotificationWindowInDays")]
    public int? PasswordNotificationWindowInDays { get; set; }

    [JsonPropertyName("passwordValidityPeriodInDays")]
    public int? PasswordValidityPeriodInDays { get; set; }

    [JsonPropertyName("serviceConfigurationRecords")]
    public List<DomainDnsRecordModel>? ServiceConfigurationRecords { get; set; }

    [JsonPropertyName("state")]
    public DomainStateModel? State { get; set; }

    [JsonPropertyName("supportedServices")]
    public List<string>? SupportedServices { get; set; }

    [JsonPropertyName("verificationDnsRecords")]
    public List<DomainDnsRecordModel>? VerificationDnsRecords { get; set; }
}
