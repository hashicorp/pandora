using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Servicelinker;


internal abstract class TargetServiceBaseModel
{
    [JsonPropertyName("type")]
    [ProvidesTypeHint]
    [Required]
    public TargetServiceTypeConstant Type { get; set; }
}
