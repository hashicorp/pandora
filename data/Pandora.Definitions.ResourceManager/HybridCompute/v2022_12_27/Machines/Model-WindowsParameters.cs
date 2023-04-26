using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.Machines;


internal class WindowsParametersModel
{
    [JsonPropertyName("classificationsToInclude")]
    public List<VMGuestPatchClassificationWindowsConstant>? ClassificationsToInclude { get; set; }

    [JsonPropertyName("excludeKbsRequiringReboot")]
    public bool? ExcludeKbsRequiringReboot { get; set; }

    [JsonPropertyName("kbNumbersToExclude")]
    public List<string>? KbNumbersToExclude { get; set; }

    [JsonPropertyName("kbNumbersToInclude")]
    public List<string>? KbNumbersToInclude { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("maxPatchPublishDate")]
    public DateTime? MaxPatchPublishDate { get; set; }
}
