using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.MaintenanceConfigurations;


internal class MaintenanceWindowModel
{
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public string? ExpirationDateTime { get; set; }

    [JsonPropertyName("recurEvery")]
    public string? RecurEvery { get; set; }

    [JsonPropertyName("startDateTime")]
    public string? StartDateTime { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
