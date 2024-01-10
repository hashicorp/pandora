using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2023_04_01.NginxDeployment;


internal class NginxDeploymentUpdatePropertiesModel
{
    [JsonPropertyName("enableDiagnosticsSupport")]
    public bool? EnableDiagnosticsSupport { get; set; }

    [JsonPropertyName("logging")]
    public NginxLoggingModel? Logging { get; set; }

    [JsonPropertyName("scalingProperties")]
    public NginxDeploymentScalingPropertiesModel? ScalingProperties { get; set; }

    [JsonPropertyName("userProfile")]
    public NginxDeploymentUserProfileModel? UserProfile { get; set; }
}
