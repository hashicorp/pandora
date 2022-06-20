using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.MachineLearningComputes;


internal class SslConfigurationModel
{
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    [JsonPropertyName("cname")]
    public string? Cname { get; set; }

    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("leafDomainLabel")]
    public string? LeafDomainLabel { get; set; }

    [JsonPropertyName("overwriteExistingDomain")]
    public bool? OverwriteExistingDomain { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }
}
