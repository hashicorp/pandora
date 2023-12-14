using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class AutoHealTriggersModel
{
    [JsonPropertyName("privateBytesInKB")]
    public int? PrivateBytesInKB { get; set; }

    [JsonPropertyName("requests")]
    public RequestsBasedTriggerModel? Requests { get; set; }

    [JsonPropertyName("slowRequests")]
    public SlowRequestsBasedTriggerModel? SlowRequests { get; set; }

    [JsonPropertyName("slowRequestsWithPath")]
    public List<SlowRequestsBasedTriggerModel>? SlowRequestsWithPath { get; set; }

    [JsonPropertyName("statusCodes")]
    public List<StatusCodesBasedTriggerModel>? StatusCodes { get; set; }

    [JsonPropertyName("statusCodesRange")]
    public List<StatusCodesRangeBasedTriggerModel>? StatusCodesRange { get; set; }
}
