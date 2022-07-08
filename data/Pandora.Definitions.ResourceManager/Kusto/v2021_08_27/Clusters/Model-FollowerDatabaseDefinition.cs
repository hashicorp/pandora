using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.Clusters;


internal class FollowerDatabaseDefinitionModel
{
    [JsonPropertyName("attachedDatabaseConfigurationName")]
    [Required]
    public string AttachedDatabaseConfigurationName { get; set; }

    [JsonPropertyName("clusterResourceId")]
    [Required]
    public string ClusterResourceId { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }
}
