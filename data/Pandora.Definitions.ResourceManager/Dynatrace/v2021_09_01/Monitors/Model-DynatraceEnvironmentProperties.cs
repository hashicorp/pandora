using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;


internal class DynatraceEnvironmentPropertiesModel
{
    [JsonPropertyName("accountInfo")]
    public AccountInfoModel? AccountInfo { get; set; }

    [JsonPropertyName("environmentInfo")]
    public EnvironmentInfoModel? EnvironmentInfo { get; set; }

    [JsonPropertyName("singleSignOnProperties")]
    public DynatraceSingleSignOnPropertiesModel? SingleSignOnProperties { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
