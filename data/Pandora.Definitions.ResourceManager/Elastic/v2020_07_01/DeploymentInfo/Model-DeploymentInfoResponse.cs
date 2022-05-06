using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.DeploymentInfo;


internal class DeploymentInfoResponseModel
{
    [JsonPropertyName("diskCapacity")]
    public string? DiskCapacity { get; set; }

    [JsonPropertyName("memoryCapacity")]
    public string? MemoryCapacity { get; set; }

    [JsonPropertyName("status")]
    public ElasticDeploymentStatusConstant? Status { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
