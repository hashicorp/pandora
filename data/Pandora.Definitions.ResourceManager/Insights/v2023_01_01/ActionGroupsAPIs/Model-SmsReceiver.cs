using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_01_01.ActionGroupsAPIs;


internal class SmsReceiverModel
{
    [JsonPropertyName("countryCode")]
    [Required]
    public string CountryCode { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("phoneNumber")]
    [Required]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("status")]
    public ReceiverStatusConstant? Status { get; set; }
}
