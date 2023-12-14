using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncGroups;


internal class SyncGroupSchemaModel
{
    [JsonPropertyName("masterSyncMemberName")]
    public string? MasterSyncMemberName { get; set; }

    [JsonPropertyName("tables")]
    public List<SyncGroupSchemaTableModel>? Tables { get; set; }
}
