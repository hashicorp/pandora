using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Domains;


internal class DomainPropertiesModel
{
    [JsonPropertyName("authCode")]
    public string? AuthCode { get; set; }

    [JsonPropertyName("autoRenew")]
    public bool? AutoRenew { get; set; }

    [JsonPropertyName("consent")]
    [Required]
    public DomainPurchaseConsentModel Consent { get; set; }

    [JsonPropertyName("contactAdmin")]
    [Required]
    public ContactModel ContactAdmin { get; set; }

    [JsonPropertyName("contactBilling")]
    [Required]
    public ContactModel ContactBilling { get; set; }

    [JsonPropertyName("contactRegistrant")]
    [Required]
    public ContactModel ContactRegistrant { get; set; }

    [JsonPropertyName("contactTech")]
    [Required]
    public ContactModel ContactTech { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("dnsType")]
    public DnsTypeConstant? DnsType { get; set; }

    [JsonPropertyName("dnsZoneId")]
    public string? DnsZoneId { get; set; }

    [JsonPropertyName("domainNotRenewableReasons")]
    public List<ResourceNotRenewableReasonConstant>? DomainNotRenewableReasons { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTime")]
    public DateTime? ExpirationTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRenewedTime")]
    public DateTime? LastRenewedTime { get; set; }

    [JsonPropertyName("managedHostNames")]
    public List<HostNameModel>? ManagedHostNames { get; set; }

    [JsonPropertyName("nameServers")]
    public List<string>? NameServers { get; set; }

    [JsonPropertyName("privacy")]
    public bool? Privacy { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("readyForDnsRecordManagement")]
    public bool? ReadyForDnsRecordManagement { get; set; }

    [JsonPropertyName("registrationStatus")]
    public DomainStatusConstant? RegistrationStatus { get; set; }

    [JsonPropertyName("targetDnsType")]
    public DnsTypeConstant? TargetDnsType { get; set; }
}
