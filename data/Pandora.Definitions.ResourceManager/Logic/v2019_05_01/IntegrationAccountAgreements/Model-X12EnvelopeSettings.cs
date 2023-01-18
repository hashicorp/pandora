using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12EnvelopeSettingsModel
{
    [JsonPropertyName("controlStandardsId")]
    [Required]
    public int ControlStandardsId { get; set; }

    [JsonPropertyName("controlVersionNumber")]
    [Required]
    public string ControlVersionNumber { get; set; }

    [JsonPropertyName("enableDefaultGroupHeaders")]
    [Required]
    public bool EnableDefaultGroupHeaders { get; set; }

    [JsonPropertyName("functionalGroupId")]
    public string? FunctionalGroupId { get; set; }

    [JsonPropertyName("groupControlNumberLowerBound")]
    [Required]
    public int GroupControlNumberLowerBound { get; set; }

    [JsonPropertyName("groupControlNumberUpperBound")]
    [Required]
    public int GroupControlNumberUpperBound { get; set; }

    [JsonPropertyName("groupHeaderAgencyCode")]
    [Required]
    public string GroupHeaderAgencyCode { get; set; }

    [JsonPropertyName("groupHeaderDateFormat")]
    [Required]
    public X12DateFormatConstant GroupHeaderDateFormat { get; set; }

    [JsonPropertyName("groupHeaderTimeFormat")]
    [Required]
    public X12TimeFormatConstant GroupHeaderTimeFormat { get; set; }

    [JsonPropertyName("groupHeaderVersion")]
    [Required]
    public string GroupHeaderVersion { get; set; }

    [JsonPropertyName("interchangeControlNumberLowerBound")]
    [Required]
    public int InterchangeControlNumberLowerBound { get; set; }

    [JsonPropertyName("interchangeControlNumberUpperBound")]
    [Required]
    public int InterchangeControlNumberUpperBound { get; set; }

    [JsonPropertyName("overwriteExistingTransactionSetControlNumber")]
    [Required]
    public bool OverwriteExistingTransactionSetControlNumber { get; set; }

    [JsonPropertyName("receiverApplicationId")]
    [Required]
    public string ReceiverApplicationId { get; set; }

    [JsonPropertyName("rolloverGroupControlNumber")]
    [Required]
    public bool RolloverGroupControlNumber { get; set; }

    [JsonPropertyName("rolloverInterchangeControlNumber")]
    [Required]
    public bool RolloverInterchangeControlNumber { get; set; }

    [JsonPropertyName("rolloverTransactionSetControlNumber")]
    [Required]
    public bool RolloverTransactionSetControlNumber { get; set; }

    [JsonPropertyName("senderApplicationId")]
    [Required]
    public string SenderApplicationId { get; set; }

    [JsonPropertyName("transactionSetControlNumberLowerBound")]
    [Required]
    public int TransactionSetControlNumberLowerBound { get; set; }

    [JsonPropertyName("transactionSetControlNumberPrefix")]
    public string? TransactionSetControlNumberPrefix { get; set; }

    [JsonPropertyName("transactionSetControlNumberSuffix")]
    public string? TransactionSetControlNumberSuffix { get; set; }

    [JsonPropertyName("transactionSetControlNumberUpperBound")]
    [Required]
    public int TransactionSetControlNumberUpperBound { get; set; }

    [JsonPropertyName("usageIndicator")]
    [Required]
    public UsageIndicatorConstant UsageIndicator { get; set; }

    [JsonPropertyName("useControlStandardsIdAsRepetitionCharacter")]
    [Required]
    public bool UseControlStandardsIdAsRepetitionCharacter { get; set; }
}
