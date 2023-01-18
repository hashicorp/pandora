using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactEnvelopeSettingsModel
{
    [JsonPropertyName("applicationReferenceId")]
    public string? ApplicationReferenceId { get; set; }

    [JsonPropertyName("applyDelimiterStringAdvice")]
    [Required]
    public bool ApplyDelimiterStringAdvice { get; set; }

    [JsonPropertyName("communicationAgreementId")]
    public string? CommunicationAgreementId { get; set; }

    [JsonPropertyName("createGroupingSegments")]
    [Required]
    public bool CreateGroupingSegments { get; set; }

    [JsonPropertyName("enableDefaultGroupHeaders")]
    [Required]
    public bool EnableDefaultGroupHeaders { get; set; }

    [JsonPropertyName("functionalGroupId")]
    public string? FunctionalGroupId { get; set; }

    [JsonPropertyName("groupApplicationPassword")]
    public string? GroupApplicationPassword { get; set; }

    [JsonPropertyName("groupApplicationReceiverId")]
    public string? GroupApplicationReceiverId { get; set; }

    [JsonPropertyName("groupApplicationReceiverQualifier")]
    public string? GroupApplicationReceiverQualifier { get; set; }

    [JsonPropertyName("groupApplicationSenderId")]
    public string? GroupApplicationSenderId { get; set; }

    [JsonPropertyName("groupApplicationSenderQualifier")]
    public string? GroupApplicationSenderQualifier { get; set; }

    [JsonPropertyName("groupAssociationAssignedCode")]
    public string? GroupAssociationAssignedCode { get; set; }

    [JsonPropertyName("groupControlNumberLowerBound")]
    [Required]
    public int GroupControlNumberLowerBound { get; set; }

    [JsonPropertyName("groupControlNumberPrefix")]
    public string? GroupControlNumberPrefix { get; set; }

    [JsonPropertyName("groupControlNumberSuffix")]
    public string? GroupControlNumberSuffix { get; set; }

    [JsonPropertyName("groupControlNumberUpperBound")]
    [Required]
    public int GroupControlNumberUpperBound { get; set; }

    [JsonPropertyName("groupControllingAgencyCode")]
    public string? GroupControllingAgencyCode { get; set; }

    [JsonPropertyName("groupMessageRelease")]
    public string? GroupMessageRelease { get; set; }

    [JsonPropertyName("groupMessageVersion")]
    public string? GroupMessageVersion { get; set; }

    [JsonPropertyName("interchangeControlNumberLowerBound")]
    [Required]
    public int InterchangeControlNumberLowerBound { get; set; }

    [JsonPropertyName("interchangeControlNumberPrefix")]
    public string? InterchangeControlNumberPrefix { get; set; }

    [JsonPropertyName("interchangeControlNumberSuffix")]
    public string? InterchangeControlNumberSuffix { get; set; }

    [JsonPropertyName("interchangeControlNumberUpperBound")]
    [Required]
    public int InterchangeControlNumberUpperBound { get; set; }

    [JsonPropertyName("isTestInterchange")]
    [Required]
    public bool IsTestInterchange { get; set; }

    [JsonPropertyName("overwriteExistingTransactionSetControlNumber")]
    [Required]
    public bool OverwriteExistingTransactionSetControlNumber { get; set; }

    [JsonPropertyName("processingPriorityCode")]
    public string? ProcessingPriorityCode { get; set; }

    [JsonPropertyName("receiverInternalIdentification")]
    public string? ReceiverInternalIdentification { get; set; }

    [JsonPropertyName("receiverInternalSubIdentification")]
    public string? ReceiverInternalSubIdentification { get; set; }

    [JsonPropertyName("receiverReverseRoutingAddress")]
    public string? ReceiverReverseRoutingAddress { get; set; }

    [JsonPropertyName("recipientReferencePasswordQualifier")]
    public string? RecipientReferencePasswordQualifier { get; set; }

    [JsonPropertyName("recipientReferencePasswordValue")]
    public string? RecipientReferencePasswordValue { get; set; }

    [JsonPropertyName("rolloverGroupControlNumber")]
    [Required]
    public bool RolloverGroupControlNumber { get; set; }

    [JsonPropertyName("rolloverInterchangeControlNumber")]
    [Required]
    public bool RolloverInterchangeControlNumber { get; set; }

    [JsonPropertyName("rolloverTransactionSetControlNumber")]
    [Required]
    public bool RolloverTransactionSetControlNumber { get; set; }

    [JsonPropertyName("senderInternalIdentification")]
    public string? SenderInternalIdentification { get; set; }

    [JsonPropertyName("senderInternalSubIdentification")]
    public string? SenderInternalSubIdentification { get; set; }

    [JsonPropertyName("senderReverseRoutingAddress")]
    public string? SenderReverseRoutingAddress { get; set; }

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
}
