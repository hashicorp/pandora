// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VendorModel
{
    [JsonPropertyName("address")]
    public PostalAddressTypeModel? Address { get; set; }

    [JsonPropertyName("balance")]
    public float? Balance { get; set; }

    [JsonPropertyName("blocked")]
    public string? Blocked { get; set; }

    [JsonPropertyName("currency")]
    public CurrencyModel? Currency { get; set; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("currencyId")]
    public string? CurrencyId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("paymentMethod")]
    public PaymentMethodModel? PaymentMethod { get; set; }

    [JsonPropertyName("paymentMethodId")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("paymentTerm")]
    public PaymentTermModel? PaymentTerm { get; set; }

    [JsonPropertyName("paymentTermsId")]
    public string? PaymentTermsId { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("picture")]
    public List<PictureModel>? Picture { get; set; }

    [JsonPropertyName("taxLiable")]
    public bool? TaxLiable { get; set; }

    [JsonPropertyName("taxRegistrationNumber")]
    public string? TaxRegistrationNumber { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
}
