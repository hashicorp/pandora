using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceCertificateOrders;


internal class AppServiceCertificateOrderPatchResourcePropertiesModel
{
    [JsonPropertyName("appServiceCertificateNotRenewableReasons")]
    public List<ResourceNotRenewableReasonConstant>? AppServiceCertificateNotRenewableReasons { get; set; }

    [JsonPropertyName("autoRenew")]
    public bool? AutoRenew { get; set; }

    [JsonPropertyName("certificates")]
    public Dictionary<string, AppServiceCertificateModel>? Certificates { get; set; }

    [JsonPropertyName("contact")]
    public CertificateOrderContactModel? Contact { get; set; }

    [JsonPropertyName("csr")]
    public string? Csr { get; set; }

    [JsonPropertyName("distinguishedName")]
    public string? DistinguishedName { get; set; }

    [JsonPropertyName("domainVerificationToken")]
    public string? DomainVerificationToken { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTime")]
    public DateTime? ExpirationTime { get; set; }

    [JsonPropertyName("intermediate")]
    public CertificateDetailsModel? Intermediate { get; set; }

    [JsonPropertyName("isPrivateKeyExternal")]
    public bool? IsPrivateKeyExternal { get; set; }

    [JsonPropertyName("keySize")]
    public int? KeySize { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCertificateIssuanceTime")]
    public DateTime? LastCertificateIssuanceTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextAutoRenewalTimeStamp")]
    public DateTime? NextAutoRenewalTimeStamp { get; set; }

    [JsonPropertyName("productType")]
    [Required]
    public CertificateProductTypeConstant ProductType { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("root")]
    public CertificateDetailsModel? Root { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("signedCertificate")]
    public CertificateDetailsModel? SignedCertificate { get; set; }

    [JsonPropertyName("status")]
    public CertificateOrderStatusConstant? Status { get; set; }

    [JsonPropertyName("validityInYears")]
    public int? ValidityInYears { get; set; }
}
