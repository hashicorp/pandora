using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ExternalSecuritySolutions;


internal class CefSolutionPropertiesModel
{
    [JsonPropertyName("agent")]
    public string? Agent { get; set; }

    [JsonPropertyName("deviceType")]
    public string? DeviceType { get; set; }

    [JsonPropertyName("deviceVendor")]
    public string? DeviceVendor { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("lastEventReceived")]
    public string? LastEventReceived { get; set; }

    [JsonPropertyName("workspace")]
    public ConnectedWorkspaceModel? Workspace { get; set; }
}
