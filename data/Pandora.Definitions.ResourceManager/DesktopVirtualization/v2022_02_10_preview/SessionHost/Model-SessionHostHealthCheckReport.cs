using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.SessionHost;


internal class SessionHostHealthCheckReportModel
{
    [JsonPropertyName("additionalFailureDetails")]
    public SessionHostHealthCheckFailureDetailsModel? AdditionalFailureDetails { get; set; }

    [JsonPropertyName("healthCheckName")]
    public HealthCheckNameConstant? HealthCheckName { get; set; }

    [JsonPropertyName("healthCheckResult")]
    public HealthCheckResultConstant? HealthCheckResult { get; set; }
}
