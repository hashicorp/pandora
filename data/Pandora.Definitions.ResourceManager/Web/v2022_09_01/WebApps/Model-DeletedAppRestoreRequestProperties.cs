using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class DeletedAppRestoreRequestPropertiesModel
{
    [JsonPropertyName("deletedSiteId")]
    public string? DeletedSiteId { get; set; }

    [JsonPropertyName("recoverConfiguration")]
    public bool? RecoverConfiguration { get; set; }

    [JsonPropertyName("snapshotTime")]
    public string? SnapshotTime { get; set; }

    [JsonPropertyName("useDRSecondary")]
    public bool? UseDRSecondary { get; set; }
}
