using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12EnvelopeOverrideModel
{
    [JsonPropertyName("dateFormat")]
    [Required]
    public X12DateFormatConstant DateFormat { get; set; }

    [JsonPropertyName("functionalIdentifierCode")]
    public string? FunctionalIdentifierCode { get; set; }

    [JsonPropertyName("headerVersion")]
    [Required]
    public string HeaderVersion { get; set; }

    [JsonPropertyName("messageId")]
    [Required]
    public string MessageId { get; set; }

    [JsonPropertyName("protocolVersion")]
    [Required]
    public string ProtocolVersion { get; set; }

    [JsonPropertyName("receiverApplicationId")]
    [Required]
    public string ReceiverApplicationId { get; set; }

    [JsonPropertyName("responsibleAgencyCode")]
    [Required]
    public string ResponsibleAgencyCode { get; set; }

    [JsonPropertyName("senderApplicationId")]
    [Required]
    public string SenderApplicationId { get; set; }

    [JsonPropertyName("targetNamespace")]
    [Required]
    public string TargetNamespace { get; set; }

    [JsonPropertyName("timeFormat")]
    [Required]
    public X12TimeFormatConstant TimeFormat { get; set; }
}
