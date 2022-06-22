using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.ApplicationGroup;


internal class ApplicationGroupPropertiesModel
{
    [JsonPropertyName("applicationGroupType")]
    [Required]
    public ApplicationGroupTypeConstant ApplicationGroupType { get; set; }

    [JsonPropertyName("cloudPcResource")]
    public bool? CloudPcResource { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("hostPoolArmPath")]
    [Required]
    public string HostPoolArmPath { get; set; }

    [JsonPropertyName("migrationRequest")]
    public MigrationRequestPropertiesModel? MigrationRequest { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("workspaceArmPath")]
    public string? WorkspaceArmPath { get; set; }
}
