using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRules;


internal class SourceAddrModel
{
    [JsonPropertyName("cidrs")]
    public List<string>? Cidrs { get; set; }

    [JsonPropertyName("countries")]
    public List<string>? Countries { get; set; }

    [JsonPropertyName("feeds")]
    public List<string>? Feeds { get; set; }

    [JsonPropertyName("prefixLists")]
    public List<string>? PrefixLists { get; set; }
}
