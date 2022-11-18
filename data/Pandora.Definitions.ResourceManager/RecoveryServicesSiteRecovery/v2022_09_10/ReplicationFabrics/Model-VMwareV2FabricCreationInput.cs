using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationFabrics;

[ValueForType("VMwareV2")]
internal class VMwareV2FabricCreationInputModel : FabricSpecificCreationInputModel
{
    [JsonPropertyName("migrationSolutionId")]
    [Required]
    public string MigrationSolutionId { get; set; }

    [JsonPropertyName("physicalSiteId")]
    public string? PhysicalSiteId { get; set; }

    [JsonPropertyName("vmwareSiteId")]
    public string? VmwareSiteId { get; set; }
}
