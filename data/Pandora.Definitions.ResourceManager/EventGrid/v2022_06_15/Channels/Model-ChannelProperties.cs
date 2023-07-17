using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Channels;


internal class ChannelPropertiesModel
{
    [JsonPropertyName("channelType")]
    public ChannelTypeConstant? ChannelType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTimeIfNotActivatedUtc")]
    public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

    [JsonPropertyName("messageForActivation")]
    public string? MessageForActivation { get; set; }

    [JsonPropertyName("partnerTopicInfo")]
    public PartnerTopicInfoModel? PartnerTopicInfo { get; set; }

    [JsonPropertyName("provisioningState")]
    public ChannelProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("readinessState")]
    public ReadinessStateConstant? ReadinessState { get; set; }
}
