using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedhatOpenShift.v2022_09_04.OpenShiftClusters;


internal class ConsoleProfileModel
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
