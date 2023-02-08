using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.NodeReports;


internal class DscMetaConfigurationModel
{
    [JsonPropertyName("actionAfterReboot")]
    public string? ActionAfterReboot { get; set; }

    [JsonPropertyName("allowModuleOverwrite")]
    public bool? AllowModuleOverwrite { get; set; }

    [JsonPropertyName("certificateId")]
    public string? CertificateId { get; set; }

    [JsonPropertyName("configurationMode")]
    public string? ConfigurationMode { get; set; }

    [JsonPropertyName("configurationModeFrequencyMins")]
    public int? ConfigurationModeFrequencyMins { get; set; }

    [JsonPropertyName("rebootNodeIfNeeded")]
    public bool? RebootNodeIfNeeded { get; set; }

    [JsonPropertyName("refreshFrequencyMins")]
    public int? RefreshFrequencyMins { get; set; }
}
