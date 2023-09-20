// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsAssignedAccessProfileModel
{
    [JsonPropertyName("appUserModelIds")]
    public List<string>? AppUserModelIds { get; set; }

    [JsonPropertyName("desktopAppPaths")]
    public List<string>? DesktopAppPaths { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("profileName")]
    public string? ProfileName { get; set; }

    [JsonPropertyName("showTaskBar")]
    public bool? ShowTaskBar { get; set; }

    [JsonPropertyName("startMenuLayoutXml")]
    public string? StartMenuLayoutXml { get; set; }

    [JsonPropertyName("userAccounts")]
    public List<string>? UserAccounts { get; set; }
}
