using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRulestacks;


internal class SupportInfoModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("accountRegistered")]
    public BooleanEnumConstant? AccountRegistered { get; set; }

    [JsonPropertyName("freeTrial")]
    public BooleanEnumConstant? FreeTrial { get; set; }

    [JsonPropertyName("freeTrialCreditLeft")]
    public int? FreeTrialCreditLeft { get; set; }

    [JsonPropertyName("freeTrialDaysLeft")]
    public int? FreeTrialDaysLeft { get; set; }

    [JsonPropertyName("helpURL")]
    public string? HelpURL { get; set; }

    [JsonPropertyName("productSerial")]
    public string? ProductSerial { get; set; }

    [JsonPropertyName("productSku")]
    public string? ProductSku { get; set; }

    [JsonPropertyName("registerURL")]
    public string? RegisterURL { get; set; }

    [JsonPropertyName("supportURL")]
    public string? SupportURL { get; set; }

    [JsonPropertyName("userDomainSupported")]
    public BooleanEnumConstant? UserDomainSupported { get; set; }

    [JsonPropertyName("userRegistered")]
    public BooleanEnumConstant? UserRegistered { get; set; }
}
