using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_12_01.WorkspacePrivateEndpointConnections;


internal class PrivateEndpointConnectionListResultDescriptionModel
{
    [JsonPropertyName("value")]
    public List<PrivateEndpointConnectionDescriptionModel>? Value { get; set; }
}
