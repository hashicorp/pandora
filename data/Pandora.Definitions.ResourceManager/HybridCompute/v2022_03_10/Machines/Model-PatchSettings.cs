using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.Machines;


internal class PatchSettingsModel
{
    [JsonPropertyName("assessmentMode")]
    public AssessmentModeTypesConstant? AssessmentMode { get; set; }

    [JsonPropertyName("patchMode")]
    public PatchModeTypesConstant? PatchMode { get; set; }
}
