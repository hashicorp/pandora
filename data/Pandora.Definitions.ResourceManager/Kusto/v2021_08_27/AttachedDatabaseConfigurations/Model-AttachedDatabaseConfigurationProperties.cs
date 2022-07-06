using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.AttachedDatabaseConfigurations;


internal class AttachedDatabaseConfigurationPropertiesModel
{
    [JsonPropertyName("attachedDatabaseNames")]
    public List<string>? AttachedDatabaseNames { get; set; }

    [JsonPropertyName("clusterResourceId")]
    [Required]
    public string ClusterResourceId { get; set; }

    [JsonPropertyName("databaseName")]
    [Required]
    public string DatabaseName { get; set; }

    [JsonPropertyName("defaultPrincipalsModificationKind")]
    [Required]
    public DefaultPrincipalsModificationKindConstant DefaultPrincipalsModificationKind { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("tableLevelSharingProperties")]
    public TableLevelSharingPropertiesModel? TableLevelSharingProperties { get; set; }
}
