// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class OrgContactModel
{
    [JsonPropertyName("addresses")]
    public List<PhysicalOfficeAddressModel>? Addresses { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("directReports")]
    public List<DirectoryObjectModel>? DirectReports { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("jobTitle")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("mail")]
    public string? Mail { get; set; }

    [JsonPropertyName("mailNickname")]
    public string? MailNickname { get; set; }

    [JsonPropertyName("manager")]
    public DirectoryObjectModel? Manager { get; set; }

    [JsonPropertyName("memberOf")]
    public List<DirectoryObjectModel>? MemberOf { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesLastSyncDateTime")]
    public DateTime? OnPremisesLastSyncDateTime { get; set; }

    [JsonPropertyName("onPremisesProvisioningErrors")]
    public List<OnPremisesProvisioningErrorModel>? OnPremisesProvisioningErrors { get; set; }

    [JsonPropertyName("onPremisesSyncEnabled")]
    public bool? OnPremisesSyncEnabled { get; set; }

    [JsonPropertyName("phones")]
    public List<PhoneModel>? Phones { get; set; }

    [JsonPropertyName("proxyAddresses")]
    public List<string>? ProxyAddresses { get; set; }

    [JsonPropertyName("serviceProvisioningErrors")]
    public List<ServiceProvisioningErrorModel>? ServiceProvisioningErrors { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("transitiveMemberOf")]
    public List<DirectoryObjectModel>? TransitiveMemberOf { get; set; }
}
