using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_02_preview.ManagedClusters;


internal class EndpointDependencyModel
{
    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("endpointDetails")]
    public List<EndpointDetailModel>? EndpointDetails { get; set; }
}
