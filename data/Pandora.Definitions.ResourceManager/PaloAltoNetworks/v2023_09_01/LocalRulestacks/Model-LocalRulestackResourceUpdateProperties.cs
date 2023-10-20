using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRulestacks;


internal class LocalRulestackResourceUpdatePropertiesModel
{
    [JsonPropertyName("associatedSubscriptions")]
    public List<string>? AssociatedSubscriptions { get; set; }

    [JsonPropertyName("defaultMode")]
    public DefaultModeConstant? DefaultMode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("minAppIdVersion")]
    public string? MinAppIdVersion { get; set; }

    [JsonPropertyName("panEtag")]
    public string? PanEtag { get; set; }

    [JsonPropertyName("panLocation")]
    public string? PanLocation { get; set; }

    [JsonPropertyName("scope")]
    public ScopeTypeConstant? Scope { get; set; }

    [JsonPropertyName("securityServices")]
    public SecurityServicesModel? SecurityServices { get; set; }
}
