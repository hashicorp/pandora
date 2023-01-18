using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactEnvelopeOverrideModel
{
    [JsonPropertyName("applicationPassword")]
    public string? ApplicationPassword { get; set; }

    [JsonPropertyName("associationAssignedCode")]
    public string? AssociationAssignedCode { get; set; }

    [JsonPropertyName("controllingAgencyCode")]
    public string? ControllingAgencyCode { get; set; }

    [JsonPropertyName("functionalGroupId")]
    public string? FunctionalGroupId { get; set; }

    [JsonPropertyName("groupHeaderMessageRelease")]
    public string? GroupHeaderMessageRelease { get; set; }

    [JsonPropertyName("groupHeaderMessageVersion")]
    public string? GroupHeaderMessageVersion { get; set; }

    [JsonPropertyName("messageAssociationAssignedCode")]
    public string? MessageAssociationAssignedCode { get; set; }

    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    [JsonPropertyName("messageRelease")]
    public string? MessageRelease { get; set; }

    [JsonPropertyName("messageVersion")]
    public string? MessageVersion { get; set; }

    [JsonPropertyName("receiverApplicationId")]
    public string? ReceiverApplicationId { get; set; }

    [JsonPropertyName("receiverApplicationQualifier")]
    public string? ReceiverApplicationQualifier { get; set; }

    [JsonPropertyName("senderApplicationId")]
    public string? SenderApplicationId { get; set; }

    [JsonPropertyName("senderApplicationQualifier")]
    public string? SenderApplicationQualifier { get; set; }

    [JsonPropertyName("targetNamespace")]
    public string? TargetNamespace { get; set; }
}
