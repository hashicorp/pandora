using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;

[ValueForType("Package")]
internal class SsisPackageModel : SsisObjectMetadataModel
{
    [JsonPropertyName("folderId")]
    public int? FolderId { get; set; }

    [JsonPropertyName("parameters")]
    public List<SsisParameterModel>? Parameters { get; set; }

    [JsonPropertyName("projectId")]
    public int? ProjectId { get; set; }

    [JsonPropertyName("projectVersion")]
    public int? ProjectVersion { get; set; }
}
