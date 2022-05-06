using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;


internal class ElasticCloudUserModel
{
    [JsonPropertyName("elasticCloudSsoDefaultUrl")]
    public string? ElasticCloudSsoDefaultUrl { get; set; }

    [JsonPropertyName("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }
}
