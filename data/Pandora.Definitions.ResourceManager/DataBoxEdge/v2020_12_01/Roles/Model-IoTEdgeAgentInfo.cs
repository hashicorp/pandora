using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Roles;


internal class IoTEdgeAgentInfoModel
{
    [JsonPropertyName("imageName")]
    [Required]
    public string ImageName { get; set; }

    [JsonPropertyName("imageRepository")]
    public ImageRepositoryCredentialModel? ImageRepository { get; set; }

    [JsonPropertyName("tag")]
    [Required]
    public string Tag { get; set; }
}
