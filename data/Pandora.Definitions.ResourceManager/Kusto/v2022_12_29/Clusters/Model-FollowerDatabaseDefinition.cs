using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_12_29.Clusters;


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

    [JsonPropertyName("databaseShareOrigin")]
    public DatabaseShareOriginConstant? DatabaseShareOrigin { get; set; }

    [JsonPropertyName("tableLevelSharingProperties")]
    public TableLevelSharingPropertiesModel? TableLevelSharingProperties { get; set; }
}
