using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;


internal class NfsAccessRuleModel
{
    [JsonPropertyName("access")]
    [Required]
    public NfsAccessRuleAccessConstant Access { get; set; }

    [JsonPropertyName("anonymousGID")]
    public string? AnonymousGID { get; set; }

    [JsonPropertyName("anonymousUID")]
    public string? AnonymousUID { get; set; }

    [JsonPropertyName("filter")]
    public string? Filter { get; set; }

    [JsonPropertyName("rootSquash")]
    public bool? RootSquash { get; set; }

    [JsonPropertyName("scope")]
    [Required]
    public NfsAccessRuleScopeConstant Scope { get; set; }

    [JsonPropertyName("submountAccess")]
    public bool? SubmountAccess { get; set; }

    [JsonPropertyName("suid")]
    public bool? Suid { get; set; }
}
