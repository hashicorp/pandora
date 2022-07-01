using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_03_01.ContainerInstance;


internal class ContainerExecRequestTerminalSizeModel
{
    [JsonPropertyName("cols")]
    public int? Cols { get; set; }

    [JsonPropertyName("rows")]
    public int? Rows { get; set; }
}
