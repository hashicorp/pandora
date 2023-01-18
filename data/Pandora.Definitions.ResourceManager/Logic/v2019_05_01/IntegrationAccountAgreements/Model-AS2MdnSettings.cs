using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AS2MdnSettingsModel
{
    [JsonPropertyName("dispositionNotificationTo")]
    public string? DispositionNotificationTo { get; set; }

    [JsonPropertyName("mdnText")]
    public string? MdnText { get; set; }

    [JsonPropertyName("micHashingAlgorithm")]
    [Required]
    public HashingAlgorithmConstant MicHashingAlgorithm { get; set; }

    [JsonPropertyName("needMDN")]
    [Required]
    public bool NeedMDN { get; set; }

    [JsonPropertyName("receiptDeliveryUrl")]
    public string? ReceiptDeliveryUrl { get; set; }

    [JsonPropertyName("sendInboundMDNToMessageBox")]
    [Required]
    public bool SendInboundMDNToMessageBox { get; set; }

    [JsonPropertyName("sendMDNAsynchronously")]
    [Required]
    public bool SendMDNAsynchronously { get; set; }

    [JsonPropertyName("signMDN")]
    [Required]
    public bool SignMDN { get; set; }

    [JsonPropertyName("signOutboundMDNIfOptional")]
    [Required]
    public bool SignOutboundMDNIfOptional { get; set; }
}
