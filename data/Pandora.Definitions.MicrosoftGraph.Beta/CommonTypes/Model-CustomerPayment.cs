// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CustomerPaymentModel
{
    [JsonPropertyName("amount")]
    public float? Amount { get; set; }

    [JsonPropertyName("appliesToInvoiceId")]
    public string? AppliesToInvoiceId { get; set; }

    [JsonPropertyName("appliesToInvoiceNumber")]
    public string? AppliesToInvoiceNumber { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("contactId")]
    public string? ContactId { get; set; }

    [JsonPropertyName("customer")]
    public CustomerModel? Customer { get; set; }

    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("documentNumber")]
    public string? DocumentNumber { get; set; }

    [JsonPropertyName("externalDocumentNumber")]
    public string? ExternalDocumentNumber { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("journalDisplayName")]
    public string? JournalDisplayName { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lineNumber")]
    public int? LineNumber { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("postingDate")]
    public DateTime? PostingDate { get; set; }
}
