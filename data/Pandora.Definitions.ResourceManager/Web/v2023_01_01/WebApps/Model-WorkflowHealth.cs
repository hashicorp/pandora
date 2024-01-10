using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class WorkflowHealthModel
{
    [JsonPropertyName("error")]
    public ErrorEntityModel? Error { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public WorkflowHealthStateConstant State { get; set; }
}
