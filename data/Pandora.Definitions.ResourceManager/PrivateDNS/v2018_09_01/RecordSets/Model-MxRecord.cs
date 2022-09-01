using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.RecordSets;


internal class MxRecordModel
{
    [JsonPropertyName("exchange")]
    public string? Exchange { get; set; }

    [JsonPropertyName("preference")]
    public int? Preference { get; set; }
}
