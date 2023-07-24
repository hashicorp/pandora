using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class SiteLogsConfigPropertiesModel
{
    [JsonPropertyName("applicationLogs")]
    public ApplicationLogsConfigModel? ApplicationLogs { get; set; }

    [JsonPropertyName("detailedErrorMessages")]
    public EnabledConfigModel? DetailedErrorMessages { get; set; }

    [JsonPropertyName("failedRequestsTracing")]
    public EnabledConfigModel? FailedRequestsTracing { get; set; }

    [JsonPropertyName("httpLogs")]
    public HTTPLogsConfigModel? HTTPLogs { get; set; }
}
