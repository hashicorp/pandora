using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.ApplicationInsights;


internal class WorkbookUpdateParametersModel
{
    [JsonPropertyName("kind")]
    public WorkbookUpdateSharedTypeKindConstant? Kind { get; set; }

    [JsonPropertyName("properties")]
    public WorkbookPropertiesUpdateParametersModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
